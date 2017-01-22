//
// Mecanimのアニメーションデータが、原点で移動しない場合の Rigidbody付きコントローラ
// サンプル
// 2014/03/13 N.Kobyasahi
//
using UnityEngine;
using UnityEngine.AI;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class LocomotionSimpleAgent : MonoBehaviour
{
    public GameObject player; /// TODO: Make this take damage
    public float animSpeed = 1.5f;              // アニメーション再生速度設定
    public float lookSmoother = 3.0f;           // a smoothing setting for camera motion
    public bool useCurves = true;               // Mecanimでカーブ調整を使うか設定する
                                                // このスイッチが入っていないとカーブは使われない
    public float useCurvesHeight = 0.5f;        // カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）
    
    private bool _attacking;
    public bool attacking
    {
        get { return _attacking; }
        set { _attacking = value; }
    }

    // 以下キャラクターコントローラ用パラメタ
    // 前進速度
    public float _forwardSpeed = 7.0f;
    public float forwardSpeed
    {
        get { return _forwardSpeed; }
        set { _forwardSpeed = value; }
    }
    // 後退速度
    public float backwardSpeed = 2.0f;
    // 旋回速度
    public float rotateSpeed = 2.0f;
    // ジャンプ威力
    public float jumpPower = 3.0f;
    // キャラクターコントローラ（カプセルコライダ）の参照
    private CapsuleCollider col;
    private Rigidbody rb;
    // キャラクターコントローラ（カプセルコライダ）の移動量
    private Vector3 velocity;
    // CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
    private float orgColHight;
    private Vector3 orgVectColCenter;

    private Animator anim;                          // キャラにアタッチされるアニメーターへの参照
    private AnimatorStateInfo currentBaseState;			// base layerで使われる、アニメーターの現在の状態の参照
    private NavMeshAgent agent;

    private GameObject cameraObject;    // メインカメラへの参照

    // アニメーター各ステートへの参照
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int locoState = Animator.StringToHash("Base Layer.Locomotion");
    static int jumpState = Animator.StringToHash("Base Layer.Jump");
    static int restState = Animator.StringToHash("Base Layer.Rest");
    static int attkState = Animator.StringToHash("Base Layer.POSE26");

    // 初期化
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        _attacking = false;
        agent = GetComponent<NavMeshAgent>();
        // Don’t update position automatically
        agent.updatePosition = false;
        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();
        // CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        //メインカメラを取得する
        cameraObject = GameObject.FindWithTag("MainCamera");
        // CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
        orgColHight = col.height;
        orgVectColCenter = col.center;
    }


    // 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
    void FixedUpdate()
    {
        forwardSpeed = EnemyHealth.speed;
        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        float h = Vector3.Dot(transform.right, worldDeltaPosition);
        float v = Vector3.Dot(transform.forward, worldDeltaPosition);
        anim.SetFloat("Speed", v);                          // Animator側で設定している"Speed"パラメタにvを渡す
        anim.SetFloat("Direction", h);                      // Animator側で設定している"Direction"パラメタにhを渡す
        anim.speed = animSpeed;                             // Animatorのモーション再生速度に animSpeedを設定する
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0); // 参照用のステート変数にBase Layer (0)の現在のステートを設定する
        rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする



        // 以下、キャラクターの移動処理
        velocity = new Vector3(0, 0, v);        // 上下のキー入力からZ軸方向の移動量を取得
                                                // キャラクターのローカル空間での方向に変換
        velocity = transform.TransformDirection(velocity);
        //以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
        if (v > 0.1)
        {
            velocity *= _forwardSpeed;       // 移動速度を掛ける
        }
        else if (v < -0.1)
        {
            velocity *= backwardSpeed;  // 移動速度を掛ける
        }


        // 上下のキー入力でキャラクターを移動させる
        transform.localPosition += velocity * Time.fixedDeltaTime;

        // 左右のキー入力でキャラクタをY軸で旋回させる
        transform.Rotate(0, h * rotateSpeed, 0);


        // 以下、Animatorの各ステート中での処理
        // Locomotion中
        // 現在のベースレイヤーがlocoStateの時
        if (currentBaseState.nameHash == locoState)
        {
            //カーブでコライダ調整をしている時は、念のためにリセットする
            if (useCurves)
            {
                resetCollider();
            }
        }
        // IDLE中の処理
        // 現在のベースレイヤーがidleStateの時
        else if (currentBaseState.nameHash == idleState)
        {
            //カーブでコライダ調整をしている時は、念のためにリセットする
            if (useCurves)
            {
                resetCollider();
            }
            // スペースキーを入力したらRest状態になる
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("Rest", true);
            }
            else if (_attacking)
            {
                anim.SetBool("Attacking", true);
            }
        }
        // REST中の処理
        // 現在のベースレイヤーがrestStateの時
        else if (currentBaseState.nameHash == restState)
        {
            //cameraObject.SendMessage("setCameraPositionFrontView");		// カメラを正面に切り替える
            // ステートが遷移中でない場合、Rest bool値をリセットする（ループしないようにする）
            if (!anim.IsInTransition(0))
            {
                anim.SetBool("Rest", false);
            }
        }
        else if (currentBaseState.nameHash == attkState)
        {
            if (!anim.IsInTransition(0))
            {
                if (anim.GetBool("Attacking"))
                {
                    PlayerHealth.playerHealth.health = PlayerHealth.playerHealth.health - EnemyHealth.enemyDamage;
                    Debug.Log("Stay Away from Senpai, Nyaa~");
                }
                anim.SetBool("Attacking", false);
            }
        }
    }


    // キャラクターのコライダーサイズのリセット関数
    void resetCollider()
    {
        // コンポーネントのHeight、Centerの初期値を戻す
        col.height = orgColHight;
        col.center = orgVectColCenter;
    }
}

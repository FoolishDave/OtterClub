using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashPose : MonoBehaviour {

    Animator anim;
    AnimatorStateInfo currentState;
    AnimatorStateInfo previousState;
    void Start()
    {
        anim = this.transform.GetComponent<Animator>();
    }

    void Update()
    {
        // "Next"フラグがtrueの時の処理
        if (anim.GetBool("Next"))
        {
            // 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
            currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                anim.SetBool("Next", false);
                previousState = currentState;
            }
        }
    }


    void OnCollisionEnter(Collision col)
    {
        NextPose();
    }
    void OnTriggerEnter(Collider col)
    {
        NextPose();
    }

    void NextPose()
    {
        Debug.Log("Updated unitychan~<3 pose");
        anim.SetBool("Next", true);
    }


}

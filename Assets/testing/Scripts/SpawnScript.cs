using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for spawning enemies at locations provided. Maintains a maximum number of enemies allowed to be spawned
/// </summary>
public class SpawnScript : MonoBehaviour {

    /// <summary>
    /// The prefab to be spawned when an enemy should be spawned
    /// </summary>
    public GameObject spawnedEnemy;

    // Manages the three states of enemies, not spawned, spawned and defeated
    private List<GameObject> enemiesNotSpawned;
    private List<GameObject> enemiesSpawned;
    private List<GameObject> defeatedEnemies;

    /// <summary>
    /// The number of enemies that have been spawned
    /// </summary>
    public long _totalEnemiesSpawned;

    public long totalEnemiesSpawned
    {
        get { return _totalEnemiesSpawned; }
        set { _totalEnemiesSpawned = value; }
    }

    /// <summary>
    /// The maximum number of enemies allowed to be present at one time
    /// </summary>
    public long _maxSpawnedEnemies;

    /// <summary>
    /// The property for getting and setting the max spawned enemies
    /// </summary>
    public long maxSpawnedEnemies
    {
        get { return _maxSpawnedEnemies; }
        set
        {
            _maxSpawnedEnemies = value;
            if (value > _maxSpawnedEnemies)
            {
                for (int i = 0; i < value - _maxSpawnedEnemies; i++)
                {
                    enemiesNotSpawned.Add(Instantiate(spawnedEnemy, new Vector3(1000f, 1000f, 1000f), Quaternion.identity));
                }
            }
            else if (_maxSpawnedEnemies > value)
            {
                for (int i = 0; i < _maxSpawnedEnemies - value; i++)
                {
                    GameObject notSpawnable = enemiesNotSpawned[i];
                    defeatedEnemies.Add(notSpawnable);
                    enemiesNotSpawned.Remove(notSpawnable);
                }
            }
        }
    }

    /// <summary>
    /// Create on start method unity
    /// </summary>
    private void Start()
    {
        enemiesNotSpawned = new List<GameObject>();
        enemiesSpawned = new List<GameObject>();
        defeatedEnemies = new List<GameObject>();
        for (int i = 0; i < maxSpawnedEnemies; i++)
        {
            enemiesNotSpawned.Insert(i, Instantiate(spawnedEnemy, new Vector3(i * 20.0f, 0, 0), Quaternion.identity));
            enemiesNotSpawned[i].SetActive(false);
        }
    }

    /// <summary>
    /// Spawns an enemy at provided position.
    /// </summary>
    /// <param name="position">Vector3 at which enemy should be spawned</param>
	public void spawnEnemy(Vector3 position)
    {
        if (totalEnemiesSpawned < maxSpawnedEnemies)
        {
            totalEnemiesSpawned++;
            GameObject spawningEnemy = enemiesNotSpawned[0];
            enemiesSpawned.Add(spawningEnemy);
            enemiesNotSpawned.Remove(spawningEnemy);
            spawningEnemy.SetActive(true);
            spawningEnemy.transform.position = position;
        }
        else
        {
            Debug.Log("Max spawnable enemies reached.");
        }
    }

    /// <summary>
    /// Resets the enemies spawned into the scene for wave progression
    /// </summary>
    public void resetEnemies()
    {
        enemiesNotSpawned.AddRange(enemiesSpawned);
        enemiesNotSpawned.AddRange(defeatedEnemies);
        while (enemiesSpawned.Count > 0)
        {
            enemiesSpawned.RemoveAt(0);
        }
        while (defeatedEnemies.Count > 0)
        {
            defeatedEnemies.RemoveAt(0);
        }
        enemiesNotSpawned.ForEach(gameObject => gameObject.SetActive(false));
    }

    /// <summary>
    /// Resets the game to its initial state
    /// </summary>
    public void resetGame()
    {
        resetEnemies();
    }
}

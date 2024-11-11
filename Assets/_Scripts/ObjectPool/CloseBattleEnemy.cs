using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBattleEnemy : MonoBehaviour
{
     private List<GameObject> pooledEnemies;
     public List<GameObject> enemies;
     
     public static CloseBattleEnemy Instance;

     private void Awake()
     {
          Instance = this;
     }

     private void Start()
     {
          pooledEnemies=new List<GameObject>();
          for (int i = 0; i < enemies.Count; i++)
          {
               GameObject enemy = Instantiate(enemies[i], Vector3.zero, Quaternion.identity);
               enemy.SetActive(false);
               pooledEnemies.Add(enemy);
          }
          StartCoroutine(SpawnEnemyAtRandomIntervals());
     }

     public GameObject GetEnemy()
     {
          if (pooledEnemies.Count == 0)
          {
               return null;
          }
          int randomIndex = UnityEngine.Random.Range(0, pooledEnemies.Count-1);
          Debug.Log(randomIndex);
          GameObject randomObject = pooledEnemies[randomIndex];
          pooledEnemies.RemoveAt(randomIndex);
          return randomObject;
     }

     public void ReturnToPool(GameObject gameObject)
     {
          gameObject.SetActive(false);
          pooledEnemies.Add(gameObject);
     }

     private Vector3 RandomSpawnPosition()
     {
          Vector3 randomSpawnPoint=new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f));
          return randomSpawnPoint;
     }
     private IEnumerator SpawnEnemyAtRandomIntervals()
     {
          while (true)
          {
               yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 5f));
               GameObject enemy = GetEnemy();
               if (enemy != null)
               {
                    // Set enemy active and spawn at a random position
                    enemy.SetActive(true);
                    enemy.transform.position = RandomSpawnPosition();
               }
          }
     }
}

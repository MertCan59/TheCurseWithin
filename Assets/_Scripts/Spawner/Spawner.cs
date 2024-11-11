using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnedObjects;
    [SerializeField] private float currentSpawnTime; 
    [SerializeField] private float timeBetweenSpawns;
    private void Start()
    {
        StartCoroutine(Spawn());    
    }
    private IEnumerator Spawn()
    {
        float elapsedTime = 0;
        while (elapsedTime <= currentSpawnTime)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(timeBetweenSpawns);
            var go= Instantiate(spawnedObjects[Random.Range(0,spawnedObjects.Count)], new Vector3(Random.Range(-15f,15f),Random.Range(-15f,15f),0), Quaternion.identity);
            go.SetActive(true);
        }
    }
}

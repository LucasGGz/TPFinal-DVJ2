using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{ 
    public GameObject[] myObjects; 
    private float spawnDuration = 30f;

    void Start() {
        StartCoroutine(StartSpawnRoutineCoroutine());
    }

    IEnumerator StartSpawnRoutineCoroutine() { 
        yield return new WaitForSeconds(6f); 
        StartCoroutine(SpawnObjectsCoroutine()); // Renombrado a SpawnObjectsCoroutine
        yield return new WaitForSeconds(spawnDuration);
        StopCoroutine(SpawnObjectsCoroutine()); // Renombrado a SpawnObjectsCoroutine
    }

    IEnumerator SpawnObjectsCoroutine() { // Renombrado a SpawnObjectsCoroutine
        while (true) { 
            int randomIndex = Random.Range(0, myObjects.Length);
            float randomZ = Random.Range(2f, -7f);
            Vector3 randomSpawnPosition = new Vector3(transform.position.x, transform.position.y, randomZ);
            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(3f); 
        } 
    } 
}


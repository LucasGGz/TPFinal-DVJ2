using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    private float spawnDuration = 28f;
    public bool shouldSpawn = true; // Variable de control

    void Start()
    {
        StartCoroutine(StartSpawnRoutineCoroutine());
    }

    IEnumerator StartSpawnRoutineCoroutine()
    {
        yield return new WaitForSeconds(7f);
        StartCoroutine(SpawnObjectsCoroutine());
        yield return new WaitForSeconds(spawnDuration);

        // Cambia la variable de control para detener la corrutina
        shouldSpawn = false;
    }

    IEnumerator SpawnObjectsCoroutine()
    {
        while (shouldSpawn) // Verifica la variable de control
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            float randomZ = Random.Range(2f, -7f);
            Vector3 randomSpawnPosition = new Vector3(transform.position.x, transform.position.y, randomZ);

            // Instancia el objeto
            GameObject spawnedObject = Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);

            // Obtén el componente de la trayectoria parabólica y configúralo
            MovimientoCubo parabolicMovement = spawnedObject.GetComponent<MovimientoCubo>();
            if (parabolicMovement != null)
            {
                parabolicMovement.SetInitialPosition(randomSpawnPosition);
            }

            yield return new WaitForSeconds(2f);
        }
    }
}


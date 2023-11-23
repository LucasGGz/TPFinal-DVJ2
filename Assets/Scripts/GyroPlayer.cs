using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroPlayer : MonoBehaviour
{
    Gyroscope steerGyro;
    public Rigidbody capsule;
    public float speed;
    public GameObject camara2;
    RandomObjectSpawner gene;

    void Start()
    {
        // Habilita el giroscopio
        steerGyro = Input.gyro;
        steerGyro.enabled = true;
        gene = GameObject.FindGameObjectWithTag("generador").GetComponent<RandomObjectSpawner>();
       
    }

    void Update()
    {
        // Transforma la rotación basada en el giroscopio
        //Quaternion gyroRotation = steerGyro.attitude;
       // gyroRotation = Quaternion.Euler(90f, 0f, 0f) * gyroRotation;

        // Calcula la velocidad basada en la inclinación del giroscopio en el eje X y Z
        float speedX = steerGyro.rotationRate.x * speed;
        float speedZ = steerGyro.rotationRate.z * speed;

        if (gene.shouldSpawn == true)
        {

            // Aplica la velocidad al rigidbody
            capsule.velocity = new Vector3(0f, 0f, speedZ);
        }
        else
        {
                camara2.SetActive(true);
                capsule.velocity = new Vector3(speedX, 0f, speedZ);
            
        }
      
    }
}

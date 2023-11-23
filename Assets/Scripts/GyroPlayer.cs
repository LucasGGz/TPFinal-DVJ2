using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroPlayer : MonoBehaviour
{
    Gyroscope steerGyro;
    public Rigidbody capsule;
    public float speed;

    void Start()
    {
        // Habilita el giroscopio
        steerGyro = Input.gyro;
        steerGyro.enabled = true;
    }

    void Update()
    {
        // Transforma la rotaci�n basada en el giroscopio
        //Quaternion gyroRotation = steerGyro.attitude;
       // gyroRotation = Quaternion.Euler(90f, 0f, 0f) * gyroRotation;

        // Calcula la velocidad basada en la inclinaci�n del giroscopio en el eje X y Z
        float speedX = steerGyro.rotationRate.x * speed;
        float speedZ = steerGyro.rotationRate.z * speed;

        // Aplica la velocidad al rigidbody
        capsule.velocity = new Vector3(0f, 0f, speedZ);
    }
}

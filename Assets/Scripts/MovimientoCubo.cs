using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCubo : MonoBehaviour


{
    private Vector3 initialPosition;
    private float startTime;
    public float height = 5f;
    public float forwardSpeed = 5f;
    public float upwardSpeed = 2f;
    public ValorPoints valorPoints;
    public float puntosQueda;
    void Start()
    {
        startTime = Time.time;
        valorPoints = FindObjectOfType<ValorPoints>();
    }

    void Update()
    {
        // Calcula el tiempo normalizado entre 0 y 1
        float t = (Time.time - startTime);

        // Calcula la posici�n seg�n la f�rmula de la par�bola
        float yOffset = upwardSpeed * t - 0.5f * 9.8f * t * t; // Ecuaci�n de movimiento vertical
        float xOffset = forwardSpeed * t;  // Ecuaci�n de movimiento horizontal
        transform.position = new Vector3(initialPosition.x + xOffset, initialPosition.y + yOffset, initialPosition.z);

        // Destruye el objeto despu�s de cierto tiempo (puedes ajustar esto seg�n tus necesidades)
       
    }

    // Configura la posici�n inicial de la trayectoria parab�lica
    public void SetInitialPosition(Vector3 position)
    {
        initialPosition = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("CHOCA");
            valorPoints.puntos += puntosQueda;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Plataforma"))
        {

            Destroy(gameObject);
        }

    }
}





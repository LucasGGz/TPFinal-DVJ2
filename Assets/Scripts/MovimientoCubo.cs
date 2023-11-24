using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float vidasPer;
    private SoundManager SoundManager;
    void Start()
    {
        SoundManager = FindObjectOfType<SoundManager>();
        startTime = Time.time;
        valorPoints = FindObjectOfType<ValorPoints>();
    }

    void Update()
    {
        // Calcula el tiempo normalizado entre 0 y 1
        float t = (Time.time - startTime);

        // Calcula la posición según la fórmula de la parábola
        float yOffset = upwardSpeed * t - 0.5f * 9.8f * t * t; // Ecuación de movimiento vertical
        float xOffset = forwardSpeed * t;  // Ecuación de movimiento horizontal
        transform.position = new Vector3(initialPosition.x + xOffset, initialPosition.y + yOffset, initialPosition.z);

        if (transform.position.y < -4.5f)
        {
            Destroy(gameObject);
            SoundManager.SeleccionAudio(1, 2f);
            valorPoints.vidas -= vidasPer;
            if (valorPoints.vidas <= 0)
            {
                valorPoints.vidas = 0;
                Debug.Log("perdiste");
                AudioPerm.Pausar();
                SoundManager.SeleccionAudio(2, 1.0f);
            }
        }
    }

    // Configura la posición inicial de la trayectoria parabólica
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
            SoundManager.SeleccionAudio(0, 5f);
        }

    }

    
}





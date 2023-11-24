using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GyroPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject particulas;
    Gyroscope steerGyro;
    public Rigidbody capsule;
    public float speed;
    public GameObject camara2;
    RandomObjectSpawner gene;
    public float puntosResta;
    public ValorPoints valorPoints;
    public float velocidadResta = 1f;
    private SoundManager SoundManager;
    void Start()
    {
        particulas.SetActive(false); 
        // Habilita el giroscopio
        steerGyro = Input.gyro;
        steerGyro.enabled = true;
        gene = GameObject.FindGameObjectWithTag("generador").GetComponent<RandomObjectSpawner>();
        valorPoints = FindObjectOfType<ValorPoints>();
        SoundManager = FindObjectOfType<SoundManager>();
    }


    void Update()
    {
        // Transforma la rotaci�n basada en el giroscopio
        //Quaternion gyroRotation = steerGyro.attitude;
       // gyroRotation = Quaternion.Euler(90f, 0f, 0f) * gyroRotation;

        // Calcula la velocidad basada en la inclinaci�n del giroscopio en el eje X y Z
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
                capsule.transform.rotation = Quaternion.Euler(0f, -90f, 0f);

        }
      
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ObjetoDescuento"))
        {
            Debug.Log("CHOCA");
            valorPoints.puntos -= puntosResta * velocidadResta;


            if (valorPoints.puntos < 0)
            {
                valorPoints.puntos = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ObjetoDescuento"))
        {


            if (valorPoints.puntos == 10)
            {
                Debug.Log("Ganaste");
                particulas.SetActive(true);
                AudioPerm.Pausar();
                SoundManager.SeleccionAudio(3, 1.0f);
                SceneManager.LoadScene("ganaste");
            }
            if (valorPoints.puntos != 10)
            {
                AudioPerm.Pausar();
                Debug.Log("Perdiste");
                SoundManager.SeleccionAudio(2, 1.0f);
                particulas.SetActive(false);
            }

        }
    }
}

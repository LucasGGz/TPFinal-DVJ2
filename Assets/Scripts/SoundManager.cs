using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audios; //arreglo para que podamos poner los sonidos independientes en el inspector
    private AudioSource controlAudio;

    private void Awake()//antes del start
    {

        controlAudio = GetComponent<AudioSource>();
    }

    public void SeleccionAudio(int indice, float volumen) //metodo estatico 
    {
        controlAudio.PlayOneShot(audios[indice], volumen); //El metodo PlayOneShot de la clase AudioSource nesesita el indice del array y el volumen
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPerm : MonoBehaviour
{
    AudioSource _audio;
    public static AudioPerm inst;//variable publica y estatica que almacena una instacia de esta clase de tipo AudioPerm

    private void Awake()//antes del start
    {
        if (AudioPerm.inst == null)
        {
            //primera vez. Esta es la instancia unica - si es nulo es la primera vez. 
            AudioPerm.inst = this; //Esta es la instancia unica
            DontDestroyOnLoad(gameObject); //y solo en ese caso que no lo destruya
            //cuando se crea otra instacia (scena) el scrip ya no va a hacer nulo, entonces en el else se destruye
            _audio = GetComponent<AudioSource>();//obtenemos el componente AudioSource
        }
        else
        {
            //ya hay una instancia. Eliminar esta
            Destroy(gameObject);
        }
    }

    public static void Suena() //desde otros scripts podemos llamar a este metodo, como son estaticos accedemos al metodo
    {                          //directamente desde la clase
        inst._audio.Play();
    }

    public static void Pausar()
    {
        inst._audio.Pause(); //desde otros scripts podemos llamar a este metodo
    }

    public static void Despausar()
    {
        inst._audio.UnPause(); //desde otros scripts podemos llamar a este metodo
    }
}

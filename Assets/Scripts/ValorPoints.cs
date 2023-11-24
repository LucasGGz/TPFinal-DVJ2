using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValorPoints : MonoBehaviour
{
    public float puntos;
    public TextMeshProUGUI textoPuntos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textoPuntos.text = "" + puntos.ToString();
        if (puntos == 4)
        {
            Debug.Log("ganaste");
        }
    }
}

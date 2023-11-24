using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Animator animFade;

    public void Scene01()
    {
        animFade.SetBool("Oculto", true);
        StartCoroutine(Load());

        IEnumerator Load()
        {
            yield return new WaitForSeconds(3.0f);
            //SceneManager.LoadScene(1);
            SceneManager.LoadScene("TerrainScene");
        }
    }
}

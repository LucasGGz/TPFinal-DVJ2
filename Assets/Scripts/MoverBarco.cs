/**using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5f;
    private bool shouldMove = false;
    private float moveDistance = 0f; // Variable para guardar la distancia recorrida
    
    private void Update()
    {
        if (Time.time >= 10f && !shouldMove)
        {
            shouldMove = true;
            moveDistance = transform.position.z + 30f; // Guardar la posición z actual más 10 unidades
        }
        
        if (shouldMove && transform.position.z < moveDistance)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}**/

using UnityEngine;

public class MovementController : MonoBehaviour { 

    public float speed = 5f; 
    private bool shouldMove = false; 
    private float moveDistance = 0f; // Variable para guardar la distancia recorrida 
    private float pauseTimer = 0f; // Variable para contar los segundos de pausa


private void Update() { 

    if (Time.time >= 4f && !shouldMove) { 

    shouldMove = true; 
    moveDistance = transform.position.z + 15f; // Guardar la posición z actual más 10 unidades 

}


if (shouldMove && transform.position.z < moveDistance) { 

    transform.Translate(Vector3.forward * speed * Time.deltaTime); 

    }


if (shouldMove && transform.position.z >= moveDistance && pauseTimer <= 10f) {

     pauseTimer += Time.deltaTime;
}


if (pauseTimer >= 10f && shouldMove && transform.position.z >= moveDistance) { 

    shouldMove = false; 
    moveDistance = transform.position.z + 20f; // Guardar la posición z actual más 20 unidades 
}



 } }

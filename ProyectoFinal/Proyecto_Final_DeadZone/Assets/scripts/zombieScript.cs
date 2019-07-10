using UnityEngine;
using System.Collections;

public class zombieScript : MonoBehaviour {
    //declara la transformación de nuestro objetivo (hacia donde se moverá el agente de navmesh) y nuestro agente de navmesh (en este caso, nuestro zombi)
  private Transform goal;
  private UnityEngine.AI.NavMeshAgent agent;

  // Usa esto para la inicialización
  void Start () {

    // crear referencias
    goal = Camera.main.transform;
    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    // establecer el destino de los agentes navmesh igual a la posición de la cámara principal (nuestro personaje en primera persona)
    agent.destination = goal.position;
    // comienza la animación de caminar
    GetComponent<Animation>().Play ("walk_in_place");
  }


  // para que esto funcione, ambos necesitan colisionadores, uno debe tener un cuerpo rígido y el zombi debe tener el gatillo activado.
  void OnTriggerEnter (Collider col)
  {
    // primero deshabilita el colisionador de zombies para que no puedan ocurrir múltiples colisiones
    GetComponent<CapsuleCollider>().enabled = false;
    // destruir la bala
    Destroy(col.gameObject);
    // detener al zombi para que no avance al establecer su destino en su posición actual
    agent.destination = gameObject.transform.position;
    // Detener la animación de caminar y reproducir la animación de retroceso.
    GetComponent<Animation>().Stop ();
    GetComponent<Animation>().Play ("fallingback");
    // Destruye a este zombie en seis segundos.
    Destroy (gameObject, 6);
    // instanciar un nuevo zombie
    GameObject zombie = Instantiate(Resources.Load("zombie", typeof(GameObject))) as GameObject;

    // establece las coordenadas para un nuevo vector 3
    float randomX = UnityEngine.Random.Range (-12f,12f);
    float constantY = .01f;
    float randomZ = UnityEngine.Random.Range (-13f,13f);
    // establecer la posición de zombies igual a estas nuevas coordenadas
    zombie.transform.position = new Vector3 (randomX, constantY, randomZ);

    // si el zombi se posiciona a menos de 3 unidades de escena de la cámara, no podremos dispararle
    // así que sigue reposicionando al zombi hasta que esté a más de 3 unidades de escena de distancia.
    while (Vector3.Distance (zombie.transform.position, Camera.main.transform.position) <= 3) {
      
      randomX = UnityEngine.Random.Range (-12f,12f);
      randomZ = UnityEngine.Random.Range (-13f,13f);

      zombie.transform.position = new Vector3 (randomX, constantY, randomZ);
    }

  }

}
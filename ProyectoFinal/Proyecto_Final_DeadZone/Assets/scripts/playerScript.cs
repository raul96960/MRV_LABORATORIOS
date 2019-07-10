using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

  // declara GameObjects y crea isShooting booleano.
  private GameObject gun;
  private GameObject spawnPoint;
  private bool isShooting;

  // Usa esto para la inicializaci�n
  void Start () {

    // solo es necesario para iOS
    Application.targetFrameRate = 60;

    // crear referencias a los objetos de punto de generaci�n de bala y pistola
    gun = gameObject.transform.GetChild (0).gameObject;
    spawnPoint = gun.transform.GetChild (0).gameObject;

    // establece isShooting bool a default de false
    isShooting = false;
  }

  // La funci�n de disparo es IEnumerator, por lo que podemos demorar unos segundos.
  IEnumerator Shoot() {
    // set est� disparando a verdadero, as� que no podemos disparar continuamente
    isShooting = true;
    // instanciar la bala
    GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
    // Obtenga el componente de cuerpo r�gido de la bala y establezca su posici�n y rotaci�n igual a la del spawnPoint
    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    bullet.transform.rotation = spawnPoint.transform.rotation;
    bullet.transform.position = spawnPoint.transform.position;
    // agrega fuerza a la bala en la direcci�n del vector hacia adelante del spawnPoint
    rb.AddForce(spawnPoint.transform.forward * 500f);
    // Reproduce el sonido de disparo y la animaci�n de arma.
    GetComponent<AudioSource>().Play ();
    gun.GetComponent<Animation>().Play ();
    // destruir la bala despu�s de 1 segundo
    Destroy (bullet, 1);
    // espera 1 segundo y configura isShooting como falso para que podamos disparar nuevamente
    yield return new WaitForSeconds (1f);
    isShooting = false;
  }

  // La actualizaci�n se llama una vez por trama
  void Update () {

    // declara un nuevo RayCastHit
    RaycastHit hit;
    // dibujar el rayo para fines de depuraci�n (solo se mostrar� en la vista de escena)
    Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.green);

    // lanza un rayo desde el punto de generaci�n en la direcci�n de su vector directo
    if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, 100)){

      // si el raycast golpea cualquier objeto del juego donde su nombre contenga "zombie"
      //y no estemos disparando, comenzaremos a disparar.
      if (hit.collider.name.Contains("zombie")) {
        if (!isShooting) {
          StartCoroutine ("Shoot");
        }

      }
        
    }
      
  }
}

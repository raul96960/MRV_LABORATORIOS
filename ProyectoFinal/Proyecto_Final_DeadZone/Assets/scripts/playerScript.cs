using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

  // declara GameObjects y crea isShooting booleano.
  private GameObject gun;
  private GameObject spawnPoint;
  private bool isShooting;

  // Usa esto para la inicialización
  void Start () {

    // solo es necesario para iOS
    Application.targetFrameRate = 60;

    // crear referencias a los objetos de punto de generación de bala y pistola
    gun = gameObject.transform.GetChild (0).gameObject;
    spawnPoint = gun.transform.GetChild (0).gameObject;

    // establece isShooting bool a default de false
    isShooting = false;
  }

  // La función de disparo es IEnumerator, por lo que podemos demorar unos segundos.
  IEnumerator Shoot() {
    // set está disparando a verdadero, así que no podemos disparar continuamente
    isShooting = true;
    // instanciar la bala
    GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
    // Obtenga el componente de cuerpo rígido de la bala y establezca su posición y rotación igual a la del spawnPoint
    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    bullet.transform.rotation = spawnPoint.transform.rotation;
    bullet.transform.position = spawnPoint.transform.position;
    // agrega fuerza a la bala en la dirección del vector hacia adelante del spawnPoint
    rb.AddForce(spawnPoint.transform.forward * 500f);
    // Reproduce el sonido de disparo y la animación de arma.
    GetComponent<AudioSource>().Play ();
    gun.GetComponent<Animation>().Play ();
    // destruir la bala después de 1 segundo
    Destroy (bullet, 1);
    // espera 1 segundo y configura isShooting como falso para que podamos disparar nuevamente
    yield return new WaitForSeconds (1f);
    isShooting = false;
  }

  // La actualización se llama una vez por trama
  void Update () {

    // declara un nuevo RayCastHit
    RaycastHit hit;
    // dibujar el rayo para fines de depuración (solo se mostrará en la vista de escena)
    Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.green);

    // lanza un rayo desde el punto de generación en la dirección de su vector directo
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

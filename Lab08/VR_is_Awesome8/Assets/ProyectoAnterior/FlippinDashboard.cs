using UnityEngine;
using System.Collections;

public class FlippinDashboard : MonoBehaviour
{
    //Esta script hace referencia al otro HeadGesturecomponente
    private HeadGesture gesture;
    private GameObject dashboard;
    private bool isOpen = true;
    private Vector3 startRotation;
    private float timer = 0.0f;
    private float timerReset = 2.0f;

    void Start()
    {
        gesture = GetComponent<HeadGesture>();
        dashboard = GameObject.Find("Dashboard");
        //inicializamos startRotationel tablero de instrumentos en su posición abierta
        startRotation = dashboard.transform.eulerAngles;
        CloseDashboard();
    }
    //función verifica si el usuario está en isFacingDowngesto
    //y abre el panel de control. De lo contrario, cierra el dashboard
    void Update()
    {
        if (gesture.isMovingDown)
        {
            OpenDashboard();
        }
        //pregunta durante cada actualización si el usuario está mirando hacia abajo ( gesture.isFacingDown)
        else if (!gesture.isFacingDown)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                CloseDashboard();
            }
        }
        else
        {
            timer = timerReset;
        }
    }
    //función la cierra estableciendo su rotación X en 180 grados, pero solo si ya está abierta.
    private void CloseDashboard()
    {
        if (isOpen)
        {
            dashboard.transform.eulerAngles = new Vector3(180.0f, startRotation.y, startRotation.z);
            isOpen = false;
        }
    }
    //función restaura la rotación a la configuración abierta, pero solo si está actualmente cerrada.
    private void OpenDashboard()
    {
        if (!isOpen)
        {
            dashboard.transform.eulerAngles = startRotation;
            isOpen = true;
        }
    }
}
using UnityEngine;
using System.Collections;

public class HeadGesture : MonoBehaviour
{
    public bool isFacingDown = false;
    public bool isMovingDown = false;

    private float sweepRate = 100.0f;
    private float previousCameraAngle;

    void Start()
    {
        previousCameraAngle = CameraAngleFromGround();
    }

    // La actualización se llama una vez por cuadro
    void Update()
    {
        isFacingDown = DetectFacingDown();
        isMovingDown = DetectMovingDown();
    }
    //función verifica si el ángulo de la cámara está dentro de 60 grados de recta hacia abajo.
    private bool DetectFacingDown()
    {
        //CameraAngleFromGround() ==> obtenemos el ángulo de la cámara actual en relación a abajo,
        //devolviendo un valor entre 0 y 180 grados.
        return (CameraAngleFromGround() < 60.0f);
    }

    //función obtiene la rotación (ángulo) de la cámara X cada vez que Update() se llama
    //y la compara con previousCameraAngle
    private bool DetectMovingDown()
    {
        float angle = CameraAngleFromGround();
        float deltaAngle = previousCameraAngle - angle;
        float rate = deltaAngle / Time.deltaTime;
        previousCameraAngle = angle;
        return (rate >= sweepRate);
    }

    private float CameraAngleFromGround()
    {
        return Vector3.Angle(Vector3.down, Camera.main.transform.rotation * Vector3.forward);
    }
}
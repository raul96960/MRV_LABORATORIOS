using UnityEngine;
using System.Collections;
public class HeadLookWalk : MonoBehaviour
{
    public float velocity = 0.7f;
    public bool isWalking = false;

    private CharacterController controller;
    private Clicker clicker = new Clicker();
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    //Reemplazado para que tengamos gravedad
    /*void Update()
    {
        Vector3 moveDirection = Camera.main.transform.forward;
        moveDirection *= velocity * Time.deltaTime;
        moveDirection.y = 0.0f;
        controller.Move(moveDirection);
    }*/

    void Update()
    {
        if (clicker.clicked())
        {
            isWalking = !isWalking;
        }
        if (isWalking)
        {
            controller.SimpleMove(Camera.main.transform.forward * velocity);
        }
    }
}
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

//La manguera debe encenderse y apagarse cada cinco segundos
public class ButtonExecuteTest : MonoBehaviour
{
    private GameObject startButton, stopButton;
    //que dice que si la manguera(hose) está encendida o apagada
    private bool on = false;
    private float timer = 5.0f;

    void Start()
    {
        //para obtenerlos en lugar de tener que arrastrarlos y soltarlos en el editor de Unity
        startButton = GameObject.Find("StartButton");
        stopButton = GameObject.Find("StopButton");
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            on = !on;
            timer = 5.0f;

            PointerEventData data = new PointerEventData(EventSystem.current);
            if (on)
            {
                //Ya que configuramos el botón para responder a los OnClick()
                //Cuando queremos encender la manguera(hose)
                ExecuteEvents.Execute<IPointerClickHandler>(startButton, data, ExecuteEvents.pointerClickHandler);
            }
            else
            {
                //Cuando queremos apagarlo, pedimos lo mismo para stopButton
                ExecuteEvents.Execute<IPointerClickHandler>(stopButton, data, ExecuteEvents.pointerClickHandler);
            }
        }
    }
}
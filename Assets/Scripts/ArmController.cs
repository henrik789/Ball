using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attatched to the ArmControl component, child of the Arm component. 
//Has a list of positions in the script 
//where the positions are child child of the Arm component (needs Box collider).
//The positions object has no script.

//Jumper/Ball controller script component with a list of positions
//needed in Ball Game Object. With box collider(is trigger)


public class ArmController : MonoBehaviour {

    public List<Transform> positions = new List<Transform>();


    int currentPosition = 0;


    private void OnEnable()
    {
        InputController.OnLeftPressed += Input_OnLeftPressed;
        InputController.OnRightPressed += Input_OnRightPressed;
    }

    private void OnDisable()
    {
        InputController.OnLeftPressed -= Input_OnLeftPressed;
        InputController.OnRightPressed -= Input_OnRightPressed;
    }

    private void Start()
    {
        transform.position = positions[currentPosition].position;
    }


    void Input_OnLeftPressed()
    {
        if (currentPosition > 0)
        {
            currentPosition--;
            transform.position = positions[currentPosition].position;
        }
    }

    void Input_OnRightPressed()
    {
        if (currentPosition < positions.Count - 1)
        {
            currentPosition++;
            transform.position = positions[currentPosition].position;
        }
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeftPressed;
    public static event ButtonPressed OnRightPressed;

    public float buttonMargin = 2;

    void Update()
    {


#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (OnLeftPressed != null && pos.x < -buttonMargin)
                OnLeftPressed();
            else if (OnRightPressed != null && pos.x > buttonMargin)
                OnRightPressed();
        }
#else
        foreach(Touch touch in Input.touches ) {
            if (touch.phase == TouchPhase.Began) {

                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

                if (OnLeftPressed != null && pos.x < -buttonMargin)
                    OnLeftPressed();
                else if (OnRightPressed != null && pos.x > buttonMargin)
                    OnRightPressed();
            }
        }


#endif


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    TextMeshPro gameOverText;

    private void Start()
    {
        gameOverText = GetComponent<TextMeshPro>();

        //gameOverText.SetText("");

        if (gameOverText == null)
        {
            Debug.LogError("Textmesh component not found!");
        }
    }


}

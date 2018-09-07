using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PointsController pointsController;
    public LifeViewController lifeController;
    public GameObject ball1;
    public GameObject ball2;
    int points = 0;
    bool gameOver = false;


    void Start () {

        lifeController.RestoreAllLives();
      

    }



    public bool Miss(GameObject ball)
    {

        RaycastHit2D hit = Physics2D.Raycast(ball.transform.position, Vector2.down);
        if (hit.collider != null)
        {
            Debug.Log("Not Miss");
            BallSaved();
            return false;

        }
        else
        {
            Debug.Log("Miss");
            LoseOneLife();
            return true;
        }
    }

    void BallSaved(){
        points++;
        pointsController.SetPoint(points);
    }

    void LoseOneLife()
    {
        if (!lifeController.RemoveLife())
        {
            Debug.Log("Game Over!");
            gameOver = true;
        }
    }

    void Update () {
		
	}
}

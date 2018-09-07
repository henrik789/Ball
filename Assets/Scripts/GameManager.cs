using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public PointsController pointsController;
    public LifeViewController lifeController;
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public AnimationCurve difficulty;
    float speed = 0.7f;
    int points = 0;
    //bool gameOver = false;

     
    void Start () {

        lifeController.RestoreAllLives();
        ball3.gameObject.SetActive(false);

        if (ball1.GetComponentInChildren<BallController>() != null)
        {
            ball1.GetComponentInChildren<BallController>().moveDelay = speed;
        }
        if (ball2.GetComponentInChildren<BallController>() != null)
        {
            ball2.GetComponentInChildren<BallController>().moveDelay = speed;
        }
        if (ball3.GetComponentInChildren<BallController>() != null)
        {
            ball3.GetComponentInChildren<BallController>().moveDelay = speed;
        }



    }

    void SetBallThreeActive(){
        if (ball3.gameObject != null)
        {
            if (points >= 6)
            {
                ball3.gameObject.SetActive(true);
            }
        }
    }



    public bool Miss(GameObject ball)
    {

        RaycastHit2D hit = Physics2D.Raycast(ball.transform.position, Vector2.down);
        if (hit.collider != null)
        {
            //Debug.Log("Not Miss");
            BallSaved();
            return false;

        }
        else
        {
            //Debug.Log("Miss");
            LoseOneLife();
            return true;
        }
    }

    void BallSaved(){
        points++;
        pointsController.SetPoint(points);
        SetBallThreeActive();
        IncreaseSpeed();
    }

    void IncreaseSpeed(){

        if (points < 100)
        {
            //Debug.Log("speed " + difficulty.Evaluate(points / 100));
        }

        speed -= (1f - difficulty.Evaluate( points / 100.0f)) * 0.1f;
        Debug.Log("Movedelay: " + speed);


        if (ball1.gameObject != null)
        {
            ball1.GetComponentInChildren<BallController>().moveDelay = speed;
        }
        if (ball2.gameObject != null)
        {
            ball2.GetComponentInChildren<BallController>().moveDelay = speed;
        }
        if (ball3.gameObject != null)
        {
            ball3.GetComponentInChildren<BallController>().moveDelay = speed;
        }


        //ball1.GetComponentInChildren<BallController>().moveDelay = speed;
        //ball2.GetComponentInChildren<BallController>().moveDelay = speed;
        //ball3.GetComponentInChildren<BallController>().moveDelay = speed;


    }

    void LoseOneLife()
    {
        if (!lifeController.RemoveLife())
        {
            Debug.Log("Game Over!");
            //gameOver = true;
        }
    }

    void Update () {


    }
}

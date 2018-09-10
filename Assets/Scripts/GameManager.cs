using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private BallController ballController1;
    private BallController ballController2;
    private BallController ballcontroller3;

    public PointsController pointsController;
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject gameover;
    public AnimationCurve difficulty;
    float speed = 0.8f;
    int points = 0;
    AudioSource m_MyAudioSource; 
    public bool m_play;
    bool gameOver = false;



    //Application
    void Start () {
    
            gameover.gameObject.SetActive(false);
            ball3.gameObject.SetActive(false);
            m_MyAudioSource = GetComponent<AudioSource>();

        ballController1 = ball1.GetComponentInChildren<BallController>();
        ballController2 = ball2.GetComponentInChildren<BallController>();
        ballcontroller3 = ball3.GetComponentInChildren<BallController>();



            if (ballController1 != null)
            {
                ballController1.moveDelay = speed;
            }
            if (ballController2 != null)
            {
                ballController2.moveDelay = speed;
            }
            if (ballcontroller3 != null)
            {
                ballcontroller3.moveDelay = speed;
            }


    }


    void SetBallThreeActive(){
        if (ball3.gameObject != null)
        {
            if (points >= 2)
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
            BallSaved();
            return false;

        }
        else
        {
            ballController1.Stop();
            ballController2.Stop();
            ballcontroller3.Stop();
            gameover.gameObject.SetActive(true);
            gameOver = true;
            return true;
        }
    }

    void BallSaved(){
        points++;
        pointsController.SetPoint(points);
        m_MyAudioSource.Play();
        SetBallThreeActive();
        IncreaseSpeed();
    }

    void IncreaseSpeed(){

        //if (points < 100)
        //{
        //    Debug.Log("speed " + difficulty.Evaluate(points / 50));
        //}

        speed -= (1f - difficulty.Evaluate( points / 100.0f)) * 0.06f;
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

    }
    void NewGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Update() 
    {
        if(gameOver != false )
        if (Input.anyKey)
        {
            NewGame();
        }

    }
}

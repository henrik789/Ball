
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BallController : MonoBehaviour
    {

        // [HideInInspector]
        public GameManager gameManager;


        public List<Transform> positions = new List<Transform>();
        float moveDelay = 0.7f;
        int currentPosition = 2;
        int direction = 1;
        int counter = 0;




        void Start()
        {

            transform.position = positions[currentPosition].position;

            StartCoroutine(Move());
        }



        IEnumerator Move()
        {

            while (true)
            {
                yield return new WaitForSeconds(moveDelay);

                currentPosition += direction;

                if (currentPosition == positions.Count - 1 || currentPosition == 0)
                {
                    if (!gameManager.Miss(gameObject))
                        SwitchDirection();
                    else
                        Die();

                }

                transform.position = positions[currentPosition].position;


            }

        }



        void SwitchDirection()
        {
            counter++;
            direction *= -1;

            if (counter % 5 == 1)
            {
                moveDelay /= 1.5f;

            }
            Debug.Log("Time: " + moveDelay);
            Debug.Log("" + counter);

        }


        void Die()
        {
            Destroy(transform.parent.gameObject);

        }

    }


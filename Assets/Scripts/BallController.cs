
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BallController : MonoBehaviour
    {

        // [HideInInspector]
        public GameManager gameManager;


        public List<Transform> positions = new List<Transform>();
        public float moveDelay = 0.7f;
        int currentPosition = 4;
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

    }


        void Die()
        {
            Destroy(transform.parent.gameObject);

        }

    }


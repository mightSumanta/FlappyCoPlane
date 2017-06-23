using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Example
{
	public class HitObstacle : MonoBehaviour 
	{
        public bool isFriendly = false;
        private GameObject scoreCanvas;
        private ScoreBoard scoreScript;
        private PlaneStatus statScript;

        private void OnEnable()
        {
            scoreCanvas = GameObject.FindGameObjectWithTag("Score");
            scoreScript = scoreCanvas.GetComponent<ScoreBoard>();
            statScript = GameObject.FindGameObjectWithTag("PlaneStat").GetComponent<PlaneStatus>();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Player")
            {
                if (isFriendly)
                {
                    scoreScript.addScore(1);
                }
                else
                {
                    Destroy(collider.gameObject);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    statScript.planeSpeed = 1;
                }
            }
        }
    }

}

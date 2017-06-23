using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Example
{
	public class ObstacleBehaviour : MonoBehaviour 
	{
        Vector3 drag = new Vector3();
        public GameObject hole;
        private PlaneStatus planeStatusScript;
        private float levelUp = 0.002f;
        private ScoreBoard scoreScript;
        Renderer rend;

		void OnEnable()
		{
            rend = hole.GetComponent<Renderer>();
            planeStatusScript = GameObject.FindGameObjectWithTag("PlaneStat").GetComponent<PlaneStatus>();
            scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreBoard>();
		}

		void Update () 
		{
            if (scoreScript.currentScore != 0 && scoreScript.currentScore % 5 == 0f)
            {
                planeStatusScript.planeSpeed += levelUp;
            }

            if (!GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(Camera.main), rend.bounds))
            {
                Destroy(gameObject);
            }

            drag = transform.position;
            drag.x -= planeStatusScript.planeSpeed * Time.deltaTime;
            transform.position = drag;
        }

   	}

}

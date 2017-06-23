using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Example
{
	public class ObstacleGeneration : MonoBehaviour 
	{
        public GameObject obstacle;
        public float minGap = 2;
        public float maxGap = 6;
        public float obstaclePos = 1.5f;
        private float actGap;
        private float nextcheck = 0f;
        private float checkRate = 0.5f;
        private PlayerControl playerControlScript;

		void OnEnable()
		{
            playerControlScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
            actGap = Random.Range(minGap, maxGap);
		}

		void Update () 
		{
            if (Time.time >= nextcheck)
            {
                actGap = Random.Range(minGap, maxGap);
                nextcheck = Time.time + checkRate;
            }

            if (playerControlScript.distance >= actGap)
            {
                playerControlScript.distance = 0;
                Vector3 spawnPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width , 0, 0));
                spawnPos.y = Random.Range(-obstaclePos, obstaclePos);
                spawnPos.z = 0;
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }
		}
	}

}

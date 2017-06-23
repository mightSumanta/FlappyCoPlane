using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Example
{
	public class PlaneStatus : MonoBehaviour 
	{

        public bool isRedPlane;
        public float planeSpeed = 1f;

        private void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }

}

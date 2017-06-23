using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Example
{
	public class SwitchPlane : MonoBehaviour 
	{
        public GameObject redPlane;
        public GameObject greenPlane;
        public GameObject inputBox;
        private PlaneStatus statScript;

        private void OnEnable()
        {
            statScript = GameObject.FindGameObjectWithTag("PlaneStat").GetComponent<PlaneStatus>();
            statScript.isRedPlane = true;
            redPlane.SetActive(true);
            greenPlane.SetActive(false);
        }

        private void OnMouseDown()
        {
            colorChange(1);

            if (statScript.isRedPlane)
            {
                statScript.isRedPlane = false;
                redPlane.SetActive(false);
                greenPlane.SetActive(true);
            }
            else
            {
                statScript.isRedPlane = true;
                redPlane.SetActive(true);
                greenPlane.SetActive(false);
            }

        }

        private void OnMouseUp()
        {
            colorChange(0.78f);
        }

        private void colorChange(float alpha)
        {
            Color tmp = inputBox.GetComponent<SpriteRenderer>().color;
            tmp.a = alpha;
            inputBox.GetComponent<SpriteRenderer>().color = tmp;
        }
    }

}

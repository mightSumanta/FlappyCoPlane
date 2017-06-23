using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Example
{
	public class ChangeScene : MonoBehaviour 
	{
        private float sceneIndex;

        private void OnEnable()
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        //private void OnMouseDown()
        //{
        //    if (sceneIndex == 0)
        //    {
        //        SceneManager.LoadScene(1);
        //    }
        //    else
        //    {
        //        SceneManager.LoadScene(0);
        //    }
        //}

        private void OnMouseUpAsButton()
        {
            if (sceneIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

}

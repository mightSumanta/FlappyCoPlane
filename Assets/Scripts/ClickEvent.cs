using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Example
{
	public class ClickEvent : MonoBehaviour 
	{
        public PlayerControl playerControlScript;
		
		void OnMouseDown()
        {
            playerControlScript.jump();
        }
	}

}

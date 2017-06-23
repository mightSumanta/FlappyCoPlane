using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Example
{
	public class PlayerControl : MonoBehaviour 
	{
        public float jumpHeight;
        public float distance;
        public GameObject redPlane;
        public GameObject greenPlane;
        private Animator anim;
        private PlaneStatus statScript;
        private Rigidbody2D myRigidbody;
        private SpriteRenderer sRend;
        private 

        void OnEnable()
		{
            initiate();
		}

        void Update ()
        {
            if (sRend != null)
            {
                if (!GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(Camera.main), sRend.bounds))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    statScript.planeSpeed = 1;
                }
            }

            distance += statScript.planeSpeed * Time.deltaTime;
        }

		void initiate()
		{
            myRigidbody = GetComponent<Rigidbody2D>();

            statScript = GameObject.FindGameObjectWithTag("PlaneStat").GetComponent<PlaneStatus>();

            if (statScript.isRedPlane)
            {
                redPlane.SetActive(true);
                greenPlane.SetActive(false);

                sRend = redPlane.GetComponent<SpriteRenderer>();
            }
            else
            {
                redPlane.SetActive(false);
                greenPlane.SetActive(true);

                sRend = greenPlane.GetComponent<SpriteRenderer>();
            }

            anim = GetComponent<Animator>();
        }

        public void jump()
        {
            if (sRend != null && GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(Camera.main), sRend.bounds))
            {
                myRigidbody.velocity = new Vector2(0, jumpHeight);
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("FlyAnimation"))
                {
                    anim.SetBool("isFlying", true);
                    StartCoroutine(fallTrigger());
                }
                else
                {
                    StopAllCoroutines();
                    StartCoroutine(fallTrigger());
                }
            }
        }

        IEnumerator fallTrigger()
        {
            yield return new WaitForSeconds(0.4f);
            anim.SetBool("isFlying", false);
        }

	}

}

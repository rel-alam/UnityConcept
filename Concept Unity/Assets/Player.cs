using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{

		public List<string> InventoryItems =
		new List<string> ();
		public float speed = 3;
		public float gravity = 20;
		public float jumpSpeed = 3;
		CharacterController controller = null;
		Vector3 moveDirection = Vector3.zero;

		void Start ()
		{
				controller = GetComponent<CharacterController> ();
		}

		void Update ()
		{
			
			
				if (controller.isGrounded) {

						moveDirection = Vector3.zero;

						float tempSpeed = speed * Time.deltaTime;

						if (Input.GetKey (KeyCode.LeftShift))
								tempSpeed *= 2;

						if (Input.GetKey ("w"))
								moveDirection.z = tempSpeed;

						if (Input.GetKey ("s"))
								moveDirection.z = -tempSpeed;
						
						moveDirection = transform.TransformDirection (moveDirection);
		
						if (Input.GetKey (KeyCode.Space))
								moveDirection.y = jumpSpeed;


				} else {

						moveDirection.y += gravity * Time.deltaTime;

				}

				controller.Move (moveDirection);

				if (Input.GetKey ("a"))
						transform.Rotate (new Vector3 (0, -90 * Time.deltaTime, 0));

				if (Input.GetKey ("d"))
						transform.Rotate (new Vector3 (0, 90 * Time.deltaTime, 0));
		}
}

















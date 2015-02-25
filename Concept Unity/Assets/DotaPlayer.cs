using UnityEngine;
using System.Collections;

public class DotaPlayer : MonoBehaviour
{

		NavMeshAgent agent = null;
		public GameObject fireball = null;
	public float meleeRange = 3;
	public float meleeAngle = 30;
		// Use this for initialization
		void Start ()
		{
				//agent = GetComponent<NavMeshAgent> ();
	
		}
	
		// Update is called once per frame
		void Update ()
	{

				if (Input.GetMouseButtonDown (0) &&
						Input.GetKey (KeyCode.LeftShift) == false) {

						Collider[] collisions = Physics.OverlapSphere (
																	transform.position,
																	meleeRange);

						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						Plane groundPlane = new Plane (Vector3.up, 0);
						float distance = 9999;
						groundPlane.Raycast (ray, out distance);
						Vector3 p = ray.origin + ray.direction * distance;
			
						p = p - transform.position;
						p.y = 0;
						p.Normalize ();
			
						for (int i = 0; i < collisions.Length; i++) {
								if (collisions [i].tag == "Goblin") {

										Vector3 toGoblin = collisions [i].transform.position - transform.position;
										toGoblin.Normalize (); 

										if (Vector3.Angle (p, toGoblin) <= meleeAngle)
												GameObject.Destroy (collisions [i].gameObject);
								}
						}
				}
				
				if (Input.GetMouseButtonDown (0) &&
				    Input.GetKey (KeyCode.LeftShift)) {

						GameObject ball = Instantiate (fireball,
			                        transform.position,
			                        Quaternion.identity) as GameObject;

						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						
						Plane groundPlane = new Plane (Vector3.up, 0);
						
						float distance = 9999;
						
						groundPlane.Raycast (ray, out distance);
						
						Vector3 p = ray.origin + ray.direction * distance;
		
						p = p - transform.position;
						p.y = 0;

						ball.GetComponent<FireBall> ().direction = p.normalized;
				}

				if (Input.GetMouseButtonDown (1)) {

						Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
						Plane groundPlane = new Plane (Vector3.up, 0);
			
						float distance = 9999;
			
						groundPlane.Raycast (ray, out distance);
			
						Vector3 p = ray.origin + ray.direction * distance;

						GetComponent<NavMeshAgent> ().SetDestination (p);
				}
		}
}

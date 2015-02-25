using UnityEngine;
using System.Collections;

public class IsoCamera : MonoBehaviour{

		Transform player = null;
		Vector3 offset = Vector3.zero;

		// Use this for initialization
		void Start (){
	
				player = GameObject.FindGameObjectWithTag ("Player").transform;
				offset = transform.position - player.position;

		}
	
		// Update is called once per frame
		void Update (){

				transform.position = player.position + offset;

		}
}

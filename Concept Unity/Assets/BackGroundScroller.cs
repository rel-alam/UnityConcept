using UnityEngine;
using System.Collections;

public class BackGroundScroller : MonoBehaviour 
{

	public float scrollSpeed;

	private Vector3 startPos;

	// Use this for initialization
	void Start () 
    {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
		float newPos = Mathf.Repeat (Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(0, newPos);
       // renderer.sharedMaterial.SetTextureOffset("
        transform.position = startPos + Vector3.forward * newPos;
	
	}
}

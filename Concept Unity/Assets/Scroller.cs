using UnityEngine;
using System.Collections;

public class Scroller : MonoBehaviour {

    public float scrollSpeed;

    private Vector2 savedOffset;

	// Use this for initialization
	void Start () {

        savedOffset = renderer.sharedMaterial.GetTextureOffset("_MainTex");
	
	}
	
	// Update is called once per frame
	void Update () {

        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
	
	}

    void OnDisable()
    {

    }
}

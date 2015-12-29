using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {

	public string jumpButton = "Fire1";
	public float jumpPower = 10.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown(jumpButton))
			GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower);
	}
}

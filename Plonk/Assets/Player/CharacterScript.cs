using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour
{

	public float inputDelay = 0.1f;
	public float forwardVel = 12.0f;
	public float rotateVel = 100.0f;
	public float jumpPower = 100.0f;
	Quaternion targetRotation;
	Rigidbody rBody;
	private float forwardInput, turnInput;

	void Start()
	{
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody>())
			rBody = GetComponent<Rigidbody>();
		else
			Debug.LogError("the character needs a rigidbody");


		forwardInput = turnInput = 0;
	}

	void GetInput()
	{
		forwardInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis("Horizontal");
	}

	void Update()
	{
		GetInput();
		Turn();
		if (Input.GetButtonDown("Jump"))
			Jump();
	}

	void FixedUpdate()
	{
		Run();
	}

	void Jump()
	{
		rBody.AddForce(transform.up * jumpPower);
	}

	void Run()
	{
		if (Mathf.Abs(forwardInput) > inputDelay)
			rBody.velocity = transform.forward * forwardInput * forwardVel;
		else
			rBody.velocity = Vector3.zero;
	}

	void Turn()
	{
		if (Mathf.Abs(turnInput) > inputDelay)
			targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
		transform.rotation = targetRotation;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCode : MonoBehaviour
{
	// Variables yay
	float _speed = 1f; // Speed of character
	float _jumpheight = 1f; // Height of jump
	float _cameraspeed = 3f; // Mouse sensitivity
	bool _inAir = false; // You'll never guess

	Rigidbody _rigidbody; // The rigidbody of this object
	
	void Start() // Start is called before the first frame update
	{
		Debug.Log("Hello World and all that");
		Cursor.lockState = CursorLockMode.Locked; // Stop mouse from wandering off to my other monitor etc (.None for stop)
		_rigidbody = GetComponent<Rigidbody>(); // Gets the rigidbody of this object (Doesn't *create* one, just gets it)
	}

	void Update() // Update is called once per frame
	{
		GetInputs(); // Updates player forces based on inputs
	}

	void GetInputs() // Updates position
	{
		// Rotates player using mouse
		float turnRads = _cameraspeed * Input.GetAxis("Mouse X"); // Current Mouse X delta
		transform.Rotate(0, turnRads, 0);
		// Check keys and calculate force
		float forwardsForce = 0; // Forwards force to apply
		if (Input.GetKey("w"))
		{
			forwardsForce += _speed;
		}
		if (Input.GetKey("s"))
		{
			forwardsForce -= _speed;
		}
		float rightForce = 0; // Left/Right force, treating right as positive
		if (Input.GetKey("d"))
		{
			rightForce += _speed;
		}
		if (Input.GetKey("a"))
		{
			rightForce -= _speed;
		}
		float jumpForce = 0; // Upwards force
		if (Input.GetKeyDown("space") && !_inAir)
		{
			jumpForce += _jumpheight;
			_inAir = true;
		}
		_rigidbody.AddForce(forwardsForce, jumpForce, rightForce); // Adds a force to the object
	}

	void OnCollisionEnter(Collision collision) // Detect ANY collision
	{
		if (collision.gameObject.name == "Level_Base") // Check if collided with flor (You could also use a tag)
		{
			_inAir = false;
		}
	}
}

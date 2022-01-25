using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCode : MonoBehaviour
{
	// Variables yay
	float _speed = 100f; // Speed of character
	float _jumpheight = 4000f; // Strength of jump
	float _cameraspeed = 3f; // Mouse sensitivity
	float _cameraangle = 0f; // Used to keep track of the camera angle, and adjust it's forwards direction accordingly
	bool _inAir = false; // You'll never guess

	Rigidbody _rigidbody; // The rigidbody of this object
	GameObject _cameraholder; // The object that the camera is linked to
	
	void Start() // Start is called before the first frame update
	{
		Debug.Log("Hello World and all that");
		Application.targetFrameRate = 60; // Sets the max FPS, and removes that horrible wining in my ear (This is the correct fix for this btw)
		Cursor.lockState = CursorLockMode.Locked; // Stop mouse from wandering off to my other monitor etc (.None for stop)
		_cameraholder = GameObject.Find("Camera Holder"); // The object the camera is linked to
		_rigidbody = GetComponent<Rigidbody>(); // Gets the rigidbody of this object (Doesn't *create* one, just gets it)
	}

	void Update() // Update is called once per frame
	{
		GetInputs(); // Updates player forces based on inputs
		_cameraholder.transform.position = transform.position; // Set the camera to look at me
	}

	void GetInputs() // Updates position
	{
		// Rotates camera using mouse
		float turnRads = _cameraspeed * Input.GetAxis("Mouse X"); // Current Mouse X delta
		_cameraangle += turnRads; // Update camera angle tracker
		_cameraholder.transform.Rotate(0, turnRads, 0, Space.World); // Rotates cam not player
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
		float rightForce = 0; // Left/Right force
		if (Input.GetKey("a"))
		{
			rightForce += _speed;
		}
		if (Input.GetKey("d"))
		{
			rightForce -= _speed;
		}
		float jumpForce = 0; // Upwards force
		if (Input.GetKeyDown("space") && !_inAir)
		{
			jumpForce += _jumpheight;
			_inAir = true;
		}
		Vector3 force = new Vector3(forwardsForce, jumpForce, rightForce);
		force = Quaternion.Euler(0, _cameraangle, 0) * force; // Rotate the force vector to align with the camera
		_rigidbody.AddForce(force); // Adds a force to the object
	}

	void OnCollisionEnter(Collision collision) // Detect ANY collision
	{
		if (collision.gameObject.tag == "Floor") // Check if collided with flor (You could also use a tag)
		{
			_inAir = false;
		}
	}
}

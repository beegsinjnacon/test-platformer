using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeCollsionEffect : MonoBehaviour
{
	public GameObject block; // Set in Unity
	void OnCollisionEnter(Collision collision) // Detect ANY collision
	{
		if (collision.gameObject.name == "Player") // Check if collided with flor (You could also use a tag)
		{
			for (int ii = 0; ii < 40; ii++)
			{
				Vector3 offset = new Vector3(Random.value * 20 - 10, 20 + Random.value * 10, Random.value * 20 - 10);
				Instantiate(block, transform.position + offset, Quaternion.identity);
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolGuyFuckingDied : MonoBehaviour
{
	public GameObject deadGuy;
	void OnCollisionEnter(Collision collision) // Detect ANY collision
	{
		if (collision.gameObject.name == "Player") 
		{
			Instantiate(deadGuy, transform.position, transform.rotation); // Brings a new dead guy into the game
			Destroy(gameObject); // Fucking dies
		}
	}
}

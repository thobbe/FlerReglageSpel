using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject_malin : MonoBehaviour {

	public Transform player;
	private float throwForce = 10;
	private bool hasPlayer = false;
	public bool beingCarried = false;
	private bool inserted = false;


	private Rigidbody rb;

	void OnTriggerEnter(Collider other)
	{
		// Om man "krockar" mission med en pick-up
		if(other.gameObject.CompareTag("Player")) //will only work if the Player has it's tag set to Player in Unity!!!!!!
		{
			hasPlayer = true;
		}


	}

	void OnTriggerExit(Collider other)	// när man inte längre krockar en pick-up med ett mission
	{

		if (other.gameObject.CompareTag("Player"))
		{
			hasPlayer = false;
		}
	}

	void Start()
	{
		rb = GetComponent<Rigidbody>();

	}

	void Update()
	{
		
		if (beingCarried) // om man bär något objekt 
		{ 
			if (Input.GetKeyDown (KeyCode.Z)) // här släpper man ett objekt genom att klicka på Z
			{	
				rb.isKinematic = false;
				transform.parent = null;
				beingCarried = false;
				//rb.AddForce (player.forward * throwForce);
			}
		}
		else // om man inte bär något objekt
		{
			if (Input.GetKeyDown(KeyCode.Z) && hasPlayer)	// här plockar man upp ett objekt genom att klicka på Z 
			{
				rb.isKinematic = true;
				transform.parent = player;
				beingCarried = true;
			}
		}
	}
}

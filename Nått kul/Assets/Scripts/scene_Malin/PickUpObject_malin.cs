using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject_malin : MonoBehaviour {

//    public Transform player;
//    public float throwForce = 10;
//    public bool hasPlayer = false;
//    bool beingCarried = false;
//
//    private Rigidbody rb;
//
//    void OnTriggerEnter(Collider other)
//    {
//        if(other.gameObject.CompareTag("Player"))
//        {
//            hasPlayer = true;
//        }
//        
//    }
//
//    void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.CompareTag("Player"))
//        {
//            hasPlayer = false;
//        }
//    }
//
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//
//
//    }
//
//    void Update()
//    {
//		
//        if (beingCarried)
//        {
//            if (Input.GetKeyDown(KeyCode.Z))
//            {
//                rb.isKinematic = false;
//                transform.parent = null;
//                beingCarried = false;
//                rb.AddForce(player.forward * throwForce);
//            }
//        }
//        else
//        {
//            if (Input.GetKeyDown(KeyCode.Z) && hasPlayer)
//            {
//                rb.isKinematic = true;
//                transform.parent = player;
//                beingCarried = true;
//            }
//        }
//    }

	public GameObject helper1;
	public GameObject helper2;
	public GameObject helper3;
	public GameObject helper4;

	public GameObject player;

	public bool pickedup1;
	public bool pickedup2;
	public bool pickedup3;
	public bool pickedup4;


	void Start()
	{
		pickedup1 = false;
		pickedup2 = false;
		pickedup3 = false;
		pickedup4 = false;
	}


	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			dropObject ();
		}
			

	}


	// här är other = player. eftersom det ör player som åker på objektet
	void OnTriggerEnter(Collider other)
    {
		gameObject.SetActive (false);

		Debug.Log ("inne i ontrigger");
        
		if (gameObject.name == "helper1") 
		{
			pickedup1 = true;
			//Debug.Log ("Inne i helper1");

		} 
		else if (gameObject.name == "helper2") 
		{
			pickedup2 = true;
		}
		else if (gameObject.name == "helper3") 
		{
			pickedup3 = true;
		}
		else if (gameObject.name == "helper4") 
		{
			pickedup4 = true;
		}
		//Debug.Log ("pickedup1 = " + pickedup1);
    }


	void dropObject()
	{
		//Debug.Log ("pickedup1, drop = " + pickedup1);
		// Get the position on the player
		Vector3 pos = player.transform.position;

		// If any object is picked up
		if (pickedup1) 
		{
			Debug.Log ("Någonting är upplockat!");
		} 
		else 
		{
			Debug.Log ("Ingenting är upplockat");
		}

	}























}

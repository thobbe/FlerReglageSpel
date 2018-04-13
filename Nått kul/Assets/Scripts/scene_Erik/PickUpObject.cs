using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    public Transform player;
    public float throwForce = 30;
    public bool hasPlayer = false;
    bool beingCarried = false;
    public bool inserted = false;

    private Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {
		
        if(other.gameObject.CompareTag("Player")) //will only work if the Player has it's tag set to Player in Unity!!!!!!
        {
            hasPlayer = true;
        }

        if (other.gameObject.CompareTag("Zone")) 
        {
            inserted = true;
            Destroy(gameObject);
            //Debug.Log("Batteri");
        }


    }

    void OnTriggerExit(Collider other)
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
        if (beingCarried)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                rb.isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                //rb.AddForce(player.forward * throwForce);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z) && hasPlayer)
            {
                rb.isKinematic = true;
                transform.parent = player;
                beingCarried = true;
            }
        }
    }
}
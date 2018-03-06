using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    public Transform player;
    public float throwForce = 10;
    public bool hasPlayer = false;
    bool beingCarried = false;

    private Rigidbody rb;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            hasPlayer = true;
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
                rb.AddForce(player.forward * throwForce);
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

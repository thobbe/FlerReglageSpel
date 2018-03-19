using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_malin : MonoBehaviour
{

//	private bool active1;
//	private bool active2;
//
//	public GameObject pickup1;
//	public GameObject pickup2;

    public float speed;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

//		active1 = true;
//		active2 = false;
//
//		pickup1.SetActive (active1);
//		pickup2.SetActive (active2);

    }

    void Update()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);

		rb.AddForce (movement * speed);

	}

//	void OnTriggerEnter(Collider other) 
//	{
//		// toggle which pick-up is visible using layers. 
//		if (other.gameObject.layer == 8) {
//			pickup1.SetActive (false);
//			pickup2.SetActive (true);
//		} else {
//			pickup1.SetActive (true);
//			pickup2.SetActive (false);
//		}
//	}
}
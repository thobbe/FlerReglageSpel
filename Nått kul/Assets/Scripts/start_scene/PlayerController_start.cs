using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_start : MonoBehaviour {

    public float speed;
    public float rotateSpeed;
    private CharacterController cc;

    // Use this for initialization
    void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        cc = GetComponent<CharacterController>();

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        cc.SimpleMove(forward * curSpeed);

    }
}

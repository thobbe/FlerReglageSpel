using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Controller : MonoBehaviour {
    public float speed;
    public string type;
    private ControllerInput controller = new ControllerInput();
    public GameObject arm;
    private Animator anim;
    private int counter;
	// Use this for initialization
	void Start () {
        anim = arm.GetComponent<Animator>();
        counter = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //Extend arm
        if (type == "Hydrogen")
        {
            Movement("Left", 355, 185);
        }
        else if(type == "Oxygen")
        {
            Movement("Right", 175, 5);
        }
    }

    void Movement(string name, int max, int min)
    {
        if (controller.GetAxis(name, "Vertical") > 0)
        {
            anim.Play("Robot Arm");
            if (counter < 120)
            {
                anim.SetFloat("Direction", 1.0f);
                counter += 1;
            }
            else
            {
                anim.SetFloat("Direction", 0.0f);
            }
        }
        else
        {
            if (counter > 0)
            {
                anim.SetFloat("Direction", -1.0f);
                counter -= 1;
            }
            else
            {
                anim.SetFloat("Direction", 0.0f);
            }
        }


        if (!(arm.transform.rotation.eulerAngles.y > max && controller.GetAxis(name, "Horizontal") > 0) &&
            !(arm.transform.rotation.eulerAngles.y < min && controller.GetAxis(name, "Horizontal") < 0))
        {
            arm.transform.Rotate(new Vector3(0, controller.GetAxis(name, "Horizontal"), 0));
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArmOxygen"))
        {
            Debug.Log("Test");
        }
    }
}

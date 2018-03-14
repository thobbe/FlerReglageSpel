using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Controller : MonoBehaviour {
    public float speed;
    public string type;
    private ControllerInput controller = new ControllerInput();
    public GameObject arm;

	// Use this for initialization
	void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {

        if (controller.ButtonPressed("Button1"))
        {
            arm.GetComponent<Animator>().SetFloat("Direction",1.0f);
            arm.GetComponent<Animator>().Play("Robot Arm");
        }
        else
        {
            arm.GetComponent<Animator>().SetFloat("Direction", -1.0f);
        }
       
        if (type == "Oxygen")
        {
            float moveVertical = controller.GetAxis("Left", "Vertical");
            transform.localScale += new Vector3(0, 0, 1.0F) * speed * moveVertical;

        }
        else
        {
            float moveVertical = controller.GetAxis("Right", "Vertical");

            transform.localScale += new Vector3(0, 0, 1.0F) * speed * moveVertical;

        }
    }
}

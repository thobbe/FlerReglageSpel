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
        Debug.Log(counter);
        if (controller.ButtonPressed("Button1"))
        {
            anim.Play("Robot Arm");
            if (counter < 150) {
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

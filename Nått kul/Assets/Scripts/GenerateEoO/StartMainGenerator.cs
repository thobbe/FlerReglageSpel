using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMainGenerator : MonoBehaviour {

    ControllerInput controller = new ControllerInput();
    public GameObject light_red;
    public GameObject light_green;
    public GameObject light_blue;
    public GameObject coreMotor1;
    public GameObject coreMotor2;
    public GameObject coreLight1;
    public GameObject coreLight2;
    public Material GlowRed;
    public Material GlowGreen;
    public Material GlowBlue;
    public Material GlowYellow;
    public Material noGlow;
    public int speed;
    private bool input1;
    private bool input2;
    private bool input3;




    void Start () {
        input1 = input2 = input3 = false;
	}


    void Update()
    {
        if (controller.ButtonPressed("Button4") && GameObject.Find("Inserted_Battery_Blue").GetComponent<Battery_insert>().insert)
        {
            if(!input1)
                light_red.GetComponent<Renderer>().material = GlowRed;
            if(!input2)
                light_green.GetComponent<Renderer>().material = GlowGreen;
            if(!input2)
                light_blue.GetComponent<Renderer>().material = GlowBlue;

            if (controller.ButtonPressed("Button1")) {
                input1 = true;
                light_red.GetComponent<Renderer>().material = GlowYellow;
            }

            if(controller.ButtonPressed("Button2") && input1)
            {
                input2 = true;
                light_green.GetComponent<Renderer>().material = GlowYellow;
            }
            else if ((controller.ButtonPressed("Button3")) && input1 && !input2)
            {
                input1 = false;
            } 

            if (controller.ButtonPressed("Button3") && input1)
            {
                input3 = true;
                light_blue.GetComponent<Renderer>().material = GlowYellow;
            }   
        }
        else
        {
            light_red.GetComponent<Renderer>().material = noGlow;
            light_green.GetComponent<Renderer>().material = noGlow;
            light_blue.GetComponent<Renderer>().material = noGlow;
            input1 = input2 = false;
        }

        if (input3)
        {
            coreLight1.GetComponent<Renderer>().material = GlowYellow;
            coreLight2.GetComponent<Renderer>().material = GlowYellow;
            coreMotor1.transform.Rotate(new Vector3(0, 0, 2) * speed * Time.deltaTime);
            coreMotor2.transform.Rotate(new Vector3(0, 0, -2) * speed * Time.deltaTime);
        }
    }
    
}

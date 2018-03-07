using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput {

    //TODO implement the buttons and joysticks

    //Constructor that initiate the controller
    public ControllerInput()
    {
        //TODO initiate the different buttons and joystick
    }

    //Get a smoth value between -1 and 1 that represent the direction. The function return both from keybord and from joysticks. 
    //There is two different joysticks "Left" and "Right" and values from the horizontal movement and vertical movement kan be found.
    //The Function is used like this:
    // private ControllerInput controller = new ControllerInput();
    // float horizontal = controller.GetAxis("Left", "Horizontal"); 
    public float GetAxis(string Joystick_name, string type)
    {
        if(Joystick_name == "Left")
        {
            if (type == "Horizontal")
            {
                return Input.GetAxis("Left_Horizontal");
            }else if (type == "Vertical")
            {
                return Input.GetAxis("Left_Vertical");
            }
        }else if (Joystick_name == "Right")
        {
            if (type == "Horizontal")
            {
                return Input.GetAxis("Right_Horizontal");
            }else if (type == "Vertical")
            {
                return Input.GetAxis("Right_Vertical");
            }
        }
        return 0.0f;
    }
    //ButtonPressed returns true if the specefic button has been pressed otherwise it return false.
    //There are four accepted arguments "Button1", "Button2", "Button3" and "Button4".
    //False is also return if the wrong argument is send in and a error messages is displayed in the console.
    //The function is used:
    // private ControllerInput controller = new ControllerInput();
    // bool pressed = controller.ButtonPressed("Button1"); 
    public bool ButtonPressed(string Button)
    {
        if(Button == "Button1")
        {
            if (Input.GetButton("Button1"))
            {
                return Input.GetButton("Button1");
            }
            else if (Input.GetKey(KeyCode.Keypad1))
            {
                return Input.GetKey(KeyCode.Keypad1);
            }

        }
        else if(Button == "Button2")
        {
            if (Input.GetButton("Button2"))
            {
                return Input.GetButton("Button2");
            }
            else if (Input.GetKey(KeyCode.Keypad2))
            {
                return Input.GetKey(KeyCode.Keypad2);
            }
        }
        else if(Button == "Button3")
        {
            if (Input.GetButton(Button))
            {
                return Input.GetButton(Button);
            }
            else if (Input.GetKey(KeyCode.Keypad3))
            {
                return Input.GetKey(KeyCode.Keypad3);
            }
        }
        else if(Button == "Button4")
        {
            if (Input.GetButton(Button))
            {
                return Input.GetButton(Button);
            }
            else if (Input.GetKey(KeyCode.Keypad4))
            {
                return Input.GetKey(KeyCode.Keypad4);
            }
        }
        else
        {
            Debug.Log("Error: Wrong input, check argument for function ControllerInput.ButtonPressed");
           
        }
        return false;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput {

    //TODO implement the buttons and joysticks

    //Constructor that initiziate the controller
    public ControllerInput()
    {
     
    }
    //Get a smoth value between -1 and 1 that represent where the joystick has been pulled
    public float GetAxis(string Joystick_name, string type)
    {
        //Left joystick or wasd on keybord
        if(Joystick_name == "Left")
        {
            if (type == "Horizontal")
            {
                return Input.GetAxis("Left_Vertical");
            }
            if (type == "Vertical")
            {
                return Input.GetAxis("Left_Vertical");
            }
        }
        //Right joystick or arrowpad on keybord
        if (Joystick_name == "Right")
        {
            if (type == "Horizontal")
            {
                return Input.GetAxis("Right_Vertical");
            }
            if (type == "Vertical")
            {
                return Input.GetAxis("Right_Vertical");
            }
        }
        return 0.0f;
    }
}

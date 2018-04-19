using UnityEngine;
using System.Collections;
using System.IO;        // for communication with arduino 
using System.IO.Ports;  // for communication with arduino 
using System;
using System.Linq;
using System.Collections.Generic;
public class Arduino : MonoBehaviour {
    /*****************************************************
    ********************Variable definitions**************
    * ****************************************************/
    //Initate a instance of Ardunio
    public static Arduino instance = null;
    //A serialport to the ardunio
    private SerialPort sp = new SerialPort("COM5", 9600); //(9600)  Opens a connection between Unity and a Serialport. 
    //Buttons and joysticks
    bool [] buttons = new bool[5] { false, false, false, false, false };
    bool [] buttons_light = new bool[5] { false, false, false, false, false };
    private int[] Joystick = new int[4] { 0, 0, 0, 0 };
    private int[] controllers = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    /*****************************************************
    ****************Functions implementation**************
    * ****************************************************/
    // Runs when one instance of this class is created. If more than one instance of this class
    // is created then it destroy the newest created instance.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            open();
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
   
    // Open a stream to the ardunio and set a timeout time.
    private void open()
    {
        sp.Open();
        sp.ReadTimeout = 5;
    }
    //Checks if a connection i avaible and then read all information from the arduino.
    private void get_data()
    {
        if (sp.IsOpen)
        {
            try
            {

                ArduinoDecrypter();
            }
            catch (System.TimeoutException)
            {
                Debug.Log("Timeout");
            }
        }
        else
        {
            open();
        }
    }
    //Reads information from the ardunio and then decrypts the information and puts the correct information into the right variables.
    public void ArduinoDecrypter()
    {
        string NewLine = sp.ReadLine();
        Debug.Log(NewLine);
        // Only reads the string if it is  characters long. It is because the information lost in transmission
        if (NewLine.Length == 15)
        {
            for (int i = 0; i < NewLine.Length - 1; i++)
            {
                //Makes chars into ints.
                controllers[i] = (int)(NewLine[i] - '0');
            }
            //Add the state into the buttons.
            for (int i = 0; i < 10; i = i + 2)
            {
                if (controllers[i] == 1)
                {
                    buttons[i / 2] = true;
                }
                else
                {
                    buttons[i / 2] = false;
                }
                if (controllers[i + 1] == 1)
                {
                    buttons_light[i / 2] = true;
                }
                else
                {
                    buttons_light[i / 2] = false;
                }
            }
            //Adds the joystick state into the joystick variable
            for (int i = 10; i < 14; i++)
            {
                if (controllers[i] == 2)
                {
                    Joystick[i - 10] = -1;
                }
                else
                {
                    Joystick[i - 10] = controllers[i];
                }
            }
        }
    }
    
    // Update is called once per frame and reupdate the data.
    void Update () {        
        get_data();
    }
    //When object is destroyed we close the stream to the arduino
    void OnDestroy()
    {
        sp.Close();
    }
    //Return if the button is pressed or not.
    public bool ButtonPressed(int nr)
    {
        return buttons[nr - 1];
    }
    //turn on or off the light of a button.
    public void LightButton(bool light,int nr)
    {
        if (light)
        {
            sp.Write("1");
        }
        else
        {
            sp.Write("0");
        }
    }
    //Returns the value of each axis.
    public int GetAxis(string axis)
    {
        if(axis == "Left_Horizontal")
        {
            return Joystick[0];
        }else if(axis == "Left_Vertical")
        {
            return Joystick[1];
        }
        else if(axis == "Right_Horizontal")
        {
            return Joystick[2];
        }else if(axis == "Right_Vertical")
        {
            return Joystick[3];
        }
        return 0;
    }
}

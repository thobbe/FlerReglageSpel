using UnityEngine;
using System.Collections;
using System.IO;        // for communication with arduino 
using System.IO.Ports;  // for communication with arduino 
using System;
using System.Linq;
using System.Collections.Generic;
public class Arduino : MonoBehaviour {
    //Used so no more instances of the class is created
    public static Arduino instance = null;
    private bool pressed = false; // contains  x- and z- valuesr from joystick (ps2)
    private SerialPort sp = new SerialPort("COM5", 9600); //(9600)  Opens a connection between Unity and a Serialport. 
    private int Value;
    int count = 0;
    int WholeCount = 0;
    

    //Knappar
    bool [] buttons = new bool[5] { false, false, false, false, false };
    bool [] buttons_light = new bool[5] { false, false, false, false, false };
    int[] controllers = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    //Checks so no more instances of this class is created
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
    // Open the stream to the arduino
    private void open()
    {
        sp.Open();
        sp.ReadTimeout = 1; // freeze if higher
    }
    //Update the data from the arduino
    private void get_data()
    {
        if (sp.IsOpen)
        {
            try
            {
                ArduinoDecrypter(); // takes the string with info from arduino and creates an array with w ints that can be used in unity.
            }
            catch (System.Exception)
            {
                Debug.Log("Can't read from Arduino");
            }
        }
    }

    public void ArduinoDecrypter()
    {
        string NewLine; 
        NewLine = sp.ReadLine(); // All data from the Arduino are putted in the string NewLine: [x' 'y].
        if (NewLine.Length == 15)
        {
            for (int i = 0; i < 14; i++)
            {
                controllers[i] = (int)(NewLine[i] - '0');
            }
            for (int i = 0; i < 14; i = i + 2)
            {
                if (controllers[i] == 1)
                {
                    buttons[i] = true;
                }
                else
                {
                    buttons[i] = false;
                }
                if (controllers[i + 1] == 1)
                {
                    buttons[i + 1] = true;
                }
                else
                {
                    buttons[i + 1] = false;
                }
            }
        }
        for (int i = 0; i < 14; i = i + 2)
        {
            Debug.Log(controllers[i]+ " ");
        }
    }
    
    // Update is called once per frame
    void LateUpdate () {
        get_data();
    }
    //When object is destroyed we close the stream to the arduino
    void OnDestroy()
    {
        sp.Close();
        print("Script was destroyed");
    }

    public bool ButtonPressed(int nr)
    {
        return buttons[nr - 1];
    }
    public void LightButton(int nr)
    {
        
    }
}

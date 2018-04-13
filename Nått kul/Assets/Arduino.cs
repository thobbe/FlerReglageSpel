using UnityEngine;
using System.Collections;
using System.IO;        // for communication with arduino 
using System.IO.Ports;  // for communication with arduino 
// don't know if all are used under this line.. 
using System;
using System.Linq;
using System.Collections.Generic;
public class Arduino : MonoBehaviour {

    public static Arduino instance = null;
    private bool pressed = false; // contains  x- and z- valuesr from joystick (ps2)
    private bool first = true;
    private SerialPort sp = new SerialPort("COM5", 9600); //(9600)  Opens a connection between Unity and a Serialport. 
    private int Value;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            open();

        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void open()
    {
        sp.Open();
        sp.ReadTimeout = 5; // freeze if higher
        first = false;
    }
    private void get_data()
    {
        if (sp.IsOpen)
        {
            try
            {
                // Value = sp.ReadByte(); // nothing works without it 
                //sp.ReadByte();
                
                pressed = ArduinoValueToUntiyValue(); // takes the string with info from arduino and creates an array with w ints that can be used in unity.

                // MoveObject(ref movement, ref coordinate);
            }
            catch (System.Exception)
            {

            }
        }
    }
    public bool ButtonPressed()
    {
        if (first)
        {
            open();
        }

        get_data();
        if (pressed)
        {
            return true;
        }
        else
        {
            return false;
        }
        //return pressed;
    }

    public bool ArduinoValueToUntiyValue()
    {
        //This function takes one string with values from the Arduino as argument and convert it to an array with int-values for x and z. 
        /* Example: 
     * private string Namn;
     * 
     * ArduinoValueToUnityValue(Namn);
     * 
     * print(xy_Value) ( prints: "[x,y]") 
     * 
    */
        string NewLine;
        NewLine  = sp.ReadLine(); // All data from the Arduino are putted in the string NewLine: [x' 'y].
        //Debug.Log(NewLine);
       // Debug.Log()
        //string b = NewLine
        string[] array = NewLine.Split(' '); // The string is divided at the  ' ' and transforms to an array with 2 slots. 
        //string xValue = array[0]; // x value (string value)
        //string yValue = array[1]; // y value (string value) 

        //int x_Value = Convert.ToInt32(xValue); // convert array value to int
        //int y_Value = Convert.ToInt32(yValue); // 


        //int[] xy_Value = new int[2]; //create an  int-array with x,y value ([x,y])
        //xy_Value[0] = x_Value;
        //xy_Value[1] = y_Value;
        int value = Convert.ToInt32(array[0]);
        //Debug.Log(value);
        if (value == 1)
        {
            //Debug.Log("True");
            return true;
        }
        else
        {
            //Debug.Log("False");
            return false;
        }
        // returns an array
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fueling_Counter_Real : MonoBehaviour
{
    ControllerInput controller = new ControllerInput();
    public int count;
    public string type;
    public GameObject test;
    private Color col;
    static bool HydrogenIn;
    static bool OxygenIn;
    Renderer rend;
    private Arm_Communication ArmCom;
    public Light warning;
    float delta = 0.0f;
    float start = 0.0f;
   

    // Use this for initialization
    void Start()
    {
        rend =test.GetComponent<Renderer>();
        SetCountText();
        HydrogenIn = false;
        OxygenIn = false;
        col = new Color(1, 1, 1);

}
    void OnTriggerStay(Collider other)
    {
        if (type == "Hydrogen" && other.gameObject.CompareTag("ArmHydrogen"))
        {
            Debug.Log("Hydrogen");
            if (Input.GetKey(KeyCode.Space) && OxygenIn)
            {
                HydrogenIn = true;
                count = count + 1;
            }
            else
                HydrogenIn = false;
            SetCountText();
        }


        if (type == "Oxygen" && other.gameObject.CompareTag("ArmOxygen"))
        {
            OxygenIn = true;
            if (Input.GetKey(KeyCode.Space) && HydrogenIn)
            {

                count = count + 1;
            }
            SetCountText();

        }
        else
            OxygenIn = false;
    }

    void SetCountText()
    {
        int percent = (count / 10);
        if (!(percent > 100))
        {
            //Fuel_level.value;
        }


    }

    private void Update()
    {
        if (controller.ButtonPressed("Button1")){
            count = count + 1;
            if (count == 100)
            {
                float start = Time.time;
                warning.intensity = 1;
            }

            if (count > 100)
            {
                delta = Time.time- start;
                //Debug.Log(delta);
                if (warning.intensity == 1 && delta >0.2f )
                {
                    start = Time.time;
                    warning.intensity = 0;
                }
                else if(warning.intensity == 0 && delta > 0.2f)
                {
                    start = Time.time;
                    warning.intensity = 1;
                }
            }
        }
        
       



        float number = (float)count / 100.0f;
          rend.material.color = new Color(1.0f-number, 1.0f, 1.0f-number);
    }
}

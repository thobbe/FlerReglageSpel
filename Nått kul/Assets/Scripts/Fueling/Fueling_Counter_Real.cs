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
        if (other.gameObject.CompareTag("Fueling_Cell"))
        {
            GameObject temp = other.gameObject;
            Arm_Controller playerScript = temp.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Arm_Controller>();
            if (controller.ButtonPressed("Button1") && playerScript.counter ==120)
            {
                
                count += 1;
            }
        }
    }

    void SetCountText()
    {

    }

    private void Update()
    {
           
            if (count == 100)
            {
                float start = Time.time;
                warning.intensity = 1;
            }

            /*if (count > 100)
            {
                delta = Time.time- start;
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
            }*/
        float number = (float)count / 100.0f;
        rend.material.color = new Color(1.0f-number, 1.0f, 1.0f-number);
    }


}

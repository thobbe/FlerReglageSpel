using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fueling_Counter : MonoBehaviour {

    public int count;
    public string type;

    public Text countText;
    static bool HydrogenIn;
    static bool OxygenIn;


    private Arm_Communication ArmCom;


    // Use this for initialization
    void Start () {
        count = count * 10;
        SetCountText();
        HydrogenIn = false;
        OxygenIn = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (type == "Hydrogen" && other.gameObject.CompareTag("ArmHydrogen"))
        {
           
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
            countText.text = percent.ToString() + "%";
        }


    }

}

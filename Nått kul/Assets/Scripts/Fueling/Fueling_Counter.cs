using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fueling_Counter : MonoBehaviour {

    public int count;
    public string type;

    public Text countText;

    public static bool OxygenIn;
    public static bool HydrogenIn;
    
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
            HydrogenIn = true;
            if (Input.GetKey(KeyCode.Space) && OxygenIn)
            {
                count = count + 1;

            }
            SetCountText();
            Debug.Log(OxygenIn);
        }
        else
        {
            HydrogenIn = false;
        }


        if (type == "Oxygen" && other.gameObject.CompareTag("ArmOxygen"))
        {
            OxygenIn = true;    
            if (Input.GetKey(KeyCode.Space) && HydrogenIn)
            {
                count = count + 1;
            }           
            SetCountText();
            //Debug.Log(HydrogenIn);
        }
        else
        {
            OxygenIn = false;
        }

        
      
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

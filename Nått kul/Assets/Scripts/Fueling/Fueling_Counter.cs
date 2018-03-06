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
    
    // Use this for initialization
    void Start () {
        count = count * 10;
        SetCountText();

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
        }
        else
            HydrogenIn = false;
     
        if (type == "Oxygen" && other.gameObject.CompareTag("ArmOxygen"))
        {

            if (Input.GetKey(KeyCode.Space))
            {
                OxygenIn = true;
                count = count + 1;
            }
            else
                OxygenIn = false;

            SetCountText();
            
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

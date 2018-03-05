using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fueling_Counter : MonoBehaviour {

    public int count;
    public string type;

    public Text countText;
    
    // Use this for initialization
    void Start () {
        count = count * 10;
        SetCountText();
    }
    void OnTriggerStay(Collider other)
    {
        if (type == "Oxygen")
        { 
            if (other.gameObject.CompareTag("ArmOxygen"))
            {

                if (Input.GetKey(KeyCode.Space))
                {
                    count = count + 1;
                }

                SetCountText();
            }
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

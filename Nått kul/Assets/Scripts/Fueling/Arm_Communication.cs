using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Communication : MonoBehaviour {

    bool Oxygen;
    bool Hydrogen;
    int OT, OM, OB, HT, HM, HB;

    void Start () {
        Oxygen = false;
        Hydrogen = false;
        OT= OM= OB=HT= HM= HB =0;
    }
	
    public void SetBool(string Type, bool Value)
    {
        if(Type == "Oxygen")
        {
            Oxygen = Value;
        }else if(Type == "Hydrogen")
        {
            Hydrogen = Value;
        }
    }

    public bool Ready()
    {
        if(Oxygen && Hydrogen)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
	// Update is called once per frame
	void Update ()
    {	
	}
}

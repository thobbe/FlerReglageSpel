using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Controller : MonoBehaviour {
    public float speed;
    public string type;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (type == "Oxygen")
        {
            float moveVertical = Input.GetAxis("Right_Vertical");

            transform.localScale += new Vector3(0, 0, 1.0F) * speed * moveVertical;
        }
        else
        {
            float moveVertical = Input.GetAxis("Left_Vertical");

            transform.localScale += new Vector3(0, 0, 1.0F) * speed * moveVertical;

        }
    }
}

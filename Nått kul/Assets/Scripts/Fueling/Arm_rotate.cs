using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_rotate : MonoBehaviour {
    public float speed;
    public string type;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(type == "Oxygen")
        {
            float moveHorizontal = Input.GetAxis("Right_Horizontal");
            transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * speed * moveHorizontal);
        }else
        {
            float moveHorizontal = Input.GetAxis("Left_Horizontal");
            transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * speed * moveHorizontal);

        }
       
    }
}

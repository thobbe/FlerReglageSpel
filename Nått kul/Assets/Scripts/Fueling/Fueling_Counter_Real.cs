using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fueling_Counter_Real : MonoBehaviour
{
    //Controller object
    ControllerInput controller = new ControllerInput();
    
    //Variables for amount fuel
	public int Start_amount;
	private int count;
	private int max_amount = 1000;
    public string type;
    public GameObject test;
	public ParticleSystem fluid;
    //private Color col;
    public Arm_Communication check;
    public Light warning;
    float delta = 0.0f;
    float start = 0.0f;
	public GameObject fuel;
	private float Fluidmin = 0;
	private float Fluidmax = 6.25f;
    // Use this for initialization
    void Start()
    {
        //Stop particle system and set fuel amount
        count = Start_amount;
        fluid.Stop();
		fuel.transform.localScale += new Vector3 (0, (Fluidmax - Fluidmin)*count / max_amount, 0);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fueling_Cell"))
        {
            Arm_Controller playerScript = other.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Arm_Controller>();
            if (check.Ready() && controller.ButtonPressed("Button1") && playerScript.counter == 120 ) {
				if (count != max_amount) {
					fluid.Play ();
					count += 1;
					//fuel.transform.localScale += new Vector3 (0, (Fluidmax - Fluidmin) / max_amount, 0);
				} 
			} else {
				fluid.Stop();
           
			}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fueling_Cell"))
        {
            Arm_Controller Script = other.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Arm_Controller>();
            check.SetBool(Script.type, true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.CompareTag("Fueling_Cell"))
        {
            Arm_Controller Script = other.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Arm_Controller>();
            check.SetBool(Script.type, false);
        }
    }
    private void Update()
    {
		if (count == max_amount)
        {
            float start = Time.time;
            warning.intensity = 1;
        }
    }
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



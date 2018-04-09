using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fueling_Counter_Real : MonoBehaviour
{
    ControllerInput controller = new ControllerInput();
    //Variable 
	public int Start_amount;
	private int count;
	private int max_amount = 1000;

    public string type;
    public GameObject test;
	public ParticleSystem fluid;
    //private Color col;
    static bool HydrogenIn;
    static bool OxygenIn;
    Renderer rend;
    private Arm_Communication ArmCom;
    public Light warning;
    float delta = 0.0f;
    float start = 0.0f;
	public GameObject fuel;
	private float Fluidmin = 0;
	private float Fluidmax = 6.25f;
    // Use this for initialization
    void Start()
    {
        rend =test.GetComponent<Renderer>();
		count = Start_amount;
        HydrogenIn = false;
        OxygenIn = false;
		fluid.Stop();
		fuel.transform.localScale += new Vector3 (0, (Fluidmax - Fluidmin)*count / max_amount, 0);

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fueling_Cell"))
        {
			Debug.Log ("Fueling cell");
            GameObject temp = other.gameObject;
            Arm_Controller playerScript = temp.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Arm_Controller>();
			if (controller.ButtonPressed ("Button1") && playerScript.counter == 120) {
				if (count != max_amount) {
					fluid.Play ();
					count += 1;
					fuel.transform.localScale += new Vector3 (0, (Fluidmax - Fluidmin) / max_amount, 0);
				} 
			} else {
				fluid.Stop();
			}
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
/*float number = (float)count / 100.0f;
rend.material.color = new Color(1.0f-number, 1.0f, 1.0f-number);*/


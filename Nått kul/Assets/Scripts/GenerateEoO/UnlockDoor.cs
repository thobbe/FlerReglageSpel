using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour {
    ControllerInput controller = new ControllerInput();
    public bool nearby;
    public GameObject door1;
    public GameObject door2;
    public GameObject cableRed;
    public GameObject cableGreen;
    public GameObject numpadRed;
    public GameObject numpadGreen;
    private Vector3 startMarker1;
    private Vector3 endMarker1;
    private Vector3 startMarker2;
    private Vector3 endMarker2;
    public float distance = 10;
    public float speed = 1.0F;
    public bool UnlockRed;
    public bool UnlockGreen;
    public Material GlowRed;
    public Material GlowGreen;
    public Material TurnOffRed;
    public Material TurnOffGreen;
    private float startTime;
    private float endTime;
    private float perc;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nearby = false;
        }
    }

    void Open()
    {
        if (startTime < endTime)
            startTime += Time.deltaTime;

        perc = startTime / endTime;
        door1.transform.position = Vector3.Lerp(startMarker1, endMarker1, perc);
        door2.transform.position = Vector3.Lerp(startMarker2, endMarker2, perc);
    }

    void Start () {
        startTime = 0;
        endTime = 5;
        nearby = false;

        startMarker1 = door1.transform.position;
        endMarker1 = door1.transform.position + Vector3.up * distance;
        startMarker2 = door2.transform.position;
        endMarker2 = door2.transform.position + Vector3.down * distance;
    }
	
	void Update () {
		if (controller.ButtonPressed("Button2") && GameObject.Find("Inserted_Battery_Red").GetComponent<Battery_insert>().insert)
        {
            cableRed.GetComponent<Renderer>().material = GlowRed;

            if (nearby && controller.ButtonPressed("Button1"))
            {
                UnlockRed = true;
            }

        }
		else if (controller.ButtonPressed("Button3") && GameObject.Find("Inserted_Battery_Green").GetComponent<Battery_insert>().insert)
        {
            cableGreen.GetComponent<Renderer>().material = GlowGreen;

            if (nearby && controller.ButtonPressed("Button1"))
            {
                UnlockGreen = true;
            }
        }
        else
        {
            cableGreen.GetComponent<Renderer>().material = TurnOffGreen;
            cableRed.GetComponent<Renderer>().material = TurnOffRed;
        }

        
        if (UnlockRed && UnlockGreen)
        {
            Open();
        }      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour {
    ControllerInput controller = new ControllerInput();
    public bool nearby;
    public GameObject door;
    public GameObject cableRed;
    public GameObject cableGreen;
    public GameObject numpadRed;
    public GameObject numpadGreen;
    public Vector3 startMarker;
    public Vector3 endMarker;
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
            Debug.Log("nära röd");
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
        door.transform.position = Vector3.Lerp(startMarker, endMarker, perc);
    }

    void Start () {
        startTime = 0;
        endTime = 5;
        nearby = false;

        startMarker = door.transform.position;
        endMarker = door.transform.position + Vector3.up * distance;
    }
	
	void Update () {
        if (controller.ButtonPressed("Button2"))
        {
            cableRed.GetComponent<Renderer>().material = GlowRed;

            if (nearby && controller.ButtonPressed("Button1"))
            {
                UnlockRed = true;
            }

        }
        else if (controller.ButtonPressed("Button3"))
        {
            cableGreen.GetComponent<Renderer>().material = GlowGreen;

            if (controller.ButtonPressed("Button1"))
            {
                UnlockGreen = true;
            }
        }
        else
        {
            cableGreen.GetComponent<Renderer>().material = TurnOffGreen;
            cableRed.GetComponent<Renderer>().material = TurnOffRed;
        }

        Debug.Log(nearby);
        if (UnlockRed && UnlockGreen)
        {
            Open();
        }      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    public bool open;
    public GameObject door;
    public Vector3 startMarker;
    public Vector3 endMarker;
    public float distance;
    public float speed = 1.0F;
    private float startTime;
    private float endTime;



    // Use this for initialization
    void Start () {
        open = false;
        startTime = 0;
        endTime = 5;

        startMarker = door.transform.position;
        endMarker = door.transform.position + Vector3.up * distance;
        
    }
	
	void Update () {
        if (open)
        {
            if(startTime < endTime)
                startTime += Time.deltaTime;

            float perc = startTime / endTime;


            door.transform.position = Vector3.Lerp(startMarker, endMarker, perc);
        }
	}
}

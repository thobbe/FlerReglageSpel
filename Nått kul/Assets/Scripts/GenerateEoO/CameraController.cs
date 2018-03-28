using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		//decide distance between camera and player transform
		offset = transform.position - player.transform.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//move camera to align with the player object
		transform.position = player.transform.position + offset;
		
	}
}

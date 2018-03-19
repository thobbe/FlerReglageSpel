using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityChange_space_malin : MonoBehaviour {

	private float g;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (!Input.GetKey ("space")) 
		{
			g = 9.82f;
		} 
		else 
		{
			g = -9.82f;
		}

		Physics.gravity = new Vector3 (0, g, 0);

	}
}


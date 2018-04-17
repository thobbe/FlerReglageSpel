using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* ***************************************************
 * 
 * 			  Får "mission" att röra sig 
 * 
 * 
 * **************************************************/

public class Rotator_movement_malin : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}

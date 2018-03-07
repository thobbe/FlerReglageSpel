using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helper_malin : MonoBehaviour {
	
	//changes the speed of the movement
	private float speed;

	//get the original position of the object
	private Vector3 pos;

	//adjust this to change how long the distance the object is moving. 
	private float dis;


	void Start() {

		speed = 3f;

		pos = transform.position;

		dis = 0.2f;
	}


	void Update() {
		
		//calculate what the new Y position will be
		float newY = Mathf.Sin(Time.time * speed) * dis;

		//set the object's Y to the new calculated Y
		transform.position = new Vector3(pos.x, newY + pos.y, pos.z);
	}
}

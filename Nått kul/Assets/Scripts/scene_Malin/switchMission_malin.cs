using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchMission_malin : MonoBehaviour {

	public GameObject mission1;
	public GameObject mission2;
	public GameObject mission3;
	public GameObject mission4;

	public GameObject pickup1;
	public GameObject pickup2;
	public GameObject pickup3;
	public GameObject pickup4;

	public Text winner;

//	private bool carried1;
//	private bool carried2;
//	private bool carried3;
//	private bool carried4;

	private bool carried;

	private Vector3 firstpos1;
	private Vector3 firstpos2;
	private Vector3 firstpos3;
	private Vector3 firstpos4;

	private int toggler;

	private bool col_mis_pick;


	// Use this for initialization
	void Start () 
	{
		// Get the initial posistions of the pick-ups
		firstpos1 = pickup1.transform.position; 
		firstpos2 = pickup2.transform.position;
		firstpos3 = pickup3.transform.position;
		firstpos4 = pickup4.transform.position;

		// Start with showing the first mission
		mission1.SetActive (true);
		mission2.SetActive (false);
		mission3.SetActive (false);
		mission4.SetActive (false);

		pickup1.SetActive (true);
		pickup2.SetActive (false);
		pickup3.SetActive (false);
		pickup4.SetActive (false);

		carried = GameObject.Find ("pick-up1").GetComponent<PickUpObject_malin> ().beingCarried;

		// Start by setting the toggler to 1. This shows that the first mission is showing.
		toggler = 1;

		// Make the completed mission text empty. 
		winner.text = "";

		col_mis_pick = false;

	}




	// Update is called once per frame
	void Update () 
	{

		// Mission and pick-up is colliding, the D-key is pressed and the pick-up is not being carried switch mission.
		if (col_mis_pick && Input.GetKeyDown(KeyCode.D) && !carried) 
		{

			// toggle which pick-up is visible using layers. 
			if (toggler == 1) {

				// show the 2nd pick-up
				mission1.SetActive (false);
				mission2.SetActive (true);
				mission3.SetActive (false);
				mission4.SetActive (false);



				// reset the position and rotation of the pick-up
				pickup1.transform.position = firstpos1;
				pickup1.transform.rotation = Quaternion.identity;

				pickup2.transform.position = firstpos2;
				pickup2.transform.rotation = Quaternion.identity;

				pickup3.transform.position = firstpos3;
				pickup3.transform.rotation = Quaternion.identity;

				pickup4.transform.position = firstpos4;
				pickup4.transform.rotation = Quaternion.identity;

				pickup1.SetActive (false);
				pickup2.SetActive (true);
				pickup3.SetActive (false);
				pickup4.SetActive (false);

				carried = GameObject.Find ("pick-up2").GetComponent<PickUpObject_malin> ().beingCarried;

				toggler = 2;
			} else if (toggler == 2) {

				// show the 3rd pick-up
				mission1.SetActive (false);
				mission2.SetActive (false);
				mission3.SetActive (true);
				mission4.SetActive (false);



				// reset the position and rotation of the pick-up
				pickup1.transform.position = firstpos1;
				pickup1.transform.rotation = Quaternion.identity;

				pickup2.transform.position = firstpos2;
				pickup2.transform.rotation = Quaternion.identity;

				pickup3.transform.position = firstpos3;
				pickup3.transform.rotation = Quaternion.identity;

				pickup4.transform.position = firstpos4;
				pickup4.transform.rotation = Quaternion.identity;

				pickup1.SetActive (false);
				pickup2.SetActive (false);
				pickup3.SetActive (true);
				pickup4.SetActive (false);

				carried = GameObject.Find ("pick-up3").GetComponent<PickUpObject_malin> ().beingCarried;

				toggler = 3;
			} else if (toggler == 3) {

				// show the 4th pick-up
				mission1.SetActive (false);
				mission2.SetActive (false);
				mission3.SetActive (false);
				mission4.SetActive (true);



				// reset the position and rotation of the pick-up
				pickup1.transform.position = firstpos1;
				pickup1.transform.rotation = Quaternion.identity;

				pickup2.transform.position = firstpos2;
				pickup2.transform.rotation = Quaternion.identity;

				pickup3.transform.position = firstpos3;
				pickup3.transform.rotation = Quaternion.identity;

				pickup4.transform.position = firstpos4;
				pickup4.transform.rotation = Quaternion.identity;

				pickup1.SetActive (false);
				pickup2.SetActive (false);
				pickup3.SetActive (false);
				pickup4.SetActive (true);

				carried = GameObject.Find ("pick-up4").GetComponent<PickUpObject_malin> ().beingCarried;

				toggler = 0;
			} else {
				// disable all the missions and pick-ups
				mission1.SetActive (false);
				mission2.SetActive (false);
				mission3.SetActive (false);
				mission4.SetActive (false);


				pickup1.SetActive (false);
				pickup2.SetActive (false);
				pickup3.SetActive (false);
				pickup4.SetActive (false);


				// Display mission completed
				winner.text = "Banan avklarad!";
			} 
		}
	}


	// other är antagligen player eller pick-up. medans gameobject är mission. 
	void OnTriggerEnter(Collider other) 
	{
		// Om man "krockar" pick-up med ett mission
		if(other.gameObject.CompareTag("Pick-up") ) 
		{
			col_mis_pick = true;
		}
	}



	void OnTriggerExit(Collider other)	// när man inte längre krockar med en pick-up
	{
		if (other.gameObject.CompareTag("Pick-up"))
		{
			col_mis_pick = false;
		}
	}

}
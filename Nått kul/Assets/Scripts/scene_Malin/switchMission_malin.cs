using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchMission_malin : MonoBehaviour {

	private int toggler;

	public GameObject pickup1;
	public GameObject pickup2;
	public GameObject pickup3;
	public GameObject pickup4;

	//public GameObject player;

	public Text winner;

	// Use this for initialization
	void Start () {

		toggler = 1;

		winner.text = "";

		// Start with showing the first pick-up object
		pickup1.SetActive (true);
		pickup2.SetActive (false);
		pickup3.SetActive (false);
		pickup4.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter() 
	{
		// toggle which pick-up is visible using layers. 
		if (toggler == 1) 
		{
			// show the 2nd pick-up
			pickup1.SetActive (false);
			pickup2.SetActive (true);
			pickup3.SetActive (false);
			pickup4.SetActive (false);
			toggler = 0;
		} 
		else if (toggler == 2) 
		{
			// show the 3rd pick-up
			pickup1.SetActive (false);
			pickup2.SetActive (false);
			pickup3.SetActive (true);
			pickup4.SetActive (false);
			toggler = 3;
		} 
		else if (toggler == 3) 
		{
			// show the 4th pick-up
			pickup1.SetActive (false);
			pickup2.SetActive (false);
			pickup3.SetActive (false);
			pickup4.SetActive (true);
			toggler = 0;
		} 
		else
		{
			// disabel all the pick-up
			pickup1.SetActive (false);
			pickup2.SetActive (false);
			pickup3.SetActive (false);
			pickup4.SetActive (false);

			// Display that indikate mission completed
			winner.text = "Banad avklarad!";
		} 
	}
}
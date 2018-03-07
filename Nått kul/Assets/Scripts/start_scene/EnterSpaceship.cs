using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnterSpaceship: MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene("scene_Erik");
		}
	}
}

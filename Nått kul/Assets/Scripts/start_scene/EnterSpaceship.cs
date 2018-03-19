using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnterSpaceship: MonoBehaviour
{
    public string sceneName;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
        {
            Initiate.Fade(sceneName, Color.black, 2.0f);
        }
    }

}

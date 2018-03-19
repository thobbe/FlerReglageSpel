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
            StartCoroutine(Pause());
        }
    }

    IEnumerator Pause()
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene(sceneName);
    }

}

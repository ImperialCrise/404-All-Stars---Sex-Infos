using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextTest : MonoBehaviour
{
	public void Start()
	{
		DontDestroyOnLoad(gameObject);
	}

	public bool isClicked = false;
	
	public void OnClickOnButton()
	{
		if (isClicked)
			return;

		isClicked = true;
		SceneManager.LoadScene(1);
	}
}

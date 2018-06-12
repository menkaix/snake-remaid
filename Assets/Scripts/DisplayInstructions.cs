using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInstructions : MonoBehaviour {

	bool wasActive = false;

	public GameObject instructions;
	public AudioSource music;

	// Use this for initialization
	void Start () {

		instructions.gameObject.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.getInstance().gameIsOver && !wasActive)
		{
			music.Play();
			instructions.SetActive(true);
			wasActive = true;

		}else if(!GameManager.getInstance().gameIsOver)
		{
			music.Stop();
			instructions.SetActive(false);
			wasActive = false;
		}
		
	}

}

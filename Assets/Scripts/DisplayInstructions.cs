using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInstructions : MonoBehaviour {

	bool wasActive = false;
	private GameManager manager;

	public GameObject instructions;
	public AudioSource music;

	// Use this for initialization
	void Start () {

		instructions.gameObject.SetActive(false);
		manager = GameManager.getInstance();


	}
	
	// Update is called once per frame
	void Update () {

		if (manager.gameIsOver && !wasActive)
		{
			music.Play();
			instructions.SetActive(true);
			wasActive = true;

		}else if(!manager.gameIsOver)
		{
			music.Stop();
			instructions.SetActive(false);
			wasActive = false;
		}
		
	}

}

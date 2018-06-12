using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.getInstance().gameIsOver)
		{
			if (Input.anyKeyDown)
			{
				GameManager.getInstance().init();
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) && GameManager.getInstance().snake.currentDirection != Snake.DIRECTION_DOWN)
			{
				GameManager.getInstance().steerSound();
				GameManager.getInstance().snake.currentDirection = Snake.DIRECTION_UP;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow) && GameManager.getInstance().snake.currentDirection != Snake.DIRECTION_UP)
			{
				GameManager.getInstance().steerSound();
				GameManager.getInstance().snake.currentDirection = Snake.DIRECTION_DOWN;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow) && GameManager.getInstance().snake.currentDirection != Snake.DIRECTION_RIGHT)
			{
				GameManager.getInstance().steerSound();
				GameManager.getInstance().snake.currentDirection = Snake.DIRECTION_LEFT;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow) && GameManager.getInstance().snake.currentDirection != Snake.DIRECTION_LEFT)
			{
				GameManager.getInstance().steerSound();
				GameManager.getInstance().snake.currentDirection = Snake.DIRECTION_RIGHT;
			}
		}

		

	}
}

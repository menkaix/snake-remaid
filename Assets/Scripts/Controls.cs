using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	GameManager manager;


	// Use this for initialization
	void Start () {
		manager = GameManager.getInstance();
	}
	
	// Update is called once per frame
	void Update () {

		if (manager.gameIsOver)
		{
			if (Input.anyKeyDown)
			{
				manager.init();
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) && manager.snake.currentDirection != Snake.DIRECTION_DOWN)
			{
				manager.steerSound();
				manager.snake.currentDirection = Snake.DIRECTION_UP;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow) && manager.snake.currentDirection != Snake.DIRECTION_UP)
			{
				GameManager.getInstance().steerSound();
				GameManager.getInstance().snake.currentDirection = Snake.DIRECTION_DOWN;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow) && manager.snake.currentDirection != Snake.DIRECTION_RIGHT)
			{
				manager.steerSound();
				manager.snake.currentDirection = Snake.DIRECTION_LEFT;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow) && manager.snake.currentDirection != Snake.DIRECTION_LEFT)
			{
				manager.steerSound();
				manager.snake.currentDirection = Snake.DIRECTION_RIGHT;
			}
		}
		
	}
}

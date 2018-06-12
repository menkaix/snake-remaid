using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Position
{
	public int col;
	public int row;
	

	public Position(int v1, int v2) : this()
	{
		this.col = v1;
		this.row = v2;
	}
}

public class Snake {

	public const int DIRECTION_UP = 1 ;
	public const int DIRECTION_DOWN = 2;
	public const int DIRECTION_LEFT = 3;
	public const int DIRECTION_RIGHT = 4;

	public List<Position> body = new List<Position>();

	public int currentDirection = 0;
	public int length = 4 ;
	


	public void tick()
	{
		Position lastHead = body[body.Count-1];
		Position newHead = lastHead;

		switch (currentDirection)
		{
			case DIRECTION_UP:
				newHead.row += 1; 
				break;
			case DIRECTION_DOWN:
				newHead.row -= 1;
				break;
			case DIRECTION_LEFT:
				newHead.col -= 1;
				break;
			case DIRECTION_RIGHT:
				newHead.col += 1;
				break;
			default:
				die();
				break;
		}

		if (
			newHead.row < 0 ||
			newHead.col < 0 ||
			newHead.row >= GameManager.ROWS ||
			newHead.col >= GameManager.COLS ||
			GameManager.getInstance().map[newHead.col, newHead.row] == GameManager.CELL_SNAKE ||
			GameManager.getInstance().map[newHead.col, newHead.row] == GameManager.CELL_BOMB
			)
		{
			die();
		}
		else
		{
			if (GameManager.getInstance().map[newHead.col, newHead.row] == GameManager.CELL_FOOD)
			{
				GameManager.getInstance().score();
			}

			body.Add(newHead);

			GameManager.getInstance().map[newHead.col, newHead.row] = 1;

			if (body.Count > length)
			{
				Position end = body[0];
				body.RemoveAt(0);

				GameManager.getInstance().map[end.col, end.row] = 0 ;

			}
		}
	}

	public void die()
	{
		Debug.Log("Bye bye cruel world !");
		GameManager.getInstance().deadSource.PlayOneShot(GameManager.getInstance().deadSound);
		GameManager.getInstance().gameIsOver = true;
	}

	public Snake(int col, int row)
	{
		currentDirection = DIRECTION_LEFT;
		body.Add(new Position(col, row));
		GameManager.getInstance().map[col, row] = 1;


	}

	

}

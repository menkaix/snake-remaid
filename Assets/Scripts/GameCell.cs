using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : MonoBehaviour {

	public int lastValue = 0;
	public int value = 0;

	GameObject snake;
	GameObject food;
	GameObject bomb;

	public int col;
	public int row;

	// Use this for initialization
	void Start () {
		snake = Instantiate(GameManager.getInstance().snakePiece);
		snake.transform.parent = GameManager.getInstance().positions[col, row].transform;
		snake.transform.localPosition = Vector3.zero;
		snake.SetActive(false);

		food = Instantiate(GameManager.getInstance().food);
		food.transform.parent = GameManager.getInstance().positions[col, row].transform;
		food.transform.localPosition = Vector3.zero;
		food.SetActive(false);

		bomb = Instantiate(GameManager.getInstance().bomb);
		bomb.transform.parent = GameManager.getInstance().positions[col, row].transform;
		bomb.transform.localPosition = Vector3.zero;
		bomb.SetActive(false);
	}
	
	public void tick()
	{
		StartCoroutine(exe());
	}

	private IEnumerator exe()
	{
		yield return null;

		int childCount = transform.childCount;

		for (int i = 0; i < childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(false);

		}

		switch (value)
		{
			case 1:
				snake.SetActive(true);
				break;
			case 2:
				food.SetActive(true);

				break;
			case 3:
				bomb.SetActive(true);

				break;
			default:

				break;
		}
		
		lastValue = value ;

	}
}

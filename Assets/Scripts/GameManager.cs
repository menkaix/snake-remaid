using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public const int CELL_EMPTY = 0;
	public const int CELL_SNAKE = 1;
	public const int CELL_FOOD = 2;
	public const int CELL_BOMB = 4;

	public const int COLS = 64;
	public const int ROWS = 56;

	private int scoreValue = 0;
	private float lastTick;
	private int best;




	public bool gameIsOver = true;
	public Snake snake;

	public int[,] map = new int[COLS, ROWS];
	public GameObject[,] positions = new GameObject[COLS, ROWS];
	public GameCell[,] cells = new GameCell[COLS, ROWS];
	
	public float gridSize = 1.5f;

	public float period = 0.46875f;

	public GameObject snakePiece;
	public GameObject food;	
	public GameObject bomb;

	public Text scoreText;

	public AudioClip tickSound ;
	public AudioClip pointSound;
	public AudioClip deadSound;

	public AudioSource snakeSource;
	public AudioSource scoreSource;
	public AudioSource deadSource;


	// Use this for initialization
	void Start () {

		lastTick = Time.time;

		for(int c=0; c<COLS; c++)
		{
			for(int r=0; r< ROWS; r++)
			{
				GameObject go = new GameObject();
				go.name = "cell_" + c + "_" + r;
				GameCell cell = go.AddComponent<GameCell>();
				cell.col = c;
				cell.row = r;

				cells[c, r] = cell;

				Vector3 newPos = Vector3.zero;
				newPos.z = r * gridSize;
				newPos.x = c * gridSize;

				go.transform.position = newPos;

				positions[c, r] = go;

			}
		}


	}

	// Update is called once per frame
	void Update()
	{

		float now = Time.time;

		if ((now - lastTick > period) && !gameIsOver)
		{
			tick();

			lastTick = now;
		}
	}

	private void tick()
	{
		for (int c = 0; c < COLS; c++)
		{
			for (int r = 0; r < ROWS; r++)
			{
				GameCell cell = cells[c, r];
				
				cell.value = map[c, r]; ;
				if(cell.value != cell.lastValue)
				{
					cell.tick();
				}				
			}
		}

		snake.tick();
	}

	public void init()
	{
		if (PlayerPrefs.HasKey("best"))
		{
			best = PlayerPrefs.GetInt("best");
		}
		else
		{
			best = 0;
		}
		
		for (int c = 0; c < COLS; c++)
		{
			for (int r = 0; r < ROWS; r++)
			{
				map[c, r] = GameManager.CELL_EMPTY;
			}
		}

		scoreValue = -7;
		snake = new Snake(32, 28);
		gameIsOver = false;
		score();
	}
	public void steerSound()
	{
		snakeSource.PlayOneShot(tickSound);

	}
	public void score()
	{
		scoreSource.PlayOneShot(pointSound);

		scoreValue += 7;

		if (scoreValue > best)
		{
			best = scoreValue;
			PlayerPrefs.SetInt("best", best);
		}


		snake.length++ ;


		scoreText.text = "Score : "+scoreValue+"    Best : "+best;

		int c = Random.Range(0, COLS);
		int r = Random.Range(0, ROWS);

		while(map[c,r] != 0)
		{
			c = Random.Range(0, COLS);
			r = Random.Range(0, ROWS);
		}

		map[c, r] = CELL_FOOD ;



	}



	//============= Singleton ============================

	private static GameManager instance;

	public static GameManager getInstance()
	{
		if (instance == null)
		{
			GameObject go = new GameObject();
			go.name = "GameManager";

			instance = go.AddComponent<GameManager>();
		}


		return instance;
	}

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;

		}else if(instance != this)
		{
			Destroy(gameObject);
		}
	}

}

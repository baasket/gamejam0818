using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    EnemyManager enemyManager;
    private InterfaceManager interfaceManager;
    private FruitsManager fruitsManager;
    private bool gameIsOver;
    [Range(0.0f, 20.0f)]
    public float timeToMainMenu = 5.0f;

    private int currentLevel;
    private float remainingTimeCurrentLevel;
    private int scoreToNextLevel;

    public float firstSpawnDelay = 5.0f;
    public float ravenWavePeriod = 10.0f;
    private float timeSinceLastSpawn;
    public int ravenCountBase = 3;
    public int ravenAugmentationCycle = 1;
    public int cycleDuration = 3;
    private int waveCounter = 0;


	// Use this for initialization
	void Start ()
    {
        enemyManager = GetComponent<EnemyManager>();
        fruitsManager = GetComponent<FruitsManager>();
        interfaceManager = GetComponent<InterfaceManager>();
        gameIsOver = false;

        currentLevel = 1;
        remainingTimeCurrentLevel = 30.0f;
        scoreToNextLevel = 5;

        timeSinceLastSpawn = ravenWavePeriod-firstSpawnDelay;
    }
	
	// Update is called once per frame
	void Update () {
		if(gameIsOver)
        {
            timeToMainMenu -= Time.deltaTime;

            if(timeToMainMenu < 0.0f)
            {
                SceneManager.LoadScene("menuScene");
            }
        }
        else
        {
            timerManagement();
            ravenManagement();
        }

        if(scoreToNextLevel == 105 && fruitsManager.getFruitCount() == 100)
        {
            interfaceManager.displayGameOver("Victoire");
            gameIsOver = true;
        }
	}

    public void gameOver()
    {
        interfaceManager.displayGameOver("Game Over");
        gameIsOver = true;
    }

    private void goToNextLevel()
    {
        currentLevel++;
        remainingTimeCurrentLevel = 30.0f;
        scoreToNextLevel+=5;
    }

    private void ravenManagement()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn > ravenWavePeriod)
        {
            timeSinceLastSpawn = 0.0f;
            int waveSize = ravenCountBase + 
                (waveCounter * ravenAugmentationCycle / cycleDuration);

            enemyManager.spawnWave(waveSize);
            waveCounter++;
        }
    }

    private void timerManagement()
    {
        remainingTimeCurrentLevel -= Time.deltaTime;

        if(remainingTimeCurrentLevel < 0)
        {
            if(fruitsManager.getFruitCount() < scoreToNextLevel)
            {
                gameOver();
            }
            else
            {
                goToNextLevel();
            }
        }

        interfaceManager.setTimer(remainingTimeCurrentLevel, 
            scoreToNextLevel);
    }

    #region Active Capacities

    public void activ_branchSlap()
    {
        Debug.Log("Branch slap");
    }

    public void activ_fruitFall()
    {
        Debug.Log("Fruit fall");
    }

    public void activ_predator()
    {
        Debug.Log("Predator");
    }

    #endregion
}

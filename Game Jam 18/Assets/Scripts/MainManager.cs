using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    private InterfaceManager interfaceManager;
    private bool gameIsOver;
    [Range(0.0f, 20.0f)]
    public float timeToMainMenu = 5.0f;

	// Use this for initialization
	void Start ()
    {
        interfaceManager = GetComponent<InterfaceManager>();
        gameIsOver = false;
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
	}

    public void gameOver()
    {
        interfaceManager.displayGameOver();
        gameIsOver = true;
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

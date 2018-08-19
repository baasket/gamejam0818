using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsManager : MonoBehaviour
{
    public List<GameObject> fruitsObjects = new List<GameObject>();

    public int initialFruits = 1;
    public int maxFruits = 100;

    private InterfaceManager interfaceManager;
    private MainManager mainManager;

    private Roots roots;
    private Foliage foliage;

    private int fruitsCount;

    public int sunCost;
    public int waterCost;

    public AudioSource audioSourceAdd;
    public AudioSource audioSourceRemove;

    // Use this for initialization
    void Start ()
    {
        foliage = GetComponent<Foliage>();
        mainManager = GetComponent<MainManager>();
        interfaceManager = GetComponent<InterfaceManager>();
        roots = GetComponent<Roots>();

        fruitsCount = initialFruits;

        updateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addFruit()
    {
        if(isResourceAvaible())
        {
            if(fruitsCount < maxFruits)
            {
                fruitsCount++;
                foliage.spendSun(sunCost);
                roots.spendWater(waterCost);
                audioSourceAdd.Play();
            }
        }

        updateDisplay();
    }

    private void gameOver()
    {
        mainManager.gameOver();
    }

    public int getFruitCount()
    {
        return fruitsCount;
    }

    private bool isResourceAvaible()
    {
        if(roots.getWater() >= waterCost)
        {
            if(foliage.getSun() >= sunCost)
            {
                return true;
            }
        }

        return false;
    }

    public void loseFruit()
    {
        fruitsCount--;
        updateDisplay();
        audioSourceRemove.Play();
        if(fruitsCount <= 0)
        {
            gameOver();
        }
    }

    private void updateDisplay()
    {
        interfaceManager.updateFruitsDisplay(fruitsCount);
    }
}

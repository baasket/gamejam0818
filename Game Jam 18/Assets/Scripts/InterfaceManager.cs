using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public Text fruitsDisplay;
    public Text sunDisplay;
    public Text waterDisplay;
    public Text timer;

    public string timerMsg_part_001 = "";
    public string timerMsg_part_002 = "";
    public string timerMsg_part_003 = "";

    public GameObject gameOverDisplay;

    public GameObject upgradeMenu;

    void Start()
    {
        gameOverDisplay.SetActive(false);
    }

    public void displayGameOver()
    {
        gameOverDisplay.SetActive(true);
    }

    public void setTimer(float time, int score)
    {
        int seconds = (int)time;

        string msg = timerMsg_part_001 + score.ToString() + timerMsg_part_002
            + seconds.ToString() + timerMsg_part_003;

        timer.text = msg;
    }

    public void showTimer(bool val=true)
    {
        timer.gameObject.SetActive(val);
    }

    public void toggleUpgradeMenu()
    {
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
    }

    public void updateFruitsDisplay(int val)
    {
        if(val >= 0)
        {
            fruitsDisplay.text = val.ToString();
        }
        else
        {
            fruitsDisplay.text = "0";
        }
    }

    public void updateSunDisplay(int val)
    {
        if (val >= 0)
        {
            sunDisplay.text = val.ToString();
        }
        else
        {
            sunDisplay.text = "0";
        }
    }

    public void updateWaterDisplay(int val)
    {
        if (val >= 0)
        {
            waterDisplay.text = val.ToString();
        }
        else
        {
            waterDisplay.text = "0";
        }
    }

}

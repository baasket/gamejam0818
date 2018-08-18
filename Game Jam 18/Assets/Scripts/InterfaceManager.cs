using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public Text fruitsDisplay;
    public Text sunDisplay;
    public Text waterDisplay;

    public GameObject upgradeMenu;

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
	
    public void toggleUpgradeMenu()
    {
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
    }

}

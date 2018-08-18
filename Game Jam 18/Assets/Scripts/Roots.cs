using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    private InterfaceManager interfaceManager;
    private int waterLevel = 0;

    public float basePeriod = 1.0f;
    public float baseRate = 10;

    private float waterPeriod = 1.0f;
    private float timeSinceLastWater = 0.0f;

    
    private int depth;
    private int retention;

    // Use this for initialization
    void Start ()
    {
        waterLevel = 0;
        timeSinceLastWater = 0.0f;

        depth = 0;
        retention = 0;
        interfaceManager = GetComponent<InterfaceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastWater += Time.deltaTime;

        if (timeSinceLastWater > waterPeriod)
        {
            waterLevel++;
            interfaceManager.updateWaterDisplay(waterLevel);
            timeSinceLastWater = 0.0f;
        }
    }

    private void computeWaterPeriod()
    {
        waterPeriod = basePeriod * baseRate / (baseRate + (float)(depth*retention));
    }

    public int getWater()
    {
        return waterLevel;
    }

    public void spendWater(int val)
    {
        waterLevel-= val;
        if (waterLevel < 0)
        {
            waterLevel = 0;
        }

        interfaceManager.updateWaterDisplay(waterLevel);
    }

    public void upgradeRootsDepth()
    {
        depth++;
        computeWaterPeriod();
    }

    public void upgradeRootsRetention()
    {
        retention++;
        computeWaterPeriod();
    }
}

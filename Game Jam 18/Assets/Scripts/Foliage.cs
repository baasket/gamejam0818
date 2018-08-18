using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foliage : MonoBehaviour
{
    private InterfaceManager interfaceManager;
    private int sunLevel = 0;

    public float sunPeriod = 1.0f;
    private float timeSinceLastSun = 0.0f;

    // Use this for initialization
    void Start()
    {
        sunLevel = 0;
        timeSinceLastSun = 0.0f;
        interfaceManager = GetComponent<InterfaceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSun += Time.deltaTime;

        if (timeSinceLastSun > sunPeriod)
        {
            sunLevel++;
            interfaceManager.updateSunDisplay(sunLevel);
            timeSinceLastSun = 0.0f;
        }
    }

    public int getSun()
    {
        return sunLevel;
    }

    public void spendSun(int val)
    {
        sunLevel -= val;
        if (sunLevel < 0)
        {
            sunLevel = 0;
        }

        interfaceManager.updateSunDisplay(sunLevel);
    }
}

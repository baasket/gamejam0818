using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    PrefabBank prefabBank;
    public GameObject spawningPoint;
    [Range(0.0f, 100.0f)]
    public float vectorVar = 1.0f;

    private List<Raven> ravens = new List<Raven>();

    public float firstRavenDelay = 10.0f;
    public float ravenSpawnPeriod = 1.0f;
    private float timeSinceLastRaven;

	// Use this for initialization
	void Start ()
    {
        prefabBank = GetComponent<PrefabBank>();
        timeSinceLastRaven = -firstRavenDelay;
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*
        timeSinceLastRaven += Time.deltaTime;

		if(timeSinceLastRaven > ravenSpawnPeriod)
        {
            spawnRaven();
            timeSinceLastRaven = 0.0f;
            computeRavenSpawnPeriod();
        }
        */
	}

    public void spawnWave(int ravenCount)
    {
        for(int i = 0; i < ravenCount; i++)
        {
            spawnRaven();
        }
    }

    private void computeRavenSpawnPeriod()
    {

    }

    public void spawnRaven()
    {
        Vector3 pos = spawningPoint.transform.position;
        pos += spawningPoint.transform.right * Random.Range(-vectorVar, vectorVar);

        pos += spawningPoint.transform.up * Random.Range(0.0f, vectorVar/5.0f);

        Raven newRaven = prefabBank.poolRaven();

        newRaven.gameObject.transform.position = pos;
        ravens.Add(newRaven);
        newRaven.init();
    }

    public void removeRaven(Raven val)
    {
        ravens.Remove(val);
    }

    public Enemy getAnyEnemy()
    {
        return getAnyRaven();
    }

    public Raven getAnyRaven()
    {
        int len = ravens.Count;

        if(ravens.Count == 0)
        {
            return null;
        }
        else
        {
            return ravens[0];
        }
    }
}

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

    public float ravenSpawnPeriod = 1.0f;
    private float timeSinceLastRaven;

	// Use this for initialization
	void Start ()
    {
        prefabBank = GetComponent<PrefabBank>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastRaven += Time.deltaTime;

		if(timeSinceLastRaven > ravenSpawnPeriod)
        {
            spawnRaven();
            timeSinceLastRaven = 0.0f;
            computeRavenSpawnPeriod();
        }
	}

    private void computeRavenSpawnPeriod()
    {

    }

    public void spawnRaven()
    {
        Vector3 pos = spawningPoint.transform.position;
        pos += spawningPoint.transform.right * Random.Range(-vectorVar, vectorVar);

        pos += new Vector3(Random.Range(-vectorVar, vectorVar),
            Random.Range(-vectorVar, vectorVar),
            Random.Range(-vectorVar, vectorVar));

        Raven newRaven = prefabBank.poolRaven();

        newRaven.gameObject.transform.position = pos;
        ravens.Add(newRaven);
        newRaven.init();
    }

    public void removeRaven(Raven val)
    {
        ravens.Remove(val);
    }

    public Raven getAnyRaven()
    {
        int len = ravens.Count;

        if(len == 0)
        {
            return null;
        }
        else
        {
            return ravens[Random.Range(0, len)];
        }
    }
}

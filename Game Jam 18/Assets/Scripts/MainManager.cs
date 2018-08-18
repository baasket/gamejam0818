using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

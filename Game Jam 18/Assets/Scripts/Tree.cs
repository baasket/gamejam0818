using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public List<GameObject> foliageObjects = new List<GameObject>();

    public InterfaceManager interfaceManager;
    // Use this for initialization

    

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Vector3 getAnyFoliage()
    {
        int len = foliageObjects.Count;

        if(len == 0)
        {
            return Vector3.zero;
        }
        else
        {
            return foliageObjects[Random.Range(0, len)].transform.position;
        }
    }
}

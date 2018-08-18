using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    public List<GameObject> spawningObjects = new List<GameObject>();
    public List<Vector3> spawningVectors = new List<Vector3>();
    public List<bool> slots = new List<bool>();

    public int avaibleSlots = 10;

    private PrefabBank prefabBank;
    private Roots roots;
    private Foliage foliage;

	// Use this for initialization
	void Start ()
    {
        prefabBank = GetComponent<PrefabBank>();
        roots = GetComponent<Roots>();
        foliage = GetComponent<Foliage>();

        int len = spawningObjects.Count;

        for (int i = 0; i < len; i++)
        {
            spawningVectors.Add(spawningObjects[i].transform.position);
            slots.Add(true);
            spawningObjects[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool isSpawnPossible(int val)
    {
        int len = avaibleSlots;

        if(val < 0 || val > 3)
        {
            return false;
        }
        if (roots.getWater() < prefabBank.waterCosts[val-1])
        {
            return false;
        }
        if(foliage.getSun() < prefabBank.sunCosts[val-1])
        {
            return false;
        }
        for (int i = 0; i < len; i++)
        {
            if(slots[i])
            {
                return true;
            }
        }

        return true;
    }

    public void spawnScareCrow(int val)
    {
        if(isSpawnPossible(val))
        {
            Scarecrow newSC = prefabBank.poolScarecrow(val);

            int posIdx = findSCPosition();

            newSC.gameObject.transform.position = spawningVectors[posIdx];
            slots[posIdx] = false;
            newSC.setSlot(posIdx);

            roots.spendWater(prefabBank.waterCosts[val - 1]);
            foliage.spendSun(prefabBank.sunCosts[val - 1]);

            newSC.init();
        }
    }

    private int findSCPosition()
    {
        int len = slots.Count;
        for (int i = 0; i < len; i++)
        {
            if(slots[i])
            {
                return i;
            }
        }

        return -1;
    }

    public void freeSlot(int val)
    {
        slots[val] = true;
    }
}

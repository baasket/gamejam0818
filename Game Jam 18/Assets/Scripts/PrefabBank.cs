using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBank : MonoBehaviour
{
    private EnemyManager enemyManager;
    private FruitsManager fruitManager;
    private SpawningManager spawningManager;

    public Tree tree;

    public GameObject scarecrow_001_prefab;
    public GameObject scarecrow_002_prefab;
    public GameObject scarecrow_003_prefab;

    public GameObject raven_prefab;

    public GameObject bullet_prefab;

    public int[] waterCosts;
    public int[] sunCosts;

    private Stack<Scarecrow> sc_pool_001 = new Stack<Scarecrow>();
    private Stack<Scarecrow> sc_pool_002 = new Stack<Scarecrow>();
    private Stack<Scarecrow> sc_pool_003 = new Stack<Scarecrow>();

    private Stack<Raven> ravenPool = new Stack<Raven>();
    private Stack<Bullet> bulletPool = new Stack<Bullet>();

    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        fruitManager = GetComponent<FruitsManager>();
        spawningManager = GetComponent<SpawningManager>();
    }

    #region Bullets
    public Bullet poolBullet(string ammoName)
    {
        if(bulletPool.Count == 0)
        {
            GameObject newObject = Instantiate(bullet_prefab);
            Bullet newBullet = newObject.GetComponent<Bullet>();
            newBullet.setPrefabBank(this);
            return newBullet;
        }
        else
        {
            Bullet newBullet = bulletPool.Pop();
            newBullet.gameObject.SetActive(true);
            return newBullet;
        }
    }

    public void takeOutBullet(Bullet val, string ammoType)
    {
        bulletPool.Push(val);
        val.gameObject.SetActive(false);
    }

    #endregion

    #region Raven
    public Raven poolRaven()
    {
        if(ravenPool.Count == 0)
        {
            GameObject newObject = Instantiate(raven_prefab);
            Raven newRaven = newObject.GetComponent<Raven>();
            newRaven.setPrefabBank(this);
            newRaven.setEnemyManager(enemyManager);
            newRaven.setFruitManager(fruitManager);
            newRaven.setTree(tree);
            newRaven.gameObject.SetActive(true);
            return newRaven;
        }
        else
        {
            Raven newRaven = ravenPool.Pop();
            newRaven.gameObject.SetActive(true);
            return newRaven;
        }
    }

    public void takeOutRaven(Raven val)
    {
        ravenPool.Push(val);
        val.gameObject.SetActive(false);
    }
    
    #endregion

    #region Scarecrow
    public Scarecrow poolScarecrow(int SC_type)
    {
        if (SC_type == 2)
        {
            if(sc_pool_002.Count == 0)
            {
                GameObject newObject = Instantiate(scarecrow_002_prefab);
                Scarecrow newSC = newObject.GetComponent<Scarecrow>();
                newSC.setPrefabBank(this);
                newSC.setEnemyManager(enemyManager);
                newSC.setSpawningManager(spawningManager);
                return newSC;
            }
            else
            {
                Scarecrow newSC = sc_pool_002.Pop();
                return newSC;
            }
        }
        else if (SC_type == 3)
        {
            if (sc_pool_003.Count == 0)
            {
                GameObject newObject = Instantiate(scarecrow_003_prefab);
                Scarecrow newSC = newObject.GetComponent<Scarecrow>();
                newSC.setPrefabBank(this);
                newSC.setEnemyManager(enemyManager);
                newSC.setSpawningManager(spawningManager);
                return newSC;
            }
            else
            {
                Scarecrow newSC = sc_pool_003.Pop();
                return newSC;
            }
        }
        else
        {
            if (sc_pool_001.Count == 0)
            {
                GameObject newObject = Instantiate(scarecrow_001_prefab);
                Scarecrow newSC = newObject.GetComponent<Scarecrow>();
                newSC.setPrefabBank(this);
                newSC.setEnemyManager(enemyManager);
                newSC.setSpawningManager(spawningManager);
                return newSC;
            }
            else
            {
                Scarecrow newSC = sc_pool_001.Pop();
                return newSC;
            }
        }
    }

    public void takeOutScarecrow(Scarecrow val, int SC_type)
    {
        if(SC_type == 1)
        {
            sc_pool_001.Push(val);
        }
        else if(SC_type == 2)
        {
            sc_pool_002.Push(val);
        }
        else if(SC_type == 3)
        {
            sc_pool_003.Push(val);
        }

        val.gameObject.SetActive(false);
    }

    #endregion

    int getSunCost(int val)
    {
        if(val > 0 && val < sunCosts.Length)
        {
            return sunCosts[val];
        }

        return -1;
    }

    int getWaterCost(int val)
    {
        if (val > 0 && val < waterCosts.Length)
        {
            return waterCosts[val];
        }

        return -1;
    }
    
	
}

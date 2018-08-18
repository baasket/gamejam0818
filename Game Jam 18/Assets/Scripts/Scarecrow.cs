using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    public bool alive;
    public float lifespan;
    private float timeSinceSpawn;
    private int slot;

    public float attackPeriod;
    public bool canTargetFlying;
    public bool canTargetWalking;

    private float timeSinceLastAttack;

    public int SC_type;
    public string ammoName;

    private PrefabBank prefabBank;
    private EnemyManager enemyManager;
    private SpawningManager spawningManager;
	
	// Update is called once per frame
	void Update ()
    {
		if(alive)
        {
            timeSinceLastAttack += Time.deltaTime;
            timeSinceSpawn += Time.deltaTime;

            if(timeSinceLastAttack > attackPeriod)
            {
                attack();
            }
            else if(timeSinceSpawn > lifespan)
            {
                die();
            }
        }
	}

    public void init()
    {
        timeSinceLastAttack = 0.0f;
        timeSinceSpawn = 0.0f;

        alive = true;
        gameObject.SetActive(true);
    }

    private void attack()
    {
        timeSinceLastAttack = 0.0f;
    }

    private void die()
    {
        alive = false;
        spawningManager.freeSlot(slot);
        prefabBank.takeOutScarecrow(this, SC_type);
    }

    public void setEnemyManager(EnemyManager val)
    {
        enemyManager = val;
    }

    public void setPrefabBank(PrefabBank val)
    {
        prefabBank = val;
    }

    public void setSlot(int val)
    {
        slot = val;
    }

    public void setSpawningManager(SpawningManager val)
    {
        spawningManager = val;
    }

}

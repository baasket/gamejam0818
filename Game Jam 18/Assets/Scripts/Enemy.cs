using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected bool active;


    public float maxHealth = 10.0f;
    public float currentHealth;

    protected PrefabBank prefabBank;
    protected Tree tree;
    protected EnemyManager enemyManager;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void setEnemyManager(EnemyManager val)
    {
        enemyManager = val;
    }

    public void setTree(Tree val)
    {
        tree = val;
    }

    public void setPrefabBank(PrefabBank val)
    {
        prefabBank = val;
    }

    public void takeDammage(float val)
    {
        currentHealth -= val;

        if(currentHealth <= 0.0f)
        {
            die();
        }
    }

    public virtual void die()
    {

    }
}

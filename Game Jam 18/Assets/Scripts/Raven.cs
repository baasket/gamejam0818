using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raven : Enemy
{

    private Vector3 destination;
    [Range(0.0f, 1.0f)]
    public float flightSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Slerp(transform.position, destination, Time.deltaTime*flightSpeed);
        transform.LookAt(destination);
    }

    public void init()
    {
        active = true;

        currentHealth = maxHealth;

        destination = tree.getAnyFoliage();
        transform.LookAt(destination);
    }

    public override void die()
    {
        active = false;
        prefabBank.takeOutRaven(this);
        enemyManager.removeRaven(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raven : Enemy
{

    private Vector3 destination;
    [Range(0.0f, 1.0f)]
    public float flightSpeed = 1.0f;

    [Range(0.0f, 5.0f)]
    public float slowFlightDistance;
    [Range(0.0f, 5.0f)]
    public float eatingDistance;
    [Range(0.0f, 5.0f)]
    public float eatingPeriod;

    private bool slowFlight;
    private bool eating;
    private float eatingTime;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Slerp(transform.position, destination, 
            Time.deltaTime*flightSpeed);
        transform.LookAt(destination);

        if(!slowFlight && !eating)
        {
            float distance = Vector3.Distance(transform.position, destination);

            if (distance < slowFlightDistance)
            {
                slowFlight = true;
            }
        }
        else if(slowFlight && !eating)
        {
            float distance = Vector3.Distance(transform.position, destination);

            if(distance < eatingDistance)
            {
                eating = true;
                slowFlight = false;
                Debug.Log("Start eating");
            }
        }
        else if(eating)
        {
            eatingTime += Time.deltaTime;

            if(eatingTime > eatingPeriod)
            {
                eatFruit();
            }
        }
    }

    public void init()
    {
        active = true;

        currentHealth = maxHealth;

        destination = tree.getAnyFoliage();
        transform.LookAt(destination);

        slowFlight = false;
        eating = false;

        eatingTime = 0.0f;

        if(slowFlightDistance < eatingDistance)
        {
            slowFlightDistance = eatingDistance;
        }
    }

    private void eatFruit()
    {
        eatingTime = 0.0f;
        fruitManager.loseFruit();
    }

    public override void die()
    {
        active = false;
        prefabBank.takeOutRaven(this);
        enemyManager.removeRaven(this);
    }
}

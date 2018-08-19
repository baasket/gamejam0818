using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raven : Enemy
{

    private Vector3 destination;
    private Vector3 lookAtDestination;
    [Range(0.0f, 1.0f)]
    public float flightSpeed = 1.0f;

    [Range(0.0f, 5.0f)]
    public float slowFlightDistance;
    [Range(0.0f, 5.0f)]
    public float eatingDistance;
    [Range(0.0f, 5.0f)]
    public float eatingPeriod;
    [Range(0.0f, 5.0f)]
    public float heightCorrection;

    private bool slowFlight;
    private bool eating;
    private float eatingTime;

    public Animator animator;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        
        

        if (!slowFlight && !eating) // normal flight
        {
            transform.position = Vector3.Lerp(transform.position, lookAtDestination,
            Time.deltaTime * flightSpeed);

            float distance = Vector3.Distance(transform.position, lookAtDestination);

            if (distance < slowFlightDistance)
            {
                slowFlight = true;
                //animator.Play("rapidFlighAnimation");
                
                animator.SetBool("rapidAnimation", true);
            }
        }
        else if(slowFlight && !eating) // final approach
        {
            transform.position = Vector3.Lerp(transform.position, destination,
            Time.deltaTime * flightSpeed);

            float distance = Vector3.Distance(transform.position, destination);

            if(distance < eatingDistance)
            {
                eating = true;
                slowFlight = false;
                animator.SetBool("rapidAnimation", false);
            }
        }
        else if(eating) // eating
        {
            eatingTime += Time.deltaTime;

            if(eatingTime > eatingPeriod)
            {
                eatFruit();
            }
        }

        transform.LookAt(lookAtDestination);
    }

    public void init()
    {
        active = true;
        animator.SetBool("rapidAnimation", false);

        currentHealth = maxHealth;

        destination = tree.getAnyFoliage();
        lookAtDestination = destination + Vector3.up * heightCorrection;
        transform.LookAt(lookAtDestination);

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

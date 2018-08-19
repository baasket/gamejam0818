using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    AudioSource audioSource;
    public string ammoType;
    public float speed;
    public float damage;
    public string impactName;


    private Vector3 trajectory;
    private Enemy enemy;
    private float flightTime;
    private float finishTime;
    private bool flying = false;

    private PrefabBank prefabBank;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(flying)
        {
            flightTime += Time.deltaTime;
            if(flightTime > finishTime)
            {
                hit();
            }
            else
            {
                transform.position += trajectory * speed * Time.deltaTime;
            }
        }
    }

    public void flyTo(Vector3 origin, Enemy target)
    {

        audioSource = GetComponent<AudioSource>();
        

        flying = true;
        enemy = target;
        Vector3 targetPos = target.getTarget();
        transform.position = origin;
        transform.LookAt(targetPos);
        trajectory = targetPos - origin;
        finishTime = trajectory.magnitude / speed;
        trajectory.Normalize();
        flightTime = 0.0f;

        audioSource.Play();
    }

    private void hit()
    {
        flying = false;

        if (enemy.gameObject.activeSelf)
        {
            enemy.takeDammage(damage);
        }

        prefabBank.takeOutBullet(this, ammoType);
    }

    public void setPrefabBank(PrefabBank val)
    {
        prefabBank = val;
    }
}

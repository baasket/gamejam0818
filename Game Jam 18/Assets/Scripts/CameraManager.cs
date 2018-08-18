using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject tree;

    [Range(0.0f, 20.0f)]
    public float distance = 10.0f;
    [Range(0.0f, 10.0f)]
    public float yConstant = 5.0f;
    [Range(0.0f, 2.0f)]
    public float rotationSpeed = 0.5f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = transform.position;

        pos += rotationSpeed * Time.deltaTime * transform.right;

        if(Vector3.Distance(tree.transform.position, pos) > 1.1f*distance)
        {
            pos += rotationSpeed * Time.deltaTime * transform.forward;
        }
        else if (Vector3.Distance(tree.transform.position, pos) < 0.9f * distance)
        {
            pos += rotationSpeed * Time.deltaTime * transform.forward * -1.0f;
        }

        pos.y = yConstant;
        transform.position = pos;
        transform.LookAt(tree.transform.position);
	}
}

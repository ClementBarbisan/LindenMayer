using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidObstacle : MonoBehaviour {
	public GameObject target;
	public Vector3 position;
	// Use this for initialization
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag ("Player");
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance (target.transform.position, transform.position) < 0.75f) 
		{
			transform.position += new Vector3 (Mathf.Clamp(1f / (transform.position.x - target.transform.position.x), -0.75f, 0.75f), Mathf.Clamp(1f / (transform.position.y - target.transform.position.y), -0.75f, 0.75f), Mathf.Clamp(1f / (transform.position.z - target.transform.position.z), -0.75f, 0.75f)) * Time.deltaTime;
		}
		else
			transform.position += (position - transform.position) * Time.deltaTime;
	}
}

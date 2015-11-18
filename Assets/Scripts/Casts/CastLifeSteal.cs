using UnityEngine;
using System.Collections;

public class CastLifeSteal : Cast {
	
	public GameObject explosion;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(Destroy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{

	}
}

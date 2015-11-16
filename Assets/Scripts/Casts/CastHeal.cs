using UnityEngine;
using System.Collections;

public class CastHeal : Cast {
	
	private Rigidbody rb;
	
	public GameObject explosion;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		StartCoroutine(Destroy());
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<Player>().hp += damage;

		}
	}
}

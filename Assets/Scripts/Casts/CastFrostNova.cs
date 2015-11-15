using UnityEngine;
using System.Collections;

public class CastFrostNova : Cast {
	
	private AudioSource ausou;
	
	// Use this for initialization
	void Start () {
		ausou = GetComponent<AudioSource>();
		Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy")
			other.gameObject.GetComponent<Enemy>().hp -= damage;
	}
}

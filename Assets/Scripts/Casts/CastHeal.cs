using UnityEngine;
using System.Collections;

public class CastHeal : Cast {
	
	private Rigidbody rb;
	private Light light;
	
	public GameObject explosion;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		light = GetComponent<Light> ();
		StartCoroutine(Destroy());
		StartCoroutine (fadeOut ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.GetComponent<Player>().hp += damage;
			if (other.GetComponent<Player>().hp > other.GetComponent<Player>().hp_max)
				other.GetComponent<Player>().hp = other.GetComponent<Player>().hp_max;
		}
	}
	IEnumerator fadeOut()
	{
		yield return new WaitForSeconds (destroyTime - 2.0f);
		while (light.intensity > 0)
		{
			light.intensity -= 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
	}
}

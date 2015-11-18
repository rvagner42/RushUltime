using UnityEngine;
using System.Collections;

public class CastHeal : Cast {
	
	private Light li;
	
	public GameObject explosion;
	
	// Use this for initialization
	void Start () {
		li = GetComponent<Light> ();
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
		while (li.intensity > 0)
		{
			li.intensity -= 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
	}
}

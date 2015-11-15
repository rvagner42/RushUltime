using UnityEngine;
using System.Collections;

public class CastFirePillar : Cast {

	private AudioSource ausou;

	// Use this for initialization
	void Start () {
		ausou = GetComponent<AudioSource>();
		Destroy(gameObject, destroyTime + 2);
		StartCoroutine(fireTime());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy")
			other.gameObject.GetComponent<Enemy>().hp -= damage;
	}

	IEnumerator fireTime()
	{
		yield return new WaitForSeconds(destroyTime);
		GetComponent<ParticleSystem>().Stop();
		transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
		StartCoroutine(fadeOut());
	}

	IEnumerator fadeOut()
	{
		for (int i = 9; i >= 0; i--)
		{
			ausou.volume = i * 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
	}
}

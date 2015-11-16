using UnityEngine;
using System.Collections;

public class CastFirePillar : Cast {

	private AudioSource ausou;
	private float lastTime;

	// Use this for initialization
	void Start () {
		ausou = GetComponent<AudioSource>();
		Destroy(gameObject, destroyTime + 2);
		StartCoroutine(fireTime());
		lastTime = -0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		if (Time.time > lastTime + 0.5f)
			lastTime = Time.time;
	}

	IEnumerator OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy" && Time.time == lastTime)
			other.gameObject.GetComponent<Enemy>().hp -= damage;
		yield return new WaitForFixedUpdate();
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

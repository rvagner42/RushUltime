using UnityEngine;
using System.Collections;

public class CastFrostNova : Cast {
	
	private AudioSource ausou;
	private float lastTime;
	
	// Use this for initialization
	void Start () {
		ausou = GetComponent<AudioSource>();
		Destroy(gameObject, destroyTime);
		StartCoroutine (disableParticles ());
		lastTime = -0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		var rotation = Quaternion.LookRotation(Vector3.up , Vector3.forward);
		transform.rotation = rotation;
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

	IEnumerator disableParticles()
	{
		yield return new WaitForSeconds (destroyTime - 0.5f);
		GetComponent<ParticleSystem> ().Stop ();
	}
}

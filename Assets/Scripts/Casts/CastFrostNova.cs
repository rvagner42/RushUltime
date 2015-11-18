using UnityEngine;
using System.Collections;

public class CastFrostNova : Cast {
	
	private float lastTime;
	private Light li;

	
	// Use this for initialization
	void Start () {
		li = GetComponent<Light> ();
		Destroy(gameObject, destroyTime);
		StartCoroutine (disableParticles ());
		StartCoroutine (fadeOut ());
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

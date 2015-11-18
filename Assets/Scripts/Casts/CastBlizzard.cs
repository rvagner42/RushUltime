using UnityEngine;
using System.Collections;

public class CastBlizzard : Cast {

	private Light li;
	private float init;

	public CastIceBlast iceBolt;

	// Use this for initialization
	void Start ()
	{
		li = GetComponent<Light> ();
		Destroy(gameObject, destroyTime + 2f);
		init = Time.time;
		StartCoroutine(spawner ());
		StartCoroutine (fadeOut ());
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	IEnumerator spawner()
	{
		while (Time.time < init + destroyTime)
		{
			Vector3 position = new Vector3(transform.position.x + Random.Range(-4, 4), transform.position.y, transform.position.z + Random.Range(-4, 4));
			CastIceBlast tmp = Instantiate(iceBolt, position, Quaternion.Euler(90, 0, 0)) as CastIceBlast;
			tmp.damage = damage;
			yield return new WaitForSeconds(0.06f);
		}
	}

	IEnumerator fadeOut()
	{
		yield return new WaitForSeconds (destroyTime);
		while (li.intensity > 0)
		{
			li.intensity -= 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
	}
}

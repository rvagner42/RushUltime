using UnityEngine;
using System.Collections;

public class CastBlizzard : Cast {

	public CastIceBlast iceBolt;

	// Use this for initialization
	void Start ()
	{
		Destroy(gameObject, destroyTime);
		StartCoroutine(spawner ());
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	IEnumerator spawner()
	{
		for (;;)
		{
			Vector3 position = new Vector3(transform.position.x + Random.Range(-4, 4), transform.position.y, transform.position.z + Random.Range(-4, 4));
			CastIceBlast tmp = Instantiate(iceBolt, position, Quaternion.Euler(90, 0, 0)) as CastIceBlast;
			tmp.damage = damage;
			yield return new WaitForSeconds(0.07f);
		}
	}
}

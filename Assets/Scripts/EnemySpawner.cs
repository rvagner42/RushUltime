using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public Enemy		male;
	public Enemy		female;

	private bool		is_dead = true;

	private Enemy		current;

	void Start ()
	{
		current = null;
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn()
	{
		for (;;)
		{
			if (is_dead == true)
			{
				current = GameObject.Instantiate((Random.Range(0, 2) == 0 ? male : female), transform.position, Quaternion.identity) as Enemy;
				current.Died += HasDied;
				is_dead = false;
			}
			yield return new WaitForSeconds (Random.Range(4.0f, 6.0f));
		}
	}

	void HasDied()
	{
		is_dead = true;
	}
}

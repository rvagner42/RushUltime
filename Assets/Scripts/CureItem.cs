using UnityEngine;
using System.Collections;

public class CureItem : MonoBehaviour
{
	// Values between 0 and 1
	public float		health_bonus;
	//public float		mana_bonus;

	private float		init_time;

	void Start ()
	{
		init_time = Time.time;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player" && Time.time > init_time + 1.0f)
		{
			Player player = collider.GetComponent<Player> ();
			player.hp += Mathf.RoundToInt(player.hp_max * health_bonus);
			if (player.hp > player.hp_max)
				player.hp = player.hp_max;
			Destroy (gameObject);
		}
	}
}

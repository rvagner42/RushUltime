using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private Vector3 offset;
	private Player player;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		offset = player.transform.position - transform.position;
	}
	
	void Update ()
	{
		transform.position = player.transform.position - offset;

	}
}

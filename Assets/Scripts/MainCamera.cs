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
		RaycastHit hit;
		if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit) && hit.transform.tag == "Wall")
		{
			Color test = new Color();
			test = hit.transform.gameObject.GetComponent<Renderer> ().material.color;
			test.a = 0.2f;
			hit.transform.gameObject.GetComponent<Renderer> ().material.color = test;
			//gameObject.GetComponent<Renderer>().material.color.a = 1.0; // fully opaque
			Debug.Log(hit.transform.gameObject.GetComponent<Renderer> ().material.color.a);
		}
	}
}

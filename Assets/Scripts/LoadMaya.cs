using UnityEngine;
using System.Collections;

public class LoadMaya : MonoBehaviour {

	public string map;
	public Vector3 position;

	private Player player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		player.GetComponent<NavMeshAgent> ().enabled = false;
		Application.LoadLevel (map);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public string map;
	public int warpId;
	//public Vector3 position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player" && collider.gameObject.GetComponent<Player>().warped == false)
		{
			collider.gameObject.GetComponent<NavMeshAgent>().enabled = false;
			collider.gameObject.GetComponent<Player>().warpId = warpId;
			collider.gameObject.GetComponent<Player>().warped = true;
			Application.LoadLevel (map);
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Player")
			collider.gameObject.GetComponent<Player>().warped = false;
	}
}

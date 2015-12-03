using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public string map;
	public int warpId;
	private Transform loading;
	// Use this for initialization
	void Start () {
		loading = GameObject.FindGameObjectWithTag ("Loading").transform;
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
			loading.gameObject.SetActive(true);
			Application.LoadLevel (map);
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "Player")
			collider.gameObject.GetComponent<Player>().warped = false;
	}
}

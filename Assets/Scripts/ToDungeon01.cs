using UnityEngine;
using System.Collections;

public class ToDungeon01 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			collider.gameObject.GetComponent<NavMeshAgent>().destination = transform.position;
			Application.LoadLevel ("Dungeon01");
			collider.gameObject.transform.position = new Vector3 (0f, 0f, 0f);
		}
	}
}

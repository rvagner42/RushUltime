using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarpPosition : MonoBehaviour {

	private Player player;

	public List<Warp> warps;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		if (player.warpId >= 0)
		{
			Vector3 position = warps [player.warpId].transform.position;
			//position.y += 0.1f;
			player.transform.position = position;
		}
		player.GetComponent<NavMeshAgent> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

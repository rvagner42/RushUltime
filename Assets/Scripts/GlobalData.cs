using UnityEngine;
using System.Collections;

public class GlobalData : MonoBehaviour {

	public Player player;

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown ("a"))
		{
			Application.LoadLevel ("Dungeon03");
			player.transform.position = new Vector3(0f, 0f, 0f);

		}*/
	}
}

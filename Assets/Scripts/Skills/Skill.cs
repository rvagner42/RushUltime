using UnityEngine;
using System.Collections;

public abstract class Skill : MonoBehaviour {

	public int level;
	public int mana;
	public float cooldown;
	public GameObject cast;
	[HideInInspector]
	public AudioSource ausou;
	[HideInInspector]
	public float lastTime;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	
	}

	public abstract void Cast(Vector3 position, Quaternion rotation);
}

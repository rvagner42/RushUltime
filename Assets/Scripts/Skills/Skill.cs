using UnityEngine;
using System.Collections;

public abstract class Skill : MonoBehaviour {

	public int baseMinDamage;
	public int baseMaxDamage;
	public float intMult;	
	public int lvlMinDamage;
	public int lvlMaxDamage;

	public int baseMana;
	public int lvlMana;

	public float baseCooldown;
	public float lvlCooldown;

	public float baseDuration;
	public float lvlDuration;

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

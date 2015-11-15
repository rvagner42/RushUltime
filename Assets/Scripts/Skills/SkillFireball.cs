using UnityEngine;
using System.Collections;

public class SkillFireball: Skill {
	
	// Use this for initialization
	void Start () {
		ausou = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	override public void Cast(Vector3 position, Quaternion rotation)
	{
		ausou.Play ();
		GameObject tmp = Instantiate(cast, transform.position, rotation) as GameObject;
		tmp.GetComponent<Cast>().damage = 10;
	}
}

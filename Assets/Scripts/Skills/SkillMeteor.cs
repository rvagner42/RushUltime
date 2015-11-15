using UnityEngine;
using System.Collections;

public class SkillMeteor : Skill {
	
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
		position.y += 50;
		Cast tmp = Instantiate(cast, position, rotation) as Cast;
	}
}

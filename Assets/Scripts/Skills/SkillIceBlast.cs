using UnityEngine;
using System.Collections;

public class SkillIceBlast : Skill {
	
	// Use this for initialization
	void Start () {
		ausou = GetComponent<AudioSource>();
		lastTime = Time.time - cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	override public void Cast(Vector3 position, Quaternion rotation)
	{
		if (Time.time > lastTime + cooldown)
		{
			ausou.Play ();
			GameObject tmp = Instantiate(cast, transform.position, rotation) as GameObject;
			//tmp.GetComponent<Cast>().damage = 10;
			lastTime = Time.time;
		}
	}
}

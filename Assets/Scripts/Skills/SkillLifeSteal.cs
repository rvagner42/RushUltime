using UnityEngine;
using System.Collections;

public class SkillLifeSteal: Skill {
	
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
			GameObject tmp = Instantiate(cast, transform.position, transform.rotation) as GameObject;
			tmp.transform.parent = transform;
			//tmp.GetComponent<Cast>().damage = 10;
			lastTime = Time.time;
		}
	}
}

﻿using UnityEngine;
using System.Collections;

public class SkillIceBlast : Skill {
	
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
		Cast tmp = Instantiate(cast, transform.position, rotation) as Cast;
		
	}
}

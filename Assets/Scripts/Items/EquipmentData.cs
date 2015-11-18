using UnityEngine;
using System.Collections;

public class EquipmentData : ScriptableObject
{
	public int							level;
	public float						attack_speed;
	public int							dmg;
	public int							id;
	public Sprite						sprite;
	public string						name;

	public int							added_min;
	public int							added_max;

	public Transform					weapon_holder;
	
	void Start()
	{

	}

	public string ToString()
	{
		return ("level: " + level.ToString() + "; name: " + name + "; attack_speed: " + attack_speed.ToString() + "; dmg: " + dmg.ToString() + "\nmin: " + added_min + ";max: " + added_max);
	}
}

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

	public Transform					weapon_holder;
	
	void Start()
	{

	}

	public void Equip()
	{
		weapon_holder.GetChild (0).gameObject.SetActive (false);
		weapon_holder.GetChild (1).gameObject.SetActive (false);
		weapon_holder.GetChild (2).gameObject.SetActive (false);
		weapon_holder.GetChild (3).gameObject.SetActive (false);
		
		weapon_holder.GetChild (id).gameObject.SetActive (true);
	}

	public string ToString()
	{
		return ("level: " + level.ToString() + "; name: " + name + "; attack_speed: " + attack_speed.ToString() + "; dmg: " + dmg.ToString());
	}
}

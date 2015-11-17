using UnityEngine;
using System.Collections;

public class Equipment : MonoBehaviour
{
	[HideInInspector]public int			level;
	[HideInInspector]public string		name;
	[HideInInspector]public float		attack_speed;
	[HideInInspector]public float		dmg;
	public int							id;
	public Sprite						sprite;
	private Transform					weapon_holder;

	void Start()
	{
		weapon_holder = GameObject.FindGameObjectWithTag ("WeaponHolder").transform;
	}

	public void Equip()
	{
		weapon_holder.GetChild (0).gameObject.SetActive (false);
		weapon_holder.GetChild (1).gameObject.SetActive (false);
		weapon_holder.GetChild (2).gameObject.SetActive (false);
		
		weapon_holder.GetChild (id).gameObject.SetActive (true);
	}
}

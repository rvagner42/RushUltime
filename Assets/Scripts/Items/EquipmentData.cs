using UnityEngine;
using System.Collections;

public class EquipmentData : ScriptableObject
{
	public int							level;
	public float						attack_speed;
	public int							dmg;
	public int							id;
	public Sprite						sprite;
	public string						equip_name;
	public string						rarity;

	public int							added_min;
	public int							added_max;

	public Transform					weapon_holder;
}

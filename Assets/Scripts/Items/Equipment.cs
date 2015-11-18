using UnityEngine;
using System.Collections;

public class Equipment : MonoBehaviour
{
	[HideInInspector]public EquipmentData	data;

	public int								id;
	public Sprite							sprite;
	public string							name;

	public float							min_attack_speed;
	public float							max_attack_speed;
	public int								base_dmg;
	public int								inc_dmg;

	void Start()
	{
		data = ScriptableObject.CreateInstance ("EquipmentData") as EquipmentData;
		data.level = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().level;
		data.attack_speed = Random.Range (min_attack_speed, max_attack_speed);
		data.dmg = base_dmg + inc_dmg * data.level;
		data.dmg = Random.Range (data.dmg - (data.dmg / 5), data.dmg + (data.dmg / 5));
		data.added_min = data.dmg - (data.dmg / 10);
		data.added_max = data.dmg + (data.dmg / 10);
		data.id = id;
		data.sprite = sprite;
		data.name = name;
		data.weapon_holder = GameObject.FindGameObjectWithTag ("WeaponHolder").transform;
	}
}

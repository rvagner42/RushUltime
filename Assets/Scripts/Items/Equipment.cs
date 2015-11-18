using UnityEngine;
using System.Collections;

public class Equipment : MonoBehaviour
{
	[HideInInspector]public EquipmentData	data;

	public int								id;
	public Sprite							sprite;
	public string							equip_name;
	
	public float							min_attack_speed;
	public float							max_attack_speed;
	public int								base_dmg;
	public int								inc_dmg;

	void Awake()
	{
		data = ScriptableObject.CreateInstance ("EquipmentData") as EquipmentData;
		data.level = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().level;
		data.attack_speed = Random.Range (min_attack_speed, max_attack_speed);
		data.dmg = base_dmg + inc_dmg * data.level;
		data.dmg = Random.Range (data.dmg - (data.dmg / 5), data.dmg + (data.dmg / 5));
		SetRarity (Random.Range (0, 10000));
		data.added_min = data.dmg - (data.dmg / 10);
		data.added_max = data.dmg + (data.dmg / 10);
		data.id = id;
		data.sprite = sprite;
		data.equip_name = equip_name;
		data.weapon_holder = GameObject.FindGameObjectWithTag ("WeaponHolder").transform;
	}

	void SetRarity(int rand)
	{
		if (rand == 0)
		{
			data.rarity = "Legendary";
			data.dmg = data.dmg * 2;
			data.attack_speed = max_attack_speed;
		}
		else if (rand < 10)
		{
			data.rarity = "Epic";
			data.dmg = Mathf.RoundToInt(data.dmg * 1.75f);
		}
		else if (rand < 500)
		{
			data.rarity = "Rare";
			data.dmg = Mathf.RoundToInt(data.dmg * 1.5f);
		}
		else if (rand < 5000)
		{
			data.rarity = "Uncommon";
			data.dmg = Mathf.RoundToInt(data.dmg * 1.15f);
		}
		else
			data.rarity = "Common";
	}

	public void CopyData(EquipmentData new_data)
	{
		data.level = new_data.level;
		data.dmg = new_data.dmg;
		data.added_max = new_data.added_max;
		data.added_min = new_data.added_min;
		data.attack_speed = new_data.attack_speed;
		data.rarity = new_data.rarity;
	}
}

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

	[HideInInspector]public Transform		tooltip;
	private UnityEngine.UI.Text				tooltip_title;
	private UnityEngine.UI.Text				tooltip_description;

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
		Destroy (gameObject, 60.0f);
	}

	void Start()
	{
		tooltip = GameObject.FindGameObjectWithTag ("Tooltip").transform.GetChild (0).transform;
		tooltip_title = tooltip.GetChild (0).GetChild (0).GetComponent<UnityEngine.UI.Text> ();
		tooltip_description = tooltip.GetChild (1).GetChild (0).GetComponent<UnityEngine.UI.Text> ();
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

	void OnDestroy()
	{
		tooltip.gameObject.SetActive (false);
	}

	void OnMouseEnter()
	{
		tooltip.gameObject.SetActive (true);
		tooltip_title.text = data.equip_name;
		tooltip_description.text = "(lvl " + data.level.ToString () + ")"
			+ "\n[" + data.rarity + "] "
			+ "\n\nMin: " + data.added_min.ToString ()
			+ "\nMax: " + data.added_max.ToString ()
			+ "\nSpeed: " + data.attack_speed.ToString ("F2") + "\n";
	}

	void OnMouseExit()
	{
		tooltip.gameObject.SetActive (false);
	}
}

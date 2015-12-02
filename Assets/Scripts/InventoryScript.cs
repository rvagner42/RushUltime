using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private Transform						panel;
	private Transform						items_part;
	private Transform						equipped_part;
	private UnityEngine.UI.Text				equipped_name;
	private UnityEngine.UI.Text				equipped_level;
	private UnityEngine.UI.Text				equipped_rarity;
	private UnityEngine.UI.Text				equipped_min_dmg;
	private UnityEngine.UI.Text				equipped_max_dmg;
	private UnityEngine.UI.Text				equipped_attack_speed;

	public List<GameObject>					weapons;

	[HideInInspector]public Player			player;
	[HideInInspector]public EquipmentData	selected;

	private Transform						tooltip;
	private UnityEngine.UI.Text				tooltip_title;
	private UnityEngine.UI.Text				tooltip_description;

	private bool							pointer_over = false;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		panel = transform.GetChild (0);
		items_part = panel.GetChild (1);
		equipped_part = panel.GetChild (2);
		equipped_name = equipped_part.GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		equipped_level = equipped_part.GetChild (2).GetComponent<UnityEngine.UI.Text> ();
		equipped_rarity = equipped_part.GetChild (3).GetComponent<UnityEngine.UI.Text> ();
		equipped_min_dmg = equipped_part.GetChild (4).GetComponent<UnityEngine.UI.Text> ();
		equipped_max_dmg = equipped_part.GetChild (5).GetComponent<UnityEngine.UI.Text> ();
		equipped_attack_speed = equipped_part.GetChild (6).GetComponent<UnityEngine.UI.Text> ();
		selected = null;

		tooltip = GameObject.FindGameObjectWithTag ("Tooltip").transform.GetChild (0).transform;
		tooltip_title = tooltip.GetChild (0).GetChild (0).GetComponent<UnityEngine.UI.Text> ();
		tooltip_description = tooltip.GetChild (1).GetChild (0).GetComponent<UnityEngine.UI.Text> ();

		StartCoroutine (UIUpdate ());
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.I))
		{
			panel.gameObject.SetActive (!panel.gameObject.activeInHierarchy);
			selected = null;
			pointer_over = !pointer_over;
			DisableTooltip ();
		}
	}

	public void OnPointerEnter(PointerEventData pointer_data)
	{
		pointer_over = true;
	}
	
	public void OnPointerExit(PointerEventData pointer_data)
	{
		pointer_over = false;
	}

	public void EnableTooltip(EquipmentData data)
	{
		tooltip.gameObject.SetActive (true);
		tooltip_title.text = data.equip_name;
		tooltip_description.text = "(lvl " + data.level.ToString() + ")"
			+ "\n[" + data.rarity + "] "
			+ "\n\nMin: " + data.added_min.ToString ()
			+ "\nMax: " + data.added_max.ToString ()
			+ "\nSpeed: " + data.attack_speed.ToString ("F2") + "\n";
	}

	public void DisableTooltip()
	{
		tooltip.gameObject.SetActive (false);
	}

	IEnumerator UIUpdate()
	{
		for (;;)
		{
			if (panel.gameObject.activeInHierarchy)
			{
				for (int i = 0; i < 20; i++)
				{
					items_part.GetChild (i).GetComponent<InventorySlot> ().Remove();
				}
				equipped_part.GetChild (0).GetComponent<InventorySlot> ().Remove();
				equipped_name.text = "No Weapon";
				equipped_level.text = "";
				equipped_rarity.text = "";
				equipped_min_dmg.text = "";
				equipped_max_dmg.text = "";
				equipped_attack_speed.text = "";
				for (int i = 0; i < player.inventory.Count; i++)
				{
					items_part.GetChild (i).GetComponent<InventorySlot> ().Add(player.inventory[i]);
				}
				if (player.equipped != null)
				{
					equipped_part.GetChild (0).GetComponent<InventorySlot> ().Add(player.equipped);
					equipped_name.text = player.equipped.equip_name;
					equipped_level.text = "[ lvl " + player.equipped.level.ToString() + "]";
					equipped_rarity.text = player.equipped.rarity;
					equipped_min_dmg.text = "Min: " + player.equipped.added_min.ToString();
					equipped_max_dmg.text = "Max: " + player.equipped.added_max.ToString();
					equipped_attack_speed.text = "Speed: " + player.equipped.attack_speed.ToString("F2");
				}
			}
			yield return new WaitForSeconds (0.1f);
		}
	}
}

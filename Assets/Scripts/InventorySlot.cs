using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public EquipmentData			data;

	private InventoryScript			inventory_ui;

	private Transform				background;
	private UnityEngine.UI.Image	sprite;
	private bool					pointer_over = false;

	void Start ()
	{
		background = transform.GetChild (0);
		sprite = transform.GetChild (1).GetComponent<UnityEngine.UI.Image> ();
		inventory_ui = transform.parent.parent.parent.GetComponent<InventoryScript> ();
		data = null;
	}

	void Update ()
	{
		if (pointer_over && data != null)
		{
			if (Input.GetMouseButtonDown (1))
			{
				if (Input.GetKey (KeyCode.LeftShift))
				{
					GameObject tmp = Instantiate (inventory_ui.weapons[data.id], inventory_ui.player.transform.position, inventory_ui.weapons[data.id].transform.rotation) as GameObject;
					tmp.GetComponent<Equipment> ().data = data;
					if (data == inventory_ui.player.equipped)
						inventory_ui.player.Unequip ();
					inventory_ui.player.inventory.Remove(data);
				}
				else
				{
					inventory_ui.player.Unequip ();
					inventory_ui.player.Equip (data);
				}
			}
			else if (Input.GetMouseButtonDown (0))
			{
				if (inventory_ui.selected == null)
					inventory_ui.selected = data;
				else
				{
					int index1 = inventory_ui.player.inventory.FindIndex (x => x == inventory_ui.selected);
					int index2 = inventory_ui.player.inventory.FindIndex (x => x == data);

					if (index1 != index2)
					{
						EquipmentData tmp = inventory_ui.player.inventory[index1];
						inventory_ui.player.inventory[index1] = inventory_ui.player.inventory[index2];
						inventory_ui.player.inventory[index2] = tmp;
						inventory_ui.selected = null;
					}
				}
			}
		}
	}

	public void Add(EquipmentData data_added)
	{
		data = data_added;
		background.gameObject.SetActive (true);
		sprite.gameObject.SetActive (true);
		sprite.sprite = data.sprite;
	}

	public void Remove()
	{
		data = null;
		background.gameObject.SetActive (false);
		sprite.gameObject.SetActive (false);
	}

	public void OnPointerEnter(PointerEventData pointer_data)
	{
		pointer_over = true;
		if (data != null)
			inventory_ui.EnableTooltip (data);
	}
	
	public void OnPointerExit(PointerEventData pointer_data)
	{
		inventory_ui.DisableTooltip ();
		pointer_over = false;
	}
}

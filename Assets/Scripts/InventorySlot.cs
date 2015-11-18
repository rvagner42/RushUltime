using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public EquipmentData			data;

	private Transform				background;
	private UnityEngine.UI.Image	sprite;
	private bool					pointer_over = false;

	void Start ()
	{
		background = transform.GetChild (0);
		sprite = transform.GetChild (1).GetComponent<UnityEngine.UI.Image> ();
	}

	void Update ()
	{
		if (pointer_over && data != null && Input.GetMouseButtonDown (1))
		{
			if (Input.GetKey (KeyCode.LeftShift))
			{
				transform.parent.parent.parent.GetComponent<InventoryScript> ().player.Unequip ();
				transform.parent.parent.parent.GetComponent<InventoryScript> ().player.inventory.Remove(data);
			}
			else
			{
				transform.parent.parent.parent.GetComponent<InventoryScript> ().player.Unequip ();
				transform.parent.parent.parent.GetComponent<InventoryScript> ().player.Equip (data);
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
	}
	
	public void OnPointerExit(PointerEventData pointer_data)
	{
		pointer_over = false;
	}
}

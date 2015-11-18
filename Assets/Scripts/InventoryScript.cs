using UnityEngine;
using System.Collections;

public class InventoryScript : MonoBehaviour
{
	public Player					player;
	private Transform				panel;
	private Transform				items_part;
	private Transform				equipped_part;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		panel = transform.GetChild (0);
		items_part = panel.GetChild (1);
		equipped_part = panel.GetChild (2).GetChild (0);
		StartCoroutine (UIUpdate ());
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.I))
		{
			panel.gameObject.SetActive (!panel.gameObject.activeInHierarchy);
		}
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
				equipped_part.GetComponent<InventorySlot> ().Remove();
				for (int i = 0; i < player.inventory.Count; i++)
				{
					items_part.GetChild (i).GetComponent<InventorySlot> ().Add(player.inventory[i]);
				}
				if (player.equipped != null)
					equipped_part.GetComponent<InventorySlot> ().Add(player.equipped);
			}
			yield return new WaitForSeconds (0.1f);
		}
	}
}

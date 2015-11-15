﻿using UnityEngine;
using System.Collections;

public class CharaStatsScript : MonoBehaviour {

	private Player					player;
	
	private Transform				panel;
	private Transform				upgrade_button;
	private UnityEngine.UI.Text		level;
	private UnityEngine.UI.Text		strength;
	private Transform				strength_button;
	private UnityEngine.UI.Text		agility;
	private Transform				agility_button;
	private UnityEngine.UI.Text		constitution;
	private Transform				constitution_button;
	private UnityEngine.UI.Text		armor;
	private UnityEngine.UI.Text		min_dmg;
	private UnityEngine.UI.Text		max_dmg;
	private UnityEngine.UI.Text		max_hp;
	private UnityEngine.UI.Text		current_xp;
	private UnityEngine.UI.Text		next_level;
	private UnityEngine.UI.Text		money;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		panel = transform.GetChild (0);
		upgrade_button = transform.GetChild (1);
		level = panel.GetChild (0).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		strength = panel.GetChild (1).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		strength_button = panel.GetChild (1).GetChild (2);
		agility = panel.GetChild (2).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		agility_button = panel.GetChild (2).GetChild (2);
		constitution = panel.GetChild (3).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		constitution_button = panel.GetChild (3).GetChild (2);
		armor = panel.GetChild (4).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		min_dmg = panel.GetChild (5).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		max_dmg = panel.GetChild (6).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		max_hp = panel.GetChild (7).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		current_xp = panel.GetChild (8).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		next_level = panel.GetChild (9).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		money = panel.GetChild (10).GetChild (1).GetComponent<UnityEngine.UI.Text> ();

		StartCoroutine (UpdateStats ());
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.C))
		{
			panel.gameObject.SetActive (!panel.gameObject.activeInHierarchy);
		}
		if (player.upgrade_points > 0)
			upgrade_button.gameObject.SetActive(true);
		else
			upgrade_button.gameObject.SetActive(false);
	}

	IEnumerator UpdateStats()
	{
		for (;;)
		{
			level.text = "( Lvl " + player.level.ToString() + " )";
			strength.text = player.str.ToString();
			agility.text = player.agi.ToString();
			constitution.text = player.con.ToString();
			armor.text = player.armor.ToString();
			min_dmg.text = (player.str / 2).ToString();
			max_dmg.text = ((player.str / 2) + 4).ToString();
			max_hp.text = (player.con * 5).ToString();
			current_xp.text = player.xp.ToString();
			next_level.text = player.xp_next.ToString();
			money.text = player.money.ToString();

			if (player.upgrade_points > 0)
			{
				strength_button.gameObject.SetActive(true);
				agility_button.gameObject.SetActive(true);
				constitution_button.gameObject.SetActive(true);
			}
			else
			{
				strength_button.gameObject.SetActive(false);
				agility_button.gameObject.SetActive(false);
				constitution_button.gameObject.SetActive(false);
			}

			yield return new WaitForSeconds (0.1f);
		}
	}

	public void UpgradeButton()
	{
		panel.gameObject.SetActive (true);
	}

	public void IncreaseStrength()
	{
		if (player.upgrade_points > 0)
		{
			player.upgrade_points -= 1;
			player.str += 1;
			player.CalculateStats();
		}
	}

	public void IncreaseAgility()
	{
		if (player.upgrade_points > 0)
		{
			player.upgrade_points -= 1;
			player.agi += 1;
			player.CalculateStats();
		}
	}

	public void IncreaseConstitution()
	{
		if (player.upgrade_points > 0)
		{
			player.upgrade_points -= 1;
			player.con += 1;
			player.CalculateStats();
		}
	}
}
using UnityEngine;
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
	private UnityEngine.UI.Text		intelligence;
	private Transform				intelligence_button;
	private UnityEngine.UI.Text		upgrade_points;
	private UnityEngine.UI.Text		armor;
	private UnityEngine.UI.Text		min_dmg_phys;
	private UnityEngine.UI.Text		max_dmg_phys;
	private UnityEngine.UI.Text		min_dmg_mag;
	private UnityEngine.UI.Text		max_dmg_mag;
	private UnityEngine.UI.Text		attack_speed;
	private UnityEngine.UI.Text		current_xp;
	private UnityEngine.UI.Text		next_level;
	private UnityEngine.UI.Text		money;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		panel = transform.GetChild (0);

		upgrade_button = transform.FindChild ("Button");

		level = panel.GetChild (0).GetChild (1).GetComponent<UnityEngine.UI.Text> ();

		strength 			= panel.GetChild (1).GetChild (0).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		strength_button		= panel.GetChild (1).GetChild (0).GetChild (2);
		agility				= panel.GetChild (1).GetChild (1).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		agility_button		= panel.GetChild (1).GetChild (1).GetChild (2);
		constitution		= panel.GetChild (1).GetChild (2).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		constitution_button	= panel.GetChild (1).GetChild (2).GetChild (2);
		intelligence		= panel.GetChild (1).GetChild (3).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		intelligence_button	= panel.GetChild (1).GetChild (3).GetChild (2);
		upgrade_points		= panel.GetChild (1).GetChild (4).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		
		armor			= panel.GetChild (2).GetChild (0).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		min_dmg_phys	= panel.GetChild (2).GetChild (1).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		max_dmg_phys	= panel.GetChild (2).GetChild (2).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		min_dmg_mag		= panel.GetChild (2).GetChild (3).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		max_dmg_mag		= panel.GetChild (2).GetChild (4).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		attack_speed	= panel.GetChild (2).GetChild (5).GetChild (1).GetComponent<UnityEngine.UI.Text> ();

		current_xp	= panel.GetChild (3).GetChild (0).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		next_level	= panel.GetChild (3).GetChild (1).GetChild (1).GetComponent<UnityEngine.UI.Text> ();
		money		= panel.GetChild (3).GetChild (2).GetChild (1).GetComponent<UnityEngine.UI.Text> ();

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
			int added_min = 0;
			int added_max = 0;
			if (player.equipped != null)
			{
				added_min = player.equipped.added_min;
				added_max = player.equipped.added_max;
			}

			level.text = "( Lvl " + player.level.ToString() + " )";
			strength.text = player.str.ToString();
			agility.text = player.agi.ToString();
			constitution.text = player.con.ToString();
			intelligence.text = player.intel.ToString();
			upgrade_points.text = player.upgrade_points.ToString();
			armor.text = player.armor.ToString();
			min_dmg_phys.text = (player.min_dmg_phys + added_min).ToString();
			max_dmg_phys.text = (player.max_dmg_phys + added_max).ToString();
			min_dmg_mag.text = player.min_dmg_mag.ToString();
			max_dmg_mag.text = player.max_dmg_mag.ToString();
			attack_speed.text = player.attack_speed.ToString("F2");
			current_xp.text = player.xp.ToString();
			next_level.text = player.xp_next.ToString();
			money.text = player.money.ToString();

			if (player.upgrade_points > 0)
			{
				strength_button.gameObject.SetActive(true);
				agility_button.gameObject.SetActive(true);
				constitution_button.gameObject.SetActive(true);
				intelligence_button.gameObject.SetActive(true);
			}
			else
			{
				strength_button.gameObject.SetActive(false);
				agility_button.gameObject.SetActive(false);
				constitution_button.gameObject.SetActive(false);
				intelligence_button.gameObject.SetActive(false);
			}

			yield return new WaitForSeconds (0.1f);
		}
	}

	public void UpgradeButton()
	{
		panel.gameObject.SetActive (true);
	}

	public void IncreaseIntelligence()
	{
		if (Input.GetKey (KeyCode.LeftShift))
		{
			if (player.upgrade_points > 9)
			{
				player.upgrade_points -= 10;
				player.intel += 10;
				player.CalculateStats();
				if (player.hp > 0)
					player.mana += 50;
			}
		}
		else
		{
			if (player.upgrade_points > 0)
			{
				player.upgrade_points -= 1;
				player.intel += 1;
				player.CalculateStats();
				if (player.hp > 0)
					player.mana += 5;
			}
		}
	}

	public void IncreaseStrength()
	{
		if (Input.GetKey (KeyCode.LeftShift))
		{
			if (player.upgrade_points > 9)
			{
				player.upgrade_points -= 10;
				player.str += 10;
				player.CalculateStats();
				if (player.hp > 0)
					player.hp += 10;
			}
		}
		else
		{
			if (player.upgrade_points > 0)
			{
				player.upgrade_points -= 1;
				player.str += 1;
				player.CalculateStats();
				if (player.hp > 0)
					player.hp += 1;
			}
		}
	}

	public void IncreaseAgility()
	{
		if (Input.GetKey (KeyCode.LeftShift))
		{
			if (player.upgrade_points > 9)
			{
				player.upgrade_points -= 10;
				player.agi += 10;
				player.CalculateStats();
			}
		}
		else
		{
			if (player.upgrade_points > 0)
			{
				player.upgrade_points -= 1;
				player.agi += 1;
				player.CalculateStats();
			}
		}
	}

	public void IncreaseConstitution()
	{
		if (Input.GetKey (KeyCode.LeftShift))
		{
			if (player.upgrade_points > 9)
			{
				player.upgrade_points -= 10;
				player.con += 10;
				player.armor += 10;
				player.CalculateStats();
				if (player.hp > 0)
					player.hp += 50;
			}
		}
		else
		{
			if (player.upgrade_points > 0)
			{
				player.upgrade_points -= 1;
				player.con += 1;
				player.armor += 1;
				player.CalculateStats();
				if (player.hp > 0)
					player.hp += 5;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	[HideInInspector]public int		str;
	[HideInInspector]public int		agi;
	[HideInInspector]public int		con;
	[HideInInspector]public int		armor;
	[HideInInspector]public int		intel;
	[HideInInspector]public int		hp;
	[HideInInspector]public int		hp_max;
	[HideInInspector]public int		min_dmg_phys;
	[HideInInspector]public int		max_dmg_phys;
	[HideInInspector]public int		min_dmg_mag;
	[HideInInspector]public int		max_dmg_mag;
	[HideInInspector]public int		level;

	public int						base_str;
	public int						base_agi;
	public int						base_con;
	public int						base_armor;
	public int						base_intel;

	public int						inc_str;
	public int						inc_agi;
	public int						inc_con;
	public int						inc_armor;
	public int						inc_intel;

	// Use this for initialization
	void Awake ()
	{
		level = 1;
		str = base_str;
		agi = base_agi;
		con = base_con;
		armor = base_armor;
		intel = base_intel;
		CalculateStats ();
		hp = hp_max;
	}

	public int GetAttacked(int dmg, int attacker_agi)
	{
		int hit = 75 + attacker_agi - agi;
		if (Random.Range (0, 100) < hit + 1.0f)
		{
			int totalDmg = dmg - armor;
			if (totalDmg < dmg / 4)
				totalDmg = dmg / 4;
			hp -= totalDmg;
			if (hp < 0)
				hp = 0;
		}
		return (hp);
	}

	public void CalculateStats()
	{
		hp_max = 5 * con;
		min_dmg_phys = str - (str / 10);
		max_dmg_phys = str + (str / 10);
		min_dmg_mag = intel - (intel / 10);
		max_dmg_mag = intel + (intel / 10);
	}
}

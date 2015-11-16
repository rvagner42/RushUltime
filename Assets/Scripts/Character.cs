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
	protected int					minDmg;
	protected int					maxDmg;
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
		if (Random.Range (0, 101) < hit)
		{
			int totalDmg = dmg * (1 - armor / 200);
			hp -= totalDmg;
			if (hp < 0)
				hp = 0;
		}
		return (hp);
	}

	public void CalculateStats()
	{
		hp_max = 5 * con;
		minDmg = str / 2;
		maxDmg = minDmg + 4;
	}
}

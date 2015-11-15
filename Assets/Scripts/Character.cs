using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public int						str;
	public int						agi;
	public int						con;
	public int						armor;
	[HideInInspector]public int		hp;

	protected int					minDmg;
	protected int					maxDmg;
	[HideInInspector]public int		level;

	// Use this for initialization
	void Awake ()
	{
		CalculateStats ();
		level = 1;
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
		hp = 5 * con;
		minDmg = str / 2;
		maxDmg = minDmg + 4;
	}
}

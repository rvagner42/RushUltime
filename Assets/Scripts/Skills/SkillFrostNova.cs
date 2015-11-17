using UnityEngine;
using System.Collections;

public class SkillFrostNova : Skill {

	private PlayerSkills playerSkills;
	
	private float cooldown;
	private int minDamage;
	private int maxDamage;
	private int randDamage;
	private int mana;
	private float duration;
	
	// Use this for initialization
	void Start ()
	{
		ausou = GetComponent<AudioSource>();
		lastTime = -1000f;
		playerSkills = transform.parent.GetComponent<PlayerSkills> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	override public void Cast(Vector3 position, Quaternion rotation)
	{
		cooldown = baseCooldown + (playerSkills.lvl2Col3 * lvlCooldown);
		mana = baseMana + (playerSkills.lvl2Col3 * lvlMana);
		if (playerSkills.lvl2Col3 > 0 && playerSkills.player.mana > mana && Time.time > lastTime + cooldown)
		{
			minDamage = Mathf.RoundToInt(baseMinDamage + (playerSkills.lvl2Col3 * lvlMinDamage) + (playerSkills.player.min_dmg_mag * intMult));
			maxDamage = Mathf.RoundToInt(baseMinDamage + (playerSkills.lvl2Col3 * lvlMaxDamage) + (playerSkills.player.max_dmg_mag * intMult));
			randDamage = Random.Range (minDamage, maxDamage + 1);
			duration = baseDuration + (playerSkills.lvl2Col3 * lvlDuration);
			ausou.Play ();
			GameObject tmp = Instantiate(cast, transform.position, Quaternion.Euler(270, 0, 0)) as GameObject;
			tmp.transform.parent = transform;
			tmp.GetComponent<Cast>().damage = randDamage;
			tmp.GetComponent<Cast>().destroyTime = duration;
			playerSkills.player.mana -= mana;
			lastTime = Time.time;
		}
	}
}
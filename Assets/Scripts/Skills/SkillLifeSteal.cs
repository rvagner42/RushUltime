using UnityEngine;
using System.Collections;

public class SkillLifeSteal: Skill {

	private PlayerSkills playerSkills;
	
	private float cooldown;
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
		cooldown = baseCooldown + (playerSkills.lvl2Col2 * lvlCooldown);
		mana = baseMana + (playerSkills.lvl2Col2 * lvlMana);
		if (playerSkills.lvl2Col2 > 0 && playerSkills.player.mana > mana && Time.time > lastTime + cooldown)
		{
			duration = baseDuration + (playerSkills.lvl2Col2 * lvlDuration);
			ausou.Play ();
			GameObject tmp = Instantiate(cast, transform.position, transform.rotation) as GameObject;
			tmp.transform.parent = transform;
			tmp.GetComponent<Cast>().destroyTime = duration;
			playerSkills.player.mana -= mana;
			lastTime = Time.time;
		}
	}
}
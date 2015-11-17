using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Player : Character {

	/// <summary>
	/// Pouet
	/// </summary>

	public Skill skillQ;



	public Skill									currentSkill;

	private NavMeshAgent							agent;
	private Animator								animator;
	private Enemy									target_enemy;
	private Equipment								target_equip;
	private float									attack_start_time;
	private bool									is_dead = false;
	private UIMaya									ui_maya;
	private UIEnemy									ui_enemy;


	[HideInInspector]public int						xp = 0;
	[HideInInspector]public int						xp_next = 150;
	[HideInInspector]public int						money = 0;
	[HideInInspector]public int						upgrade_points = 0;
	[HideInInspector]public int						skillPoints = 0;
	[HideInInspector]public List<Equipment>			inventory = new List<Equipment> ();

	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		target_enemy = null;
		target_equip = null;
		ui_maya = GameObject.FindGameObjectWithTag ("Maya UI").GetComponent<UIMaya> ();
		ui_enemy = GameObject.FindGameObjectWithTag ("Enemy UI").GetComponent<UIEnemy> ();
		ui_enemy.Enable (false);
		StartCoroutine (UIUpdate ());
		StartCoroutine (RegenHP ());
		StartCoroutine (RegenMana ());
	}
	
	void Update ()
	{
		if (!is_dead) {
			if (!EventSystem.current.IsPointerOverGameObject())
				CheckClick ();
			Animate ();
			if (hp <= 0)
			{
				hp = 0;
				is_dead = true;
				target_enemy = null;
				animator.SetTrigger("is_dead");
				ui_maya.DeathUI();
			}
			if (Input.GetKeyDown (KeyCode.KeypadPlus))
				LevelUp ();
		}
	}

	void Animate()
	{
		if (agent.destination != transform.position && !animator.GetBool ("is_walking"))
			animator.SetBool ("is_walking", true);
		if (agent.destination == transform.position && animator.GetBool ("is_walking"))
			animator.SetBool ("is_walking", false);
		if (animator.GetBool ("is_attacking") == true && target_enemy == null)
		{
			animator.SetBool ("is_attacking", false);
			animator.speed = 1.0f;
		}
	}

	void CheckClick()
	{
		if (Input.GetMouseButtonDown (0))
		{
			RaycastHit hit;
			
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit))
			{
				if (hit.collider.tag == "Enemy")
				{
					target_enemy = hit.collider.GetComponent<Enemy> ();
					target_equip = null;
					agent.destination = target_enemy.transform.position;
					ui_enemy.Enable (true);
				}
				else if (hit.collider.tag == "Equipment")
				{
					target_enemy = null;
					target_equip = hit.collider.GetComponent<Equipment> ();
					agent.destination = target_equip.transform.position;
					ui_enemy.Enable (false);
				}
				else
				{
					target_enemy = null;
					agent.destination = hit.point;
					ui_enemy.Enable (false);
				}
			}
		}
		if (Input.GetMouseButton (0))
		{
			if (target_enemy == null)
			{
				RaycastHit hit;
				
				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit))
					agent.destination = hit.point;
			}
		}
		if (target_enemy != null)
			Attack ();
		if (target_equip != null)
			Fetch ();


		if (Input.GetMouseButton (1))
		{
			agent.destination = transform.position;
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
				Quaternion rotation = transform.rotation;
				rotation.x = 0;
				rotation.z = 0;
				currentSkill.Cast(hit.point, rotation);
			}
		}

	}

	void Attack()
	{
		ui_enemy.Enable (true);
		if (Vector3.Distance (target_enemy.transform.position, transform.position) < 3.0f && target_enemy.hp > 0)
		{
			transform.LookAt (target_enemy.transform.position);
			if (animator.GetBool ("is_attacking") == false)
			{
				agent.destination = transform.position;
				animator.SetBool ("is_attacking", true);
				animator.speed = attack_speed;
				attack_start_time = Time.time;
			}
			else if (Time.time > attack_start_time + (animator.GetCurrentAnimatorStateInfo( 0 ).length))
			{
				animator.SetBool ("is_attacking", false);
				animator.speed = 1.0f;
				if (target_enemy.GetAttacked(Random.Range (min_dmg_phys, max_dmg_phys + 1), agi) <= 0)
				{
					target_enemy = null;
					ui_enemy.Enable (false);
				}
				if (!Input.GetMouseButton (0))
				{
					target_enemy = null;
					agent.destination = transform.position;
					ui_enemy.Enable (false);
				}
			}
		}
	}

	void Fetch()
	{
		if (Vector3.Distance (target_equip.transform.position, transform.position) < 2.5f)
		{
			transform.LookAt (target_equip.transform.position);
			inventory.Add (target_equip);
			Destroy (target_equip.gameObject);
			target_equip = null;
		}
	}

	void LevelUp()
	{
		xp = (xp > 0) ? xp - xp_next : 0;
		xp_next = xp_next + 100 * level;
		level += 1;
		upgrade_points += 5;
		IncStats ();
		CalculateStats ();
		hp = hp_max;
		mana = mana_max;
		skillPoints += 1;
	}

	public void IncStats()
	{
		con += inc_con;
		str += inc_str;
		agi += inc_agi;
		armor += inc_armor;
		intel += inc_intel;
	}

	IEnumerator UIUpdate()
	{
		for (;;)
		{
			if (xp >= xp_next)
				LevelUp();
			ui_maya.UpdateUI (hp, hp_max, xp, xp_next, level, mana, mana_max);
			if (target_enemy != null)
				ui_enemy.UpdateUI(target_enemy.hp, target_enemy.hp_max, target_enemy.name_string, target_enemy.level);
			yield return new WaitForSeconds(0.05f);
		}
	}

	IEnumerator RegenHP()
	{
		while (hp > 0)
		{
			hp += (hp_max / 100);
			if (hp > hp_max)
				hp = hp_max;
			yield return new WaitForSeconds (3.0f);
		}
	}

	IEnumerator RegenMana()
	{
		while (mana > 0)
		{
			mana += (mana_max / 100);
			if (mana > mana_max)
				mana = mana_max;
			yield return new WaitForSeconds (1.5f);
		}
	}
}

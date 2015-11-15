using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Player : Character {
	
	private NavMeshAgent				agent;
	private Animator					animator;
	private Enemy						target;
	private float						attack_start_time;
	private bool						is_dead = false;
	private UIMaya						ui_maya;
	private UIEnemy						ui_enemy;

	[HideInInspector]public int			xp = 0;
	[HideInInspector]public int			xp_next = 150;
	[HideInInspector]public int			money = 0;
	[HideInInspector]public int			upgrade_points = 0;

	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		target = null;
		ui_maya = GameObject.FindGameObjectWithTag ("Maya UI").GetComponent<UIMaya> ();
		ui_enemy = GameObject.FindGameObjectWithTag ("Enemy UI").GetComponent<UIEnemy> ();
		ui_enemy.Enable (false);
		StartCoroutine (UIUpdate ());
		StartCoroutine (RegenHP ());
	}
	
	void Update ()
	{
		if (!is_dead) {
			if (!EventSystem.current.IsPointerOverGameObject())
				CheckClick ();
			Animate ();
			if (hp <= 0)
			{
				is_dead = true;
				target = null;
				animator.SetTrigger("is_dead");
				ui_maya.DeathUI();
			}
			if (Input.GetKeyDown (KeyCode.N))
				LevelUp ();
		}
	}

	void Animate()
	{
		if (agent.destination != transform.position && !animator.GetBool ("is_walking"))
			animator.SetBool ("is_walking", true);
		if (agent.destination == transform.position && animator.GetBool ("is_walking"))
			animator.SetBool ("is_walking", false);
		if (animator.GetBool ("is_attacking") == true && target == null)
			animator.SetBool ("is_attacking", false);
	}

	void CheckClick()
	{
		if (Input.GetMouseButtonDown (0))
		{
			RaycastHit hit;
			
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit) && hit.collider.tag == "Enemy")
			{
				target = hit.collider.GetComponent<Enemy> ();
				agent.destination = target.transform.position;
				ui_enemy.Enable (true);
			}
		}
		if (Input.GetMouseButtonUp (0) && target != null)
		{
			target = null;
			agent.destination = transform.position;
		}
		if (Input.GetMouseButton (0))
		{
			if (target == null)
			{
				RaycastHit hit;
				
				if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit))
					agent.destination = hit.point;
			}
			else
				Attack ();
		}
	}

	void Attack()
	{
		ui_enemy.Enable (true);
		if (Vector3.Distance (target.transform.position, transform.position) < 3.0f && target.hp > 0)
		{
			transform.LookAt (target.transform.position);
			if (animator.GetBool ("is_attacking") == false)
			{
				agent.destination = transform.position;
				animator.SetBool ("is_attacking", true);
				attack_start_time = Time.time;
			}
			else if (Time.time > attack_start_time + 0.6f)
			{
				animator.SetBool ("is_attacking", false);
				if (target.GetAttacked(Random.Range (minDmg, maxDmg + 1), agi) <= 0)
				{
					xp += target.GiveXP();
					if (xp >= xp_next)
						LevelUp();
					money += target.GiveMoney();
					target = null;
					ui_enemy.Enable (false);
				}
			}
		}
	}

	void LevelUp()
	{
		xp = (xp > 0) ? xp - xp_next : 0;
		xp_next = xp_next + 100 * level;
		level += 1;
		upgrade_points += 5;
	}

	IEnumerator UIUpdate()
	{
		for (;;)
		{
			ui_maya.UpdateUI (hp, con * 5, xp, xp_next, level);
			if (target != null)
				ui_enemy.UpdateUI(target.hp, target.con * 5, target.name_string, target.level);
			yield return new WaitForSeconds(0.05f);
		}
	}

	IEnumerator RegenHP()
	{
		while (hp > 0)
		{
			if (hp < con * 5)
				hp += 1;
			yield return new WaitForSeconds (1.5f);
		}
	}
}

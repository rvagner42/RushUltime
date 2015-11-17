using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Character {

	private NavMeshAgent	agent;
	private Player			player;
	private Animator		animator;
	private UIEnemy			ui_enemy;

	private Player			target;
	private bool			dead = false;
	private float			attack_start_time = 0.0f;

	public int				base_xp;
	public int				inc_xp;
	public int				base_money;
	public int				inc_money;
	public string			name_string;
	public List<GameObject>	drops;
	
	public delegate void	Death();
	public event Death		Died;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		ui_enemy = GameObject.FindGameObjectWithTag ("Enemy UI").GetComponent<UIEnemy> ();
		target = null;
		StartCoroutine (SearchPlayer ());


		level = player.level;
		IncStats ();
		CalculateStats ();
		hp = hp_max;
	}

	void OnMouseEnter()
	{
		ui_enemy.Enable (true);
		ui_enemy.UpdateUI(hp, con * 5, name_string, level);
	}

	void OnMouseOver()
	{
		ui_enemy.UpdateUI(hp, con * 5, name_string, level);
	}

	void OnMouseExit()
	{
		ui_enemy.Enable (false);
	}

	void IncStats()
	{
		con = base_con + (inc_con * level);
		str = base_str + (inc_str * level);
		agi = base_agi + (inc_agi * level);
		armor = base_armor + (inc_armor * level);
		intel = base_intel + (inc_intel * level);
	}

	void Update ()
	{
		if (hp > 0)
		{
			Move ();
			Attack ();
		}
		if (hp <= 0 && dead == false)
		{
			dead = true;
			animator.SetTrigger("is_dead");
			StartCoroutine(Die ());
		}
	}

	void Move()
	{
		if (target == null)
		{
			agent.destination = transform.position;
			animator.SetBool("is_walking", false);
		}
		else
		{
			if (target.transform.position != agent.destination)
			{
				agent.destination = target.transform.position;
				animator.SetBool("is_walking", true);
				agent.Resume();
			}
			if (Vector3.Distance(transform.position, target.transform.position) < 2.0f)
			{
				agent.Stop ();
				animator.SetBool("is_walking", false);
			}
		}
	}

	void Attack()
	{
	
		if (target != null && Vector3.Distance (target.transform.position, transform.position) < 2.0f && target.hp > 0)
		{
			transform.LookAt (target.transform.position);
			if (animator.GetBool ("is_attacking") == false)
			{
				animator.SetBool ("is_attacking", true);
				attack_start_time = Time.time;
			}
			else if (Time.time > attack_start_time + animator.GetCurrentAnimatorStateInfo( 0 ).length)
			{
				animator.SetBool ("is_attacking", false);
				if (target.GetAttacked(Random.Range (min_dmg_phys, max_dmg_phys + 1), agi) <= 0)
				{
					target = null;
				}
			}
		}
		else if (animator.GetBool ("is_attacking") == true)
			animator.SetBool ("is_attacking", false);
	}

	IEnumerator SearchPlayer()
	{
		for (;;)
		{
			RaycastHit hit;
			
			if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, 10.0f))
			{
				if (hit.collider.tag == "Player")
					target = player;
			}
			else
				target = null;
			yield return new WaitForSeconds (0.2f);
		}
	}

	IEnumerator Die()
	{
		GetComponent<Collider> ().enabled = false;
		GetComponent<NavMeshAgent> ().enabled = false;
		player.xp += (base_xp + (inc_xp * level));
		player.money += (base_money + (inc_money * level));
		if (Random.Range (0, 2) == 0)
		Instantiate (drops[Random.Range (0, drops.Count)], transform.position, transform.rotation);
		yield return new WaitForSeconds (4.0f);
		while (transform.position.y > -1.0f)
		{
			transform.Translate (Vector3.down * 0.05f);
			yield return new WaitForSeconds (0.05f);
		}
	
		Destroy (gameObject);
	}

	void OnDestroy()
	{
		Died ();
	}
}

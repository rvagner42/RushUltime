using UnityEngine;
using System.Collections;

public class Enemy : Character {

	private NavMeshAgent	agent;
	private Player			player;
	private Animator		animator;
	private Player			target;
	private bool			dead = false;

	private float			attack_start_time = 0.0f;

	private int				xp = 20;
	private int				money = 10;
	
	public delegate void	Death();
	public event Death		Died;

	private UIEnemy				ui_enemy;

	public string			name_string;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		ui_enemy = GameObject.FindGameObjectWithTag ("Enemy UI").GetComponent<UIEnemy> ();
		target = null;
		StartCoroutine (SearchPlayer ());
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
			else if (Time.time > attack_start_time + 1.2f)
			{
				animator.SetBool ("is_attacking", false);
				if (target.GetAttacked(Random.Range (minDmg, maxDmg + 1), agi) <= 0)
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
		yield return new WaitForSeconds (4.0f);
		while (transform.position.y > -1.0f)
		{
			transform.Translate (Vector3.down * 0.05f);
			yield return new WaitForSeconds (0.05f);
		}
		Destroy (gameObject);
	}

	public int GiveXP()
	{
		if (hp <= 0)
			return (xp);
		return (0);
	}
	
	public int GiveMoney()
	{
		if (hp <= 0)
			return (money);
		return (0);
	}

	void OnDestroy()
	{
		Died ();
	}
}

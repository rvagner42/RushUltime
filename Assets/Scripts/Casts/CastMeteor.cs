using UnityEngine;
using System.Collections;

public class CastMeteor : Cast {
	
	private Rigidbody rb;
	
	public GameObject explosion;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		StartCoroutine(Destroy());
	}
	
	// Update is called once per frame
	void Update () {
		rb.MovePosition(transform.position + Vector3.down * Time.deltaTime * speed);
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")
			collision.gameObject.GetComponent<Enemy> ().hp -= damage;
		else
		{
			Instantiate(explosion, transform.position, Quaternion.identity);
			GetComponent<SphereCollider>().enabled = false;
			Destroy(gameObject, 2f);
		}
	}
}

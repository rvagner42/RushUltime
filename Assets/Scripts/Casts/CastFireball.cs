using UnityEngine;
using System.Collections;

public class CastFireball : Cast {

	private Rigidbody rb;

	public GameObject explosion;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		StartCoroutine(Destroy());
	}
	
	// Update is called once per frame
	void Update () {
		rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")
			collision.gameObject.GetComponent<Enemy>().hp -= damage;
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}

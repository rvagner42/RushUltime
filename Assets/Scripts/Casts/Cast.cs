using UnityEngine;
using System.Collections;

public class Cast : MonoBehaviour {

	public int damage;
	public int speed;
	public float destroyTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected IEnumerator Destroy()
	{
		yield return new WaitForSeconds(destroyTime);
		Destroy(gameObject);
	}
}

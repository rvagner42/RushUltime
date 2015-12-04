using UnityEngine;
using System.Collections;

public class VisibilityBubble : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Wall" && transform.position.z < other.transform.position.z)
		{
			Color alpha = new Color();
			Material[] materials;
			materials = other.transform.gameObject.GetComponent<Renderer>().materials;
			foreach (Material elem in materials)
			{
				alpha = elem.color;
				alpha.a = 0.1f;
				elem.color = alpha;
			}
		}
		else if (other.tag == "Wall" && transform.position.z > other.transform.position.z)
		{
			Color alpha = new Color();
			Material[] materials;
			materials = other.transform.gameObject.GetComponent<Renderer>().materials;
			foreach (Material elem in materials)
			{
				alpha = elem.color;
				alpha.a = 1.0f;
				elem.color = alpha;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		Color alpha = new Color();
		Material[] materials;
		materials = other.transform.gameObject.GetComponent<Renderer>().materials;
		foreach (Material elem in materials)
		{
			alpha = elem.color;
			alpha.a = 1.0f;
			elem.color = alpha;
		}
	}
}

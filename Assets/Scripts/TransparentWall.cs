using UnityEngine;
using System.Collections;

public class TransparentWall : MonoBehaviour {

	[HideInInspector] public bool isTransparent;
	private Color alpha;
	private Material[] materials;

	// Use this for initialization
	void Start () {
		isTransparent = false;
		Color alpha = new Color();
		Material[] materials;
		materials = GetComponent<Renderer> ().materials;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartFadeOut()
	{
		isTransparent = true;
		StopCoroutine (fadeIn ());
		StartCoroutine (fadeOut ());
	}

	IEnumerator fadeOut()
	{
		materials = GetComponent<Renderer> ().materials;
		while (materials[0].color.a > 0.1f)
		{
			foreach (Material elem in materials)
			{
				alpha = elem.color;
				alpha.a -= 0.1f;
				elem.color = alpha;
			}
			yield return new WaitForSeconds(0.025f);
		}
	}

	public void StartFadeIn()
	{
		isTransparent = false;
		StopCoroutine (fadeOut ());
		StartCoroutine (fadeIn ());
	}
	
	IEnumerator fadeIn()
	{
		materials = GetComponent<Renderer> ().materials;
		while (materials[0].color.a < 1.0f)
		{
			foreach (Material elem in materials)
			{
				alpha = elem.color;
				alpha.a += 0.1f;
				elem.color = alpha;
			}
			yield return new WaitForSeconds(0.025f);
		}
	}
}

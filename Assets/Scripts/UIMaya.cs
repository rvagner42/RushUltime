using UnityEngine;
using System.Collections;

public class UIMaya : MonoBehaviour {
	
	private UnityEngine.UI.Image	hp_bar;
	private UnityEngine.UI.Image	mana_bar;
	private UnityEngine.UI.Image	xp_bar;
	private UnityEngine.UI.Text		hp_text;
	private UnityEngine.UI.Text		mana_text;
	private UnityEngine.UI.Text		xp_text;
	private UnityEngine.UI.Text		level_text;
	private Transform				death_screen;

	void Start ()
	{
		hp_bar = transform.GetChild (2).GetChild (1).GetComponent<UnityEngine.UI.Image> ();
		hp_text = transform.GetChild (2).GetChild (3).GetComponent<UnityEngine.UI.Text> ();
		mana_bar = transform.GetChild (3).GetChild (1).GetComponent<UnityEngine.UI.Image> ();
		mana_text = transform.GetChild (3).GetChild (3).GetComponent<UnityEngine.UI.Text> ();
		xp_bar = transform.GetChild (1).GetChild (1).GetComponent<UnityEngine.UI.Image> ();
		xp_text = transform.GetChild (1).GetChild (2).GetComponent<UnityEngine.UI.Text> ();
		level_text = transform.GetChild (4).GetComponent<UnityEngine.UI.Text> ();
		death_screen = transform.GetChild (5);
	}
	
	public void UpdateUI (float hp, float max_hp, float xp, float max_xp, int level, float mana, float max_mana)
	{
		hp_text.text = hp.ToString () + " / " + max_hp.ToString ();
		mana_text.text = mana.ToString () + " / " + max_mana.ToString ();
		xp_text.text = xp.ToString () + " / " + max_xp.ToString ();

		hp_bar.fillAmount = hp / max_hp;
		mana_bar.fillAmount = mana / max_mana;
		xp_bar.fillAmount = xp / max_xp;

		level_text.text = "Level " + level.ToString ();
	}

	public void DeathUI()
	{
		death_screen.gameObject.SetActive (true);
		StartCoroutine (DeathScreen ());
	}

	IEnumerator DeathScreen()
	{
		UnityEngine.UI.Image panel = death_screen.GetChild (0).GetComponent<UnityEngine.UI.Image> ();
		while (panel.color.a < 0.6f)
		{
			panel.color = panel.color + new Color(0.0f, 0.0f, 0.0f, 0.01f);
			yield return new WaitForSeconds (0.05f);
		}
	}
}

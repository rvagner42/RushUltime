using UnityEngine;
using System.Collections;

public class UIEnemy : MonoBehaviour {

	private UnityEngine.UI.Text		name_text;
	private UnityEngine.UI.Image	hp_bar;
	private UnityEngine.UI.Text		hp_text;

	public bool						shown = false;

	void Start ()
	{
		name_text = transform.GetChild (0).GetComponent<UnityEngine.UI.Text> ();
		hp_bar = transform.GetChild (1).GetComponent<UnityEngine.UI.Image> ();
		hp_text = transform.GetChild (2).GetComponent<UnityEngine.UI.Text> ();
	}
	
	public void UpdateUI (float hp, float max_hp, string name, int level)
	{
		hp_text.text = hp.ToString () + " / " + max_hp.ToString ();
		name_text.text = name + " - Level " + level.ToString ();
		
		hp_bar.fillAmount = hp / max_hp;
	}

	public void Enable(bool state)
	{
		if (state == true && shown == false)
		{
			name_text.color = name_text.color + new Color(0.0f, 0.0f, 0.0f, 1.0f);
			hp_bar.color = hp_bar.color + new Color(0.0f, 0.0f, 0.0f, 1.0f);
			hp_text.color = hp_text.color + new Color(0.0f, 0.0f, 0.0f, 1.0f);
			shown = true;
		}
		else if (state == false && shown == true)
		{
			name_text.color = name_text.color - new Color(0.0f, 0.0f, 0.0f, 1.0f);
			hp_bar.color = hp_bar.color - new Color(0.0f, 0.0f, 0.0f, 1.0f);
			hp_text.color = hp_text.color - new Color(0.0f, 0.0f, 0.0f, 1.0f);
			shown = false;
		}
	}
}

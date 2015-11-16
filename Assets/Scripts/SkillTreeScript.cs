using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTreeScript : MonoBehaviour {

	private SkillController skill;
	private Player player;

	private Transform panel;
	private Text lvl1Col1;
	private Text lvl1Col2;
	private Text lvl1Col3;
	private Text lvl2Col1;
	private Text lvl2Col2;
	private Text lvl2Col3;
	private Text lvl3Col1;
	private Text lvl3Col2;
	private Text lvl3Col3;

	private Text freePoints;

	// Use this for initialization
	void Start ()
	{
		skill = GameObject.FindGameObjectWithTag ("Skill").GetComponent<SkillController> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		panel = transform.GetChild (0);

		lvl1Col1 = panel.GetChild (1).GetChild(0).GetChild (1).GetChild (0).GetComponent<Text> ();
		lvl1Col2 = panel.GetChild (1).GetChild(0).GetChild (1).GetChild (1).GetComponent<Text> ();
		lvl1Col3 = panel.GetChild (1).GetChild(0).GetChild (1).GetChild (2).GetComponent<Text> ();

		lvl2Col1 = panel.GetChild (1).GetChild(2).GetChild (1).GetChild (0).GetComponent<Text> ();
		lvl2Col2 = panel.GetChild (1).GetChild(2).GetChild (1).GetChild (1).GetComponent<Text> ();
		lvl2Col3 = panel.GetChild (1).GetChild(2).GetChild (1).GetChild (2).GetComponent<Text> ();

		lvl3Col1 = panel.GetChild (1).GetChild(4).GetChild (1).GetChild (0).GetComponent<Text> ();
		lvl3Col2 = panel.GetChild (1).GetChild(4).GetChild (1).GetChild (1).GetComponent<Text> ();
		lvl3Col3 = panel.GetChild (1).GetChild(4).GetChild (1).GetChild (2).GetComponent<Text> ();

		freePoints = panel.GetChild (2).GetChild (1).GetComponent<Text> ();

		StartCoroutine (UpdatePoints ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.S))
		{
			panel.gameObject.SetActive (!panel.gameObject.activeInHierarchy);
		}
		UpdateSkills ();
	}

	public void UpdateSkills()
	{
		lvl1Col1.text = skill.lvl1Col1.ToString();
		lvl1Col2.text = skill.lvl1Col2.ToString();
		lvl1Col3.text = skill.lvl1Col3.ToString();
		lvl2Col1.text = skill.lvl2Col1.ToString();
		lvl2Col2.text = skill.lvl2Col2.ToString();
		lvl2Col3.text = skill.lvl2Col3.ToString();
		lvl3Col1.text = skill.lvl3Col1.ToString();
		lvl3Col2.text = skill.lvl3Col2.ToString();
		lvl3Col3.text = skill.lvl3Col3.ToString();

	}

	IEnumerator UpdatePoints()
	{
		for (;;)
		{
			freePoints.text = player.skillPoints.ToString();
			yield return new WaitForSeconds(0.1f);
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTreeScript : MonoBehaviour {
	
	private PlayerSkills skill;
	private Player player;
	
	private Transform panel;
	private Transform upgradeButton;
	
	private Text lvl1Col1;
	private Text lvl1Col2;
	private Text lvl1Col3;
	private Text lvl2Col1;
	private Text lvl2Col2;
	private Text lvl2Col3;
	private Text lvl3Col1;
	private Text lvl3Col2;
	private Text lvl3Col3;
	
	private Image img1Col1;
	private Image img1Col2;
	private Image img1Col3;
	private Image img2Col1;
	private Image img2Col2;
	private Image img2Col3;
	private Image img3Col1;
	private Image img3Col2;
	private Image img3Col3;
	
	
	private Text freePoints;
	
	// Use this for initialization
	void Start ()
	{
		skill = GameObject.FindGameObjectWithTag ("Skill").GetComponent<PlayerSkills> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		panel = transform.GetChild (0);
		upgradeButton = transform.GetChild (1); 
		
		lvl1Col1 = panel.GetChild (1).GetChild(0).GetChild (1).GetChild (0).GetComponent<Text> ();
		lvl1Col2 = panel.GetChild (1).GetChild(0).GetChild (1).GetChild (1).GetComponent<Text> ();
		lvl1Col3 = panel.GetChild (1).GetChild(0).GetChild (1).GetChild (2).GetComponent<Text> ();
		
		lvl2Col1 = panel.GetChild (1).GetChild(2).GetChild (1).GetChild (0).GetComponent<Text> ();
		lvl2Col2 = panel.GetChild (1).GetChild(2).GetChild (1).GetChild (1).GetComponent<Text> ();
		lvl2Col3 = panel.GetChild (1).GetChild(2).GetChild (1).GetChild (2).GetComponent<Text> ();
		
		lvl3Col1 = panel.GetChild (1).GetChild(4).GetChild (1).GetChild (0).GetComponent<Text> ();
		lvl3Col2 = panel.GetChild (1).GetChild(4).GetChild (1).GetChild (1).GetComponent<Text> ();
		lvl3Col3 = panel.GetChild (1).GetChild(4).GetChild (1).GetChild (2).GetComponent<Text> ();
		
		img1Col1 = panel.GetChild (1).GetChild(0).GetChild (0).GetChild (0).GetComponent<Image> ();
		img1Col2 = panel.GetChild (1).GetChild(0).GetChild (0).GetChild (1).GetComponent<Image> ();
		img1Col3 = panel.GetChild (1).GetChild(0).GetChild (0).GetChild (2).GetComponent<Image> ();
		
		img2Col1 = panel.GetChild (1).GetChild(2).GetChild (0).GetChild (0).GetComponent<Image> ();
		img2Col2 = panel.GetChild (1).GetChild(2).GetChild (0).GetChild (1).GetComponent<Image> ();
		img2Col3 = panel.GetChild (1).GetChild(2).GetChild (0).GetChild (2).GetComponent<Image> ();
		
		img3Col1 = panel.GetChild (1).GetChild(4).GetChild (0).GetChild (0).GetComponent<Image> ();
		img3Col2 = panel.GetChild (1).GetChild(4).GetChild (0).GetChild (1).GetComponent<Image> ();
		img3Col3 = panel.GetChild (1).GetChild(4).GetChild (0).GetChild (2).GetComponent<Image> ();
		
		freePoints = panel.GetChild (2).GetChild (1).GetComponent<Text> ();
		UpdateSkills ();
		StartCoroutine (UpdatePoints ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.N))
		{
			panel.gameObject.SetActive (!panel.gameObject.activeInHierarchy);
		}
		if (player.skillPoints > 0)
			upgradeButton.gameObject.SetActive(true);
		else
			upgradeButton.gameObject.SetActive(false);
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
		
		if (skill.lvl1Col1 == 0 && player.skillPoints == 0)
			img1Col1.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		else
			img1Col1.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		if (skill.lvl1Col2 == 0 && player.skillPoints == 0)
			img1Col2.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		else
			img1Col2.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		if (skill.lvl1Col3 == 0 && player.skillPoints == 0)
			img1Col3.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		else
			img1Col3.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		
		
		if ((skill.lvl2Col1 == 0 && player.skillPoints == 0) || (player.level < 6 || skill.lvl1Col1 < 3))
			img2Col1.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		else
			img2Col1.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		if ((skill.lvl2Col2 == 0 && player.skillPoints == 0) || (player.level < 6 || skill.lvl1Col2 < 3))
			img2Col2.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		else
			img2Col2.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		if ((skill.lvl2Col3 == 0 && player.skillPoints == 0) || (player.level < 6 || skill.lvl1Col3 < 3))
			img2Col3.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		else
			img2Col3.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		
		
		if ((skill.lvl3Col1 == 0 && player.skillPoints == 0) || (player.level < 12 || skill.lvl2Col1 < 3))
			img3Col1.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		else
			img3Col1.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		if ((skill.lvl3Col2 == 0 && player.skillPoints == 0) || (player.level < 12 || skill.lvl2Col2 < 3))
			img3Col2.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		else
			img3Col2.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		if ((skill.lvl3Col3 == 0 && player.skillPoints == 0) || (player.level < 12 || skill.lvl2Col3 < 3))
			img3Col3.color = new Color (0.5f, 0.5f, 0.5f, 0.5f);
		else
			img3Col3.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		
		
	}
	
	IEnumerator UpdatePoints()
	{
		for (;;)
		{
			freePoints.text = player.skillPoints.ToString();
			UpdateSkills();
			yield return new WaitForSeconds(0.1f);
		}
	}
	
	public void UpgradeButton()
	{
		panel.gameObject.SetActive (true);
	}
	
	public void IncLvl1Col1()
	{
		if (player.skillPoints > 0 && skill.lvl1Col1 < 20)
		{
			skill.lvl1Col1++;
			player.skillPoints--;
			UpdateSkills ();
		}
	}
	
	public void IncLvl1Col2()
	{
		if (player.skillPoints > 0 && skill.lvl1Col2 < 20)
		{
			skill.lvl1Col2++;
			player.skillPoints--;
			UpdateSkills ();
		}
	}
	
	public void IncLvl1Col3()
	{
		if (player.skillPoints > 0 && skill.lvl1Col3 < 20)
		{
			skill.lvl1Col3++;
			player.skillPoints--;
			UpdateSkills ();
		}
	}
	
	public void IncLvl2Col1()
	{
		if (player.skillPoints > 0 && skill.lvl2Col1 < 20 && player.level >= 6 && skill.lvl1Col1 >= 3)
		{
			skill.lvl2Col1++;
			player.skillPoints--;
			UpdateSkills ();
		}
	}
	
	public void IncLvl2Col2()
	{
		if (player.skillPoints > 0 && skill.lvl2Col2 < 20 && player.level >= 6 && skill.lvl1Col2 >= 3)
		{
			skill.lvl2Col2++;
			player.skillPoints--;
			UpdateSkills ();
		}
	}
	
	public void IncLvl2Col3()
	{
		if (player.skillPoints > 0 && skill.lvl2Col3 < 20 && player.level >= 6 && skill.lvl1Col3 >= 3)
		{
			skill.lvl2Col3++;
			player.skillPoints--;
			UpdateSkills ();
		}
	}
	
	public void IncLvl3Col1()
	{
		if (player.skillPoints > 0 && skill.lvl3Col1 < 20 && player.level >= 12 && skill.lvl2Col1 >= 3)
		{
			skill.lvl3Col1++;
			player.skillPoints--;
			UpdateSkills ();
		}
	}
	
	public void IncLvl3Col2()
	{
		if (player.skillPoints > 0 && skill.lvl3Col2 < 20 && player.level >= 12 && skill.lvl2Col2 >= 3)
		{
			skill.lvl3Col2++;
			player.skillPoints--;
			UpdateSkills ();
		}
	}
	
	public void IncLvl3Col3()
	{
		if (player.skillPoints > 0 && skill.lvl3Col3 < 20 && player.level >= 12 && skill.lvl2Col3 >= 3)
		{
			skill.lvl3Col3++;
			player.skillPoints--;
			UpdateSkills ();
		}
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTreeScript : MonoBehaviour {

	public static GameObject item;

	private Skill Skill1Col1;
	private Skill Skill1Col2;
	private Skill Skill1Col3;
	private Skill Skill2Col1;
	private Skill Skill2Col2;
	private Skill Skill2Col3;
	private Skill Skill3Col1;
	//private Skill Skill3Col2;
	private Skill Skill3Col3;
	
	private PlayerSkills skill;
	private Player player;

	private Transform skillBar;

	private Image skillQ;
	private Image skillW;
	private Image skillE;
	private Image skillR;
	private Image skillRightMouse;

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

	private bool onLvl1Col1 = false;
	private bool onLvl1Col2 = false;
	private bool onLvl1Col3 = false;
	private bool onLvl2Col1 = false;
	private bool onLvl2Col2 = false;
	private bool onLvl2Col3 = false;
	private bool onLvl3Col1 = false;
	private bool onLvl3Col2 = false;
	private bool onLvl3Col3 = false;

	
	private Text freePoints;
	
	// Use this for initialization
	void Start ()
	{
		skill = GameObject.FindGameObjectWithTag ("Skill").GetComponent<PlayerSkills> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		skillBar = GameObject.FindGameObjectWithTag ("SkillBar").transform;

		Skill1Col1 = skill.transform.GetChild (0).GetComponent<Skill>();
		Skill1Col2 = skill.transform.GetChild (1).GetComponent<Skill>();
		Skill1Col3 = skill.transform.GetChild (2).GetComponent<Skill>();
		Skill2Col1 = skill.transform.GetChild (3).GetComponent<Skill>();
		Skill2Col2 = skill.transform.GetChild (4).GetComponent<Skill>();
		Skill2Col3 = skill.transform.GetChild (5).GetComponent<Skill>();
		Skill3Col1 = skill.transform.GetChild (6).GetComponent<Skill>();
		//Skill3Col2 = skill.transform.GetChild (7).GetComponent<Skill>();
		Skill3Col3 = skill.transform.GetChild (8).GetComponent<Skill>();

		skillQ = skillBar.GetChild (0).GetComponent<Image>();
		skillW = skillBar.GetChild (1).GetComponent<Image>();
		skillE = skillBar.GetChild (2).GetComponent<Image>();
		skillR = skillBar.GetChild (3).GetComponent<Image>();
		skillRightMouse = skillBar.GetChild (4).GetComponent<Image>();

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

		if (Input.GetMouseButtonDown (1))
		{
			if (onLvl1Col1 == true && skill.lvl1Col1 > 0)
			{
				player.skillRightMouse = Skill1Col1;
				skillRightMouse.sprite = img1Col1.sprite;
				skillRightMouse.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl1Col2 == true && skill.lvl1Col2 > 0)
			{
				player.skillRightMouse = Skill1Col2;
				skillRightMouse.sprite = img1Col2.sprite;
				skillRightMouse.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl1Col3 == true && skill.lvl1Col3 > 0)
			{
				player.skillRightMouse = Skill1Col3;
				skillRightMouse.sprite = img1Col3.sprite;
				skillRightMouse.color = new Color (1f, 1f, 1f, 1f);
			}
			
			if (onLvl2Col1 == true && skill.lvl2Col1 > 0)
			{
				player.skillRightMouse = Skill2Col1;
				skillRightMouse.sprite = img2Col1.sprite;
				skillRightMouse.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl2Col2 == true && skill.lvl2Col2 > 0)
			{
				player.skillRightMouse = Skill2Col2;
				skillRightMouse.sprite = img2Col2.sprite;
				skillRightMouse.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl2Col3 == true && skill.lvl2Col3 > 0)
			{
				player.skillRightMouse = Skill2Col3;
				skillRightMouse.sprite = img2Col3.sprite;
				skillRightMouse.color = new Color (1f, 1f, 1f, 1f);
			}
			
			if (onLvl3Col1 == true && skill.lvl3Col1 > 0)
			{
				player.skillRightMouse = Skill3Col1;
				skillRightMouse.sprite = img3Col1.sprite;
				skillRightMouse.color = new Color (1f, 1f, 1f, 1f);
			}
			/*else if (onLvl3Col2 == true && skill.lvl3Col2 > 0)
			{
				player.skillRightMouse = Skill3Col2;
				skillRightMouse.sprite = img3Col2.sprite;
				skillRightMouse.color = new Color (1f, 1f, 1f, 1f);
			}*/
			else if (onLvl3Col3 == true && skill.lvl3Col3 > 0)
			{
				player.skillRightMouse = Skill3Col3;
				skillRightMouse.sprite = img3Col3.sprite;
				skillRightMouse.color = new Color (1f, 1f, 1f, 1f);
			}
		}

		if (Input.GetKeyDown (KeyCode.Q))
		{
			if (onLvl1Col1 == true && skill.lvl1Col1 > 0)
			{
				player.skillQ = Skill1Col1;
				skillQ.sprite = img1Col1.sprite;
				skillQ.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl1Col2 == true && skill.lvl1Col2 > 0)
			{
				player.skillQ = Skill1Col2;
				skillQ.sprite = img1Col2.sprite;
				skillQ.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl1Col3 == true && skill.lvl1Col3 > 0)
			{
				player.skillQ = Skill1Col3;
				skillQ.sprite = img1Col3.sprite;
				skillQ.color = new Color (1f, 1f, 1f, 1f);
			}

			if (onLvl2Col1 == true && skill.lvl2Col1 > 0)
			{
				player.skillQ = Skill2Col1;
				skillQ.sprite = img2Col1.sprite;
				skillQ.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl2Col2 == true && skill.lvl2Col2 > 0)
			{
				player.skillQ = Skill2Col2;
				skillQ.sprite = img2Col2.sprite;
				skillQ.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl2Col3 == true && skill.lvl2Col3 > 0)
			{
				player.skillQ = Skill2Col3;
				skillQ.sprite = img2Col3.sprite;
				skillQ.color = new Color (1f, 1f, 1f, 1f);
			}

			if (onLvl3Col1 == true && skill.lvl3Col1 > 0)
			{
				player.skillQ = Skill3Col1;
				skillQ.sprite = img3Col1.sprite;
				skillQ.color = new Color (1f, 1f, 1f, 1f);
			}
			/*else if (onLvl3Col2 == true && skill.lvl3Col2 > 0)
			{
				player.skillQ = Skill3Col2;
				skillQ.sprite = img3Col2.sprite;
			}*/
			else if (onLvl3Col3 == true && skill.lvl3Col3 > 0)
			{
				player.skillQ = Skill3Col3;
				skillQ.sprite = img3Col3.sprite;
				skillQ.color = new Color (1f, 1f, 1f, 1f);
			}
		}

		if (Input.GetKeyDown (KeyCode.W))
		{
			if (onLvl1Col1 == true && skill.lvl1Col1 > 0)
			{
				player.skillW = Skill1Col1;
				skillW.sprite = img1Col1.sprite;
				skillW.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl1Col2 == true && skill.lvl1Col2 > 0)
			{
				player.skillW = Skill1Col2;
				skillW.sprite = img1Col2.sprite;
				skillW.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl1Col3 == true && skill.lvl1Col3 > 0)
			{
				player.skillW = Skill1Col3;
				skillW.sprite = img1Col3.sprite;
				skillW.color = new Color (1f, 1f, 1f, 1f);
			}
			
			if (onLvl2Col1 == true && skill.lvl2Col1 > 0)
			{
				player.skillW = Skill2Col1;
				skillW.sprite = img2Col1.sprite;
				skillW.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl2Col2 == true && skill.lvl2Col2 > 0)
			{
				player.skillW = Skill2Col2;
				skillW.sprite = img2Col2.sprite;
				skillW.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl2Col3 == true && skill.lvl2Col3 > 0)
			{
				player.skillW = Skill2Col3;
				skillW.sprite = img2Col3.sprite;
				skillW.color = new Color (1f, 1f, 1f, 1f);
			}
			
			if (onLvl3Col1 == true && skill.lvl3Col1 > 0)
			{
				player.skillW = Skill3Col1;
				skillW.sprite = img3Col1.sprite;
				skillW.color = new Color (1f, 1f, 1f, 1f);
			}
			/*else if (onLvl3Col2 == true && skill.lvl3Col2 > 0)
			{
				player.skillW = Skill3Col2;
				skillW.sprite = img3Col2.sprite;
				skillW.color = new Color (1f, 1f, 1f, 1f);
			}*/
			else if (onLvl3Col3 == true && skill.lvl3Col3 > 0)
			{
				player.skillW = Skill3Col3;
				skillW.sprite = img3Col3.sprite;
				skillW.color = new Color (1f, 1f, 1f, 1f);
			}
		}

		if (Input.GetKeyDown (KeyCode.E))
		{
			if (onLvl1Col1 == true && skill.lvl1Col1 > 0)
			{
				player.skillE = Skill1Col1;
				skillE.sprite = img1Col1.sprite;
				skillE.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl1Col2 == true && skill.lvl1Col2 > 0)
			{
				player.skillE = Skill1Col2;
				skillE.sprite = img1Col2.sprite;
				skillE.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl1Col3 == true && skill.lvl1Col3 > 0)
			{
				player.skillE = Skill1Col3;
				skillE.sprite = img1Col3.sprite;
				skillE.color = new Color (1f, 1f, 1f, 1f);
			}
			
			if (onLvl2Col1 == true && skill.lvl2Col1 > 0)
			{
				player.skillE = Skill2Col1;
				skillE.sprite = img2Col1.sprite;
				skillE.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl2Col2 == true && skill.lvl2Col2 > 0)
			{
				player.skillE = Skill2Col2;
				skillE.sprite = img2Col2.sprite;
				skillE.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl2Col3 == true && skill.lvl2Col3 > 0)
			{
				player.skillE = Skill2Col3;
				skillE.sprite = img2Col3.sprite;
				skillE.color = new Color (1f, 1f, 1f, 1f);
			}
			
			if (onLvl3Col1 == true && skill.lvl3Col1 > 0)
			{
				player.skillE = Skill3Col1;
				skillE.sprite = img3Col1.sprite;
				skillE.color = new Color (1f, 1f, 1f, 1f);
			}
			/*else if (onLvl3Col2 == true && skill.lvl3Col2 > 0)
			{
				player.skillE = Skill3Col2;
				skillE.sprite = img3Col2.sprite;
				skillE.color = new Color (1f, 1f, 1f, 1f);
			}*/
			else if (onLvl3Col3 == true && skill.lvl3Col3 > 0)
			{
				player.skillE = Skill3Col3;
				skillE.sprite = img3Col3.sprite;
				skillE.color = new Color (1f, 1f, 1f, 1f);
			}
		}

		if (Input.GetKeyDown (KeyCode.R))
		{
			if (onLvl1Col1 == true && skill.lvl1Col1 > 0)
			{
				player.skillR = Skill1Col1;
				skillR.sprite = img1Col1.sprite;
				skillR.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl1Col2 == true && skill.lvl1Col2 > 0)
			{
				player.skillR = Skill1Col2;
				skillR.sprite = img1Col2.sprite;
				skillR.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl1Col3 == true && skill.lvl1Col3 > 0)
			{
				player.skillR = Skill1Col3;
				skillR.sprite = img1Col3.sprite;
				skillR.color = new Color (1f, 1f, 1f, 1f);
			}
			
			if (onLvl2Col1 == true && skill.lvl2Col1 > 0)
			{
				player.skillR = Skill2Col1;
				skillR.sprite = img2Col1.sprite;
				skillR.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl2Col2 == true && skill.lvl2Col2 > 0)
			{
				player.skillR = Skill2Col2;
				skillR.sprite = img2Col2.sprite;
				skillR.color = new Color (1f, 1f, 1f, 1f);
			}
			else if (onLvl2Col3 == true && skill.lvl2Col3 > 0)
			{
				player.skillR = Skill2Col3;
				skillR.sprite = img2Col3.sprite;
				skillR.color = new Color (1f, 1f, 1f, 1f);
			}
			
			if (onLvl3Col1 == true && skill.lvl3Col1 > 0)
			{
				player.skillR = Skill3Col1;
				skillR.sprite = img3Col1.sprite;
				skillR.color = new Color (1f, 1f, 1f, 1f);
			}
			/*else if (onLvl3Col2 == true && skill.lvl3Col2 > 0)
			{
				player.skillR = Skill3Col2;
				skillR.sprite = img3Col2.sprite;
				skillR.color = new Color (1f, 1f, 1f, 1f);
			}*/
			else if (onLvl3Col3 == true && skill.lvl3Col3 > 0)
			{
				player.skillR = Skill3Col3;
				skillR.sprite = img3Col3.sprite;
				skillR.color = new Color (1f, 1f, 1f, 1f);
			}
		}


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

	public void OnLvl1Col1()
	{
		onLvl1Col1 = true;
	}

	public void OffLvl1Col1()
	{
		onLvl1Col1 = false;
	}

	public void OnLvl1Col2()
	{
		onLvl1Col2 = true;
	}
	
	public void OffLvl1Col2()
	{
		onLvl1Col2 = false;
	}

	public void OnLvl1Col3()
	{
		onLvl1Col3 = true;
	}
	
	public void OffLvl1Col3()
	{
		onLvl1Col3 = false;
	}

	public void OnLvl2Col1()
	{
		onLvl2Col1 = true;
	}
	
	public void OffLvl2Col1()
	{
		onLvl2Col1 = false;
	}
	
	public void OnLvl2Col2()
	{
		onLvl2Col2 = true;
	}
	
	public void OffLvl2Col2()
	{
		onLvl2Col2 = false;
	}
	
	public void OnLvl2Col3()
	{
		onLvl2Col3 = true;
	}
	
	public void OffLvl2Col3()
	{
		onLvl2Col3 = false;
	}

	public void OnLvl3Col1()
	{
		onLvl3Col1 = true;
	}
	
	public void OffLvl3Col1()
	{
		onLvl3Col1 = false;
	}
	
	public void OnLvl3Col2()
	{
		onLvl3Col2 = true;
	}
	
	public void OffLvl3Col2()
	{
		onLvl3Col2 = false;
	}
	
	public void OnLvl3Col3()
	{
		onLvl3Col3 = true;
	}
	
	public void OffLvl3Col3()
	{
		onLvl3Col3 = false;
	}
}
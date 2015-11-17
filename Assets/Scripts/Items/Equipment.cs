using UnityEngine;
using System.Collections;

public class Equipment : MonoBehaviour
{
	[HideInInspector]public int			level;
	[HideInInspector]public string		name;
	[HideInInspector]public float		attack_speed;
	[HideInInspector]public float		dmg;
	public Sprite						sprite;
}

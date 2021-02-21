using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Spells
{
	public string name;
	public TextMeshProUGUI description;
	public int id;
	public float dmg;
	// Add other stuff later

	public Spells(Spells c)
	{
		name = c.name;
		description = c.description;
		id = c.id;
		dmg = c.dmg;
	}
}

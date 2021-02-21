using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpells_System : MonoBehaviour
{
	// AllSpells can be changed if we want to 
	// create specific instruments for specific spells
    public Spells[] PlayerSpells;
	public Spells[] AllSpells;

	private void Start()
	{ 
		// Just assign all the spells, no system in-place to choose when spells are learned.
		for (int i = 0; i < 10; ++i)
		{
			PlayerSpells[i].id = AllSpells[i].id;
			PlayerSpells[i].name = AllSpells[i].name;
			PlayerSpells[i].description = AllSpells[i].description;
			PlayerSpells[i].dmg = AllSpells[i].dmg;
		}
	}
}

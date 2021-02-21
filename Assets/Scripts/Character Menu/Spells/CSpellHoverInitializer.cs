using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// UI manager system needs to come in later and get/set a lot of these things. I can create a separte file to control all of the list objects
/// and directly take information from one source, instead of having all this information spread out.
/// </summary>
public class CSpellHoverInitializer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public CSpellHoverComponent HoverComponent;
	public CSpells_System SpellSystem;
	public SpellAutoComplete AutoComplete;

	public Spells AllSpells;

	// This is temporary. Description in spells should be accessed by changing the component inside the seralizable TMP prefab.
	public string HoverDesc = "";

	// Sets serialized info on creation of our object. ShowToolTip reads this information
	public void GetSpellInfo(int Index)
	{
		// We can possibly remove this list if we check against an array of actual spells (once spell system is complete)
		List<string> Name = new List<string>() {
			"<color=#e58b09>Oil Spill</color>", "<color=#bb39cf>Teleport</color>", "<color=#db470f>Fireball</color>",
			"<color=#0fb6db>Iceburst</color>", "Spell 5", "Spell 6",
			"Spell 7", "Spell 8", "Spell 9",
			"Spell 10", "Spell 11",};

		List<string> Description = new List<string>() {
			"<sprite=2> Incapacitates the target causing them to randomly slip \nand be stunned for up to <color=#42ddff>2s</color>. <color=#db470f>Fire</color> spells cause a burning effect.",
			"Teleports the Bard to a new tower. ",
			"Strikes the target for <color=#db470f>15 fire damage</color>. (<- need icon here) ",
			"Deals <color=#0fb6db>5 frost damage</color> and freezes targets for up to <color=#42ddff>1s </color>. \nAll ground in target area will cause enemies to randomly slip and be stunned for up to <color=#42ddff>1s </color>.",
			"Spell 5", "Spell 6",
			"Spell 7", "Spell 8", "Spell 9",
			"Spell 10", "Spell 11",};

		AllSpells.id = Index;
		AllSpells.name = Name[Index];
		HoverDesc = Description[Index];
	}

	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		Debug.Log("Cursor entering " + name + " GameObject");
		HoverComponent.ShowToolTip("<b><size=200%>" + AllSpells.name + "</size></b>" + "\n" + HoverDesc);
	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
		Debug.Log("Cursor leaving " + name + " GameObject");
		HoverComponent.HideToolTip();
	}










	//private void onEnter()
	//{
	//	isShow = true;
	//}

	//private void onExit()
	//{
	//	isShow = false;
	//}

	//private void UpdateToolTip()
	//{
	//	if (isShow)
	//	{
	//		HoverComponent.ShowToolTip("<b><size=200%>" + AllSpells.name + "</size></b>" + "\n" + HoverDesc);
	//	}
	//	else
	//	{
	//		HoverComponent.HideToolTip();
	//	}
	//}

}


// OnPointEnter old system. For reference
//
//
// THIS SYSTEM IS GHETTO AS FUCK. 
// I COULDN'T FIGURE OUT A PROPER WAY TO ORGANIZE THIS WITHOUT RE-DOING THE SPELL SYSTEM. WOULD TAKE A LOT OF REFACTORING.
// THE PROPER WAY IS TO ASSIGN THE GAME OBJECTS WITH THE ACTUAL TEXT, BUT I JUST DON'T CARE ENOUGH TO FIX IT.
//switch (gameObject.name)
//{
//	case "0":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[0].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[0].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[0].id);
//		break;
//	case "1":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[1].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[1].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[1].id);
//		break;
//	case "2":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[2].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[1].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[2].id);
//		break;
//	case "3":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[3].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[3].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[3].id);
//		break;
//	case "4":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[4].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[4].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[4].id);
//		break;
//	case "5":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[5].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[5].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[5].id);
//		break;
//	case "6":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[6].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[6].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[6].id);
//		break;
//	case "7":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[7].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[7].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[7].id);
//		break;
//	case "8":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[8].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[8].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[8].id);
//		break;
//	case "9":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[9].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[9].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[9].id);
//		break;
//	case "10":
//		HoverComponent.ShowToolTip("Spell name: " + SpellSystem.PlayerSpells[10].name + "\n" +
//		"Spell description: " + SpellSystem.PlayerSpells[10].description + "\n" +
//		"Spell id: " + SpellSystem.PlayerSpells[10].id);
//		break;
//}

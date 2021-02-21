using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpellInput : MonoBehaviour
{
	// Example of spell ID list. 
	//	1. Elements can be randomized when calling awake() function.
	//	2. This is simply a test, we can treat these as a spell ID and match it to the spell in a different array.
	public List<string> SpellList = new List<string>() { "qweqr", "qqrwe", "qqrrw", "qqqrr", "reweq", "rweqq", "eeweq", "weqee", "wwerr", "eewee", "eqrew" };

	// Check if spell is found state
	private static bool SpellFound = false;

	public GameObject SpellCanvas;
	public Image Note4, Note8, Note16, Note32;
	public Image CloneImage;
	//public GameObject clone;

	// Object Distance positioner
	private float xDistance = -60.0f;
	private int ObjectCounter = 0;

	// Unused yDistance for objects
	// -> private float yDistance = 0.0f;

	// Include our spell script
	public SpellSuccess SpellSucScript;
	public SpellController SpellController;



	public void ReadSpellInput(string KeyInput)
	{
		// We check to see if spell is actually found.
		for (int i = 0; i < SpellList.Count; ++i)
		{
			if (KeyInput == SpellList[i])
			{
				SpellFound = true;
			}
		}
		
		// we output if the spell is found or not
		if (SpellFound)
		{
			Debug.Log(KeyInput + " was found in the spell list.");
			SpellController.CastSpell(KeyInput);
			CastSpellClear('a');
			SpellFound = false;
		}
		else
		{
			Debug.Log(KeyInput + " was not found in the spell list.");
			CastSpellClear('x');
			SpellFound = false;
		}
	}

	public void DisplaySpellInput(string KeyInput)
	{
		Debug.Log("DisplaySpellInput(string) function called");

		// Randomizes location for the yPos.
		List<float> yPos = new List<float>() { -10.0f, 0.0f, 15.0f, 20.0f };
		System.Random random = new System.Random();
		int r = random.Next(yPos.Count);


		if (ObjectCounter < 5)
		{
			switch (KeyInput)
			{
				case "q":
					Debug.Log("q");
					CloneImage = Instantiate(Note4, Vector3.zero, Quaternion.identity);
					CloneImage.transform.SetParent(SpellCanvas.transform, false);
					CloneImage.rectTransform.anchoredPosition = new Vector2(xDistance, yPos[r]); // New object position
					//CloneImage.transform.gameObject.SetActive(true); // Can sit outside of switch statement -- sets object active. == KEEP DISABLED. TESTING PURPOSES
					break;
				case "w":
					Debug.Log("w");
					CloneImage = Instantiate(Note8, Vector3.zero, Quaternion.identity);
					CloneImage.transform.SetParent(SpellCanvas.transform, false);
					CloneImage.rectTransform.anchoredPosition = new Vector2(xDistance, yPos[r]); // New object position
					break;
				case "e":
					Debug.Log("e");
					CloneImage = Instantiate(Note16, Vector3.zero, Quaternion.identity);
					CloneImage.transform.SetParent(SpellCanvas.transform, false);
					CloneImage.rectTransform.anchoredPosition = new Vector2(xDistance, yPos[r]); // New object position
					break;
				case "r":
					Debug.Log("r");
					CloneImage = Instantiate(Note32, Vector3.zero, Quaternion.identity);
					CloneImage.transform.SetParent(SpellCanvas.transform, false);
					CloneImage.rectTransform.anchoredPosition = new Vector2(xDistance, yPos[r]); // New object position
					break;
			}
			// Change x location
			xDistance += 30.0f;
			++ObjectCounter;
		}
	}

	// Spell cancelled with Z
	public void DisplaySpellClear(char KeyInput)
	{
		foreach(Transform child in transform)
		{
			Destroy(child.gameObject);
			xDistance = -60.0f;
			ObjectCounter = 0;
		}
		// Call our text fader
		SpellSucScript.CallFade(KeyInput);
	}

	// Spell casted with A
	public void CastSpellClear(char KeyInput)
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
			xDistance = -60.0f;
			ObjectCounter = 0;
		}
		if (SpellFound)
		{
			SpellSucScript.CallFade(KeyInput);
		}
		else if (!SpellFound)
		{
			SpellSucScript.CallFade(KeyInput);
		}
	}
}

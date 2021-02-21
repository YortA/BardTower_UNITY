using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine.EventSystems;

public class SpellAutoComplete : MonoBehaviour
{
	public SpellInput SpellScript;
	public RectTransform prefab;
	public RectTransform prefabSpell;
	public RectTransform resultsParent;

	public CSpellHoverInitializer CSpellHover;
	public CSpellHoverComponent CSpellHoverComponent;

	// Track auto complete
	public void TrackWords(string AutoComplete)
	{
		// Reset bottom location of text
		float yDistance = -30.0f;
		//string SpellTMP = "";
		// We need a list to keep track of our inputs
		List<string> a_CompleteList = new List<string>();
		// We reset check number for the amount of times we check the list
		int CheckNumber = 0;
		// Call destroy to remove incorrect values
		DestroyWords();
		

		// Match our inputs
		foreach (string match in SpellScript.SpellList)
		{
			if (match.StartsWith(AutoComplete))
			{
				a_CompleteList.Add(match);
				++CheckNumber;
			}
		}
		// Create our autocomplete text objects
		for (int i = 0; i < a_CompleteList.Count; ++i)
		{
			// Color change for our input
			List<string> a_ColorList = new List<string>();

			if (a_CompleteList[i].StartsWith(AutoComplete))
			{
				string[] s1 = Regex.Split(a_CompleteList[i], string.Empty);
				foreach (string s in s1)
				{
					a_ColorList.Add(s);
				}
				// Add our color to our inputs
				// .Length +2 because 0 = color, 1 = first value; therefore +2 = 2nd element.
				a_ColorList.Insert(0, "<color=#6519d8>");
				a_ColorList.Insert(1, "(");
				a_ColorList.Insert(2, "</color>");
				a_ColorList.Insert(3, "<color=white>");
				a_ColorList.Insert(AutoComplete.Length + 5, "</color>");
				// We use "1"  because each time we add a new value, we backtrack. Yeah, it looks dumb -- I know.
				a_ColorList.Insert(a_ColorList.Count - 1, "<color=#6519d8>");
				a_ColorList.Insert(a_ColorList.Count - 1, ")");
				a_ColorList.Insert(a_ColorList.Count - 1, "</color>");
			}
			string ColorAutoComplete = String.Join<string>("", a_ColorList);

			CreateSpellTMP(a_CompleteList[i], yDistance);

			RectTransform child = Instantiate(prefab) as RectTransform;
			// Remember to set parent so we can move position inside the container
			child.SetParent(resultsParent);
			child.anchoredPosition = new Vector2(45.0f, yDistance);
			child.GetComponentInChildren<Text>().text = ColorAutoComplete;
			yDistance += 40.0f;
		}

		Debug.Log(CheckNumber);
	}
	
	// Destroy the autocomplete objects
	public void DestroyWords()
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
			CSpellHoverComponent.HideToolTip();
		}
	}

	// Match Icons & Spells to autocomplete text
	// ### Refactoring ###
	// We need to attach the RectTransform to the anchorpoint of the TrackWords anchor point.
	public void CreateSpellTMP(string SpellSearch, float yDistance)
	{
		// All list locations must match specific spells. So, QWEQR is [1] in the SpellList, therefore, Oil Spill[1] should match it.
		List<string> a_TMPSpell = new List<string>() { 
			"<sprite=2>Oil Spill", "<sprite=3>Teleport", "<sprite=10>Fireball", 
			"<sprite=2>Iceburst", "<sprite=2>Oil Spill5", "<sprite=2>Oil Spill 6",
			"<sprite=2>Oil Spill 7", "<sprite=2>Oil Spill 8", "<sprite=2>Oil Spill 9",
			"<sprite=2>Oil Spill 10", "<sprite=2>Oil Spill 11",};
		

		for (int i = 0; i < SpellScript.SpellList.Count; ++i)
		{
			if (SpellSearch == SpellScript.SpellList[i])
			{
				CSpellHover.GetSpellInfo(i);
				RectTransform spellchild = Instantiate(prefabSpell) as RectTransform;
				// Remember to set parent so we can move position inside the container
				spellchild.SetParent(resultsParent);
				spellchild.anchoredPosition = new Vector2(-150.0f, yDistance + 155.5f);
				spellchild.name = a_TMPSpell[i] + " " + i;
				// a_TMPSpell must match our spelllist index size, otherwise we get an out-of-range error.
				spellchild.GetComponentInChildren<TextMeshProUGUI>().text = a_TMPSpell[i];
			}
		}
	}
}

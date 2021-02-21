using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CMenuScript : MonoBehaviour
{

	// Character Menu States
	public enum MenuStates { CMain, CSpells };
	public static MenuStates CurrentState;

	// Menu objects
	public GameObject CMainMenu;
	public GameObject CSpellMenu;
	// public GameObject CBuildMenu;

	// List for spell inputs
	public List<string> KeyboardInputs = new List<string>();

	// Count how many inputs for spells
	public int InputCounter = 0;

	// Call Spellinput
	public SpellInput SpellScript;
	public SpellAutoComplete SpellComplete;

	// Global string for autocompletion
	private string AutoComplete = "";

	// Intiailize script
	void Awake()
	{
		// Sets first menu
		CurrentState = MenuStates.CMain;

	}

	void Update()
	{
		// Check current menu states
		// Set active game object for menus
		switch (CurrentState)
		{
			case MenuStates.CMain:
				CMainMenu.SetActive(true);
				CSpellMenu.SetActive(false);
				break;
			case MenuStates.CSpells:
				CSpellMenu.SetActive(true);
				CMainMenu.SetActive(false);
				break;
		}
		
	}

	public void OnSpellMenu()
	{
		Debug.Log("You've selected the spell menu.");

		// Change to spell menu state
		CurrentState = MenuStates.CSpells;
	}

	public void CancelMenu()
	{
		// Checks for spell menu and clears everything
		if(CurrentState == MenuStates.CSpells)
		{
			AutoComplete = "";
			SpellComplete.DestroyWords();
			InputCounter = 0;
			KeyboardInputs.Clear();
			SpellScript.DisplaySpellClear('z');
			Debug.Log("Cancelled Spell Menu : All inputs cleared.");
		}

		// Return to main menu state
		CurrentState = MenuStates.CMain;
	}

	public void SelectSpellMenu()
	{
		// Change to a switch statement later. Too lazy
		if (CurrentState == MenuStates.CSpells && InputCounter < 5)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				SpellScript.DisplaySpellInput("q");
				KeyboardInputs.Add("q");
				++InputCounter;
			}
			if (Input.GetKeyDown(KeyCode.W))
			{
				SpellScript.DisplaySpellInput("w");
				KeyboardInputs.Add("w");
				++InputCounter;
			}
			if (Input.GetKeyDown(KeyCode.E))
			{
				SpellScript.DisplaySpellInput("e");
				KeyboardInputs.Add("e");
				++InputCounter;
			}
			if (Input.GetKeyDown(KeyCode.R))
			{
				SpellScript.DisplaySpellInput("r");
				KeyboardInputs.Add("r");
				++InputCounter;
			}
			// Used to track our inputs. Don't go over 5.
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			// Accept spell if inputs are equal to 5
			if (InputCounter == 5)
			{
				// Clear our autocomplete
				AutoComplete = "";
				SpellComplete.DestroyWords();
				// Change ASpellState for "A" sound change.
				CMenuSounds.ASpellState = true;
				
				// Concatinate the inputs into a string and check it against the spell list in SpellInput.cs
				string SpellKeyInput = String.Join<string>("", KeyboardInputs);
				Debug.Log("You input: " + SpellKeyInput + "Input Counter: " + InputCounter);
				SpellScript.ReadSpellInput(SpellKeyInput);

				// Clear counters for next input
				InputCounter = 0;
				KeyboardInputs.Clear();
				Debug.Log("All inputs cleared.");

				// Set menu back to main -- We can change this later and have it clear the shown inputs
				CurrentState = MenuStates.CMain;

			}
			// Not enough inputs, place "not enough inputs" in SpellSuccess.cs later
			else
			{
				Debug.Log("Insufficient amount of inputs: " + InputCounter);
			}
		}
		if(InputCounter != 0)
		{
			AutoComplete = String.Join<string>("", KeyboardInputs);
			SpellComplete.TrackWords(AutoComplete);
		}
	}
}

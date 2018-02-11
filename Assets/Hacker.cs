using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Hacker : MonoBehaviour {
	// Game state
	int level;
	enum Screen
	{
		MainMenu,
		Password,
		Win
	}
	Screen _currentScreen = Screen.MainMenu;

	// Use this for initialization
	void Start () {
		ShowMainMenu();
	}

	void ShowMainMenu()
	{
		Terminal.ClearScreen();
		Terminal.WriteLine("Hello Ben");
        		Terminal.WriteLine("What would you like to hack into?\n\nPress 1 for the teacher's classroon\nPress 2 for Professor's office\nPress 3 for the principal's guesthouse\n\nEnter your selection");
	}

	
	void OnUserInput(string input)
	{
		if (input == "menu") {
			ShowMainMenu();
			_currentScreen = Screen.MainMenu;
		}

		if (_currentScreen == Screen.MainMenu){
			RunMainMenu(input);
		}

		if (_currentScreen == Screen.Password) {
			GuessPassword(input);
		}
	}

	void GuessPassword(string input) {
		string[] easy = {"table","pencil",""}
	}

	void RunMainMenu(string input)
	{
		if (input == "007"){
			Terminal.WriteLine("Please select a level, Mr. Bond");
		}
		else if (input == "1")
		{
			level = 1;
			StartGame();
			_currentScreen = Screen.Password;
		}
		else if (input == "2")
		{
			level = 2;
			StartGame();
			_currentScreen = Screen.Password;
		}
		else if (input == "3")
		{
			level = 3;
			StartGame();
			_currentScreen = Screen.Password;
		}
		else if (input == "menu")
		{
			ShowMainMenu();
			_currentScreen = Screen.MainMenu;
		}
	}

	void StartGame()
	{
		Terminal.WriteLine("You have chosen level "+level);
	}

	// Update is called once per frame
	void Update () { 
		
	}
}

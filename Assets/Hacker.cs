using UnityEngine;

public class Hacker : MonoBehaviour {
	// Game configuration
	private string[] level1Password = {"addition", "drawing", "pencil", "blackboard", "eraser"};
	private string[] level2Password = {"geology", "metaphor", "Napoleon", "quadratic", "cardio"};
	private string[] level3Password = {"renaissence", "calculus", "template", "algorithm", "artifical intelligence"};
	
	// Game state
	private int mainMenuRepeatingTimes = 0;
	private int passwordReatingTimes = 0;
	private string _menuHint = "If you can't solve it, feel free to type 'menu' to go back to the main menu";
	private int _level;
	private enum Screen {
		MainMenu,
		Password,
		Win
	}

	private Screen _currentScreen;
	private string _password;

	// Use this for initialization
	private void Start () {
		ShowMainMenu();
	}

	private void ShowMainMenu() {
		_currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("Hello Ben");
        Terminal.WriteLine("What would you like to hack into?\n\nPress 1 for the teacher's classroon\nPress 2 for Professor's office\nPress 3 for the principal's guesthouse\n\nEnter your selection");
	}

	
	void OnUserInput(string input) {
		
		if (input == "menu") {
			ShowMainMenu();
			mainMenuRepeatingTimes = 0;
			passwordReatingTimes = 0;
			_currentScreen = Screen.MainMenu;
		}
		else if (input == "close" || input == "quit" || input == "exit") {
			Terminal.WriteLine("If you are on a web, close the web tab");
		}

		
		if (_currentScreen == Screen.MainMenu) {
			mainMenuRepeatingTimes++;
			passwordReatingTimes = 0;
			RunMainMenu(input);
		}

		else if (_currentScreen == Screen.Password) {
			Terminal.ClearScreen();
			CheckPassword(input);
			passwordReatingTimes++;
			mainMenuRepeatingTimes = 0;
		}
		if ((mainMenuRepeatingTimes >= 3 || passwordReatingTimes >= 3) && _currentScreen!=Screen.Win) {
        			Terminal.WriteLine(_menuHint);
        		}
	}
	void RunMainMenu(string input) {
		bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
		if (isValidLevelNumber) {
			Terminal.ClearScreen();
			_level = int.Parse(input);
			AskForPassword();
		} else {
			switch (input) {
				case "007":	// easter egg
					Terminal.WriteLine("Please select a level, Mr. Bond");
					break;
				default:
					Debug.LogError("Invalid level number");
					break;
			}
		}
		}

	void AskForPassword() {
		print(level1Password.Length);
		_currentScreen = Screen.Password;
		SetRandomPassword();
		Terminal.WriteLine("Please enter your password hint : "+_password.Anagram());
	}

	private void SetRandomPassword() {
		switch (_level) {
			case 1:
				_password = level1Password[Random.Range(0, level1Password.Length)];
				break;
			case 2:
				_password = level2Password[Random.Range(0, level2Password.Length)];
				break;
			case 3:
				_password = level3Password[Random.Range(0, level3Password.Length)];
				break;
		}
	}

	void CheckPassword(string input) {
		if (input == _password) {
			DisplayWinScreen();
		} else {
			Terminal.WriteLine("Sorry, wrong password");
			AskForPassword();
		}
	}

	void DisplayWinScreen() {
		Terminal.ClearScreen();
		_currentScreen = Screen.Win;
		Terminal.WriteLine("Congratulations! You successfully dicipher the code.");
		ShowLevelReward();
	}

	private void ShowLevelReward() {
		switch (_level) {
			case 1:
				Terminal.WriteLine("Have a book");
				Terminal.WriteLine(@"
    ______
   /    //
  /    //
 /____//
(____(/
");
				break;
			case 2:
				Terminal.WriteLine("You got a prison key");
				Terminal.WriteLine(@"
 __
/0 \________
\__/-='-='-
");
				break;
			case 3:
				Terminal.WriteLine("You can go to Mars now");
				Terminal.WriteLine(@"
  /\
  ||
  ||
 /__\
  ||
");
				break;
			default:
				Debug.LogError("Invalid level reached");
				break;
		}
		Terminal.WriteLine("You can type 'menu' to choose a more diffcult level for challenge");
	}

	

	

	// Update is called once per frame
	void Update () {
		
	}
}

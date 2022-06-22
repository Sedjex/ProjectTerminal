using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    enum Screen { MainMenu, Password, Win };

    Screen currentScreen = Screen.MainMenu;
    
    const string menuHint = "Напишіть ʼменюʼ щоб повернутися в меню.";
    int level;
    string password;
    
    string[] Level1Password = { "ключ", "книга", "папір", "олівець", "ручка" };
    string[] Level2Password = { "пістолет", "автомат", "байрактар", "гаубиця", "джавелін" };
    string[] Level3Password = { "інтерстеллар", "аполлон-13", "ентерпрайз", "лексс", "елізіум" };
    
    void Start()
    {
        ShowMainMenu("Гравець,");
    }

    void ShowMainMenu(string playerName)
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        
        Terminal.ClearScreen();
        Terminal.WriteLine(playerName + "\nякий термінал ви хотіли б взломати?");
        Terminal.WriteLine("\n1 - міська бібліотека");
        Terminal.WriteLine("2 - оружейна");
        Terminal.WriteLine("3 - шаттл");
        Terminal.WriteLine("\nЗробіть вибір ...");
    }


    void OnUserInput(string input)
    {
        if (input == "меню")
        {
            ShowMainMenu("Раді бачити вас знов, ");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    
    void GameStart()
    {
    Terminal.ClearScreen();
    currentScreen = Screen.Password;

    switch (level)

        {
            case 1:
                password = Level1Password[Random.Range(0,Level1Password.Length)];
                Terminal.WriteLine("Ви у міській бібліотеці");
                break;
            case 2:
                password = Level2Password[Random.Range(0,Level2Password.Length)];
                Terminal.WriteLine("Ви в оружейній");
                break;
            case 3:
                password = Level3Password[Random.Range(0,Level3Password.Length)];
                Terminal.WriteLine("Ви у космічному шаттлі");
                break;
            default:
                Debug.LogError("Такого рівня не існує");
                break;
        }
        
        Terminal.WriteLine("Підказка: " + password.Anagram());
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Введіть пароль: ");
    }

    void RunMainMenu(string input)
    {
        bool isValideLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValideLevelNumber)
        {
            level = int.Parse(input);
            GameStart();
        }
        else
        {
            Terminal.WriteLine("Введіть значення від 1 до 3 або меню");
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
              ShowWinScreen();
        }
        else
        {
           GameStart();
        }
    }

    void ShowWinScreen()
    {
        Terminal.ClearScreen();
        Reward();
    }

    void Reward()
    {
    currentScreen = Screen.Win;
    
    switch(level)
        {
           case 1:
           Terminal.WriteLine("Пароль вірний! Ось ваша книга: ");
           Terminal.WriteLine(@"
      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\      
 //________.|.________\\     
`----------`-'----------' ");
           break; 
           
           case 2:
           Terminal.WriteLine("Пароль вірний!");
           Terminal.WriteLine(@"
      (( /========\
      __/__________\____________n_
  (( /              \_____________]Піу!
    /  =(*)=          \
    |_._._._._._._._._.| ");
           break;

           case 3:
           Terminal.WriteLine("Пароль вірний! Полетіли!");
           Terminal.WriteLine(@"
     |     | |
    / \    | |
   |--o|===|-|
   |---|   | |
  /     \  | |
 |       |=| |
 |_______| |_|
  |@| |@|  | |
___________|_|_ ");
           break;
        }
        Terminal.WriteLine(menuHint);
    }
}

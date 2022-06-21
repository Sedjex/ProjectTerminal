using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    enum Screen { MainMenu, Password, Win };

    Screen currentScreen = Screen.MainMenu;

    int level;
    string password;

    void Start()
    {
        ShowMainMenu("NoName, ");
    }

    void ShowMainMenu(string playerName)
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine(playerName + "\nякий термінал ви хотіли б взломати?");
        Terminal.WriteLine("\n1 - міська бібліотека");
        Terminal.WriteLine("2 - поліція");
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
        currentScreen = Screen.Password;
        Terminal.WriteLine("Ви обрали " + level + " рівень");
        Terminal.WriteLine("Введіть пароль: ");
    }

    void RunMainMenu(string input)
    {
        if (input == "007")
        {
            Terminal.WriteLine("Hello, Mr. Bond!");
        }
        else if (input == "1")
        {
            level = 1;
            password = "ключ";
            GameStart();
        }
        else if (input == "2")
        {
            level = 2;
            password = "пістолет";
            GameStart();
        }
        else if (input == "3")
        {
            level = 3;
            password = "інтерстеллар";
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
            Terminal.WriteLine("Вітаю! Термінал взламано.");
        }

        else
        {
            Terminal.WriteLine("Не вдалося, спробуйте ще...");
        }
    }
}

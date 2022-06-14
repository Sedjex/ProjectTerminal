using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    void Start()
    {
        ShowMainMenu("Olga, ");
    }
    void ShowMainMenu(string playerName)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(playerName + "привіт! \nЯкий термінал ви хотіли б взломати?");
        Terminal.WriteLine("\n1 - міська бібліотека");
        Terminal.WriteLine("2 - поліція");
        Terminal.WriteLine("3 - шаттл");
        Terminal.WriteLine("\nЗробіть вибір ...");
    }
    void Update()
    {

    }
}

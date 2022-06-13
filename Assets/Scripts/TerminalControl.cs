using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalControl : MonoBehaviour
{
    void Start()
    {
    ShowMainMenu();
    }
void ShowMainMenu()
{
    Terminal.ClearScreen();
    Terminal.WriteLine("Привіт! \nЯкий термінал ви хотіли б взломати?");
    Terminal.WriteLine("\n1 - міська бібліотека");
    Terminal.WriteLine("2 - поліція");
    Terminal.WriteLine("3 - шаттл");
    Terminal.WriteLine("\nЗробіть вибір ...");
}
    void Update()
    {
        
    }
}

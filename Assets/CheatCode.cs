using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    // state variable
    private string[] cheatCode;
    private int index;

    //cached reference
    GameStatus theGameStatus;

    void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        cheatCode = new string[] { "c", "a", "l", "v", "i", "n", "l", "i", "n", "a", "r", "d", "y" };
        index = 0;
    }

    void Update()
    {
        if (theGameStatus.isAutoPlayEnabled == false)
        {
            TypeInCheatCodes();

            if (index == cheatCode.Length)
            {
                theGameStatus.isAutoPlayEnabled = true;
            }
        }
    }

    private void TypeInCheatCodes()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }
}

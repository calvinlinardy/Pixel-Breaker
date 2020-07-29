using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    private string[] cheatCode;
    private int index;
    bool yourBool;

    void Start()
    {
        cheatCode = new string[] { "c", "a", "l", "v", "i", "n", "l", "c" };
        index = 0;
    }

    void Update()
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

        if (index == cheatCode.Length)
        {
            PlayerPrefs.SetInt("Cheats", (yourBool ? 1 : 0));
        }
    }
}

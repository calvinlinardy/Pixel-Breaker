using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatCode : MonoBehaviour
{
    // state variable
    private string[] cheatCode;
    private int index;
    public GameObject cheatIndicator = null;
    public float sec = 1f;

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
                cheatIndicator.gameObject.SetActive(true);
                StartCoroutine(DisableAfterSec());
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

    public IEnumerator DisableAfterSec()
    {
        yield return new WaitForSeconds(sec);
        cheatIndicator.gameObject.SetActive(false);
    }
}

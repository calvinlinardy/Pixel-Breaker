using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minX = 1.23f;
    [SerializeField] float maxX = 14.77f;

    // cached references
    GameStatus theGameStatus;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        if (SceneLoader.GameIsPaused)
        {
            paddlePos.x = gameObject.transform.position.x;
        }
        else
        {
            paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
            transform.position = paddlePos;
        }
    }

    private float GetXPos()
    {
        if (theGameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthUnits;
        }
    }
}

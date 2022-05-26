using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static List<PlaceholderZapalka> matches;
    private static bool gameStarted = false;
    private static bool firstsTurn = true;
    public static int thisTurnTaken = 0;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (gameStarted)
        {
            changeTurn();
        }
        else
        {
            gameStart();
        }
    }

    public static void changeTurn()
    {
        if (matches.Count == 0)
        {
            //go to current player wins
        }
        else if (thisTurnTaken != 0)
        {
            Debug.Log("changeTurn");
            firstsTurn = !firstsTurn;
            thisTurnTaken = 0;
        }
    }

    private void gameStart()
    {
        Debug.Log("gameStart");
        matches = new List<PlaceholderZapalka>();
        gameStarted = true;
        firstsTurn = true;
        spawnMatches();
    }

    private void spawnMatches()
    {
        Debug.Log("spawnMatches");
        matches.Add(new PlaceholderZapalka());
        //TODO
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

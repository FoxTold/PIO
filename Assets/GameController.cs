using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public  GameObject prefab;
    private GameObject spawnPoint;
    public int maxNumOfMatches = 10;
    private List<GameObject> matchesList = new List<GameObject>();

    private int currentMatches = 0;
    private bool gameOver = false;

    private const string player1 = "Player 1";
    private const string player2 = "Player 2";

    private string currentPlayer;

    private string winner;

    private int possibleMoves = 3;
    public GameObject napis; //topTextObj
    private Text topText;

    public GameObject winNapis; //winTextObj
    private Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText = winNapis.GetComponent<Text>();
        topText = napis.GetComponent<Text>();
        currentPlayer = player1;
        currentMatches = maxNumOfMatches;
        spawnPoint = this.gameObject;

        for(int i = 0; i < maxNumOfMatches; i++)
        {
            GameObject m = Instantiate(prefab);
            m.transform.position = spawnPoint.transform.position;
            matchesList.Add(m); 
        }

        topText.text = "Current player: " + currentPlayer;

    }
    public void removeZapalka(GameObject zapalka)
    {
        matchesList.Remove(zapalka);
        currentMatches--;
    }
    // Update is called once per frame
    void Update()
    {
        if (matchesList.Count == 0 && !gameOver)
        {
            winner = currentPlayer ;
            Debug.Log("Wygral: " + winner);
            winText.text = "Winner: " + winner;
            gameOver = true;
        }
    }

    public void ChangeCurrentPlayer()
    {
        if (possibleMoves == 3) return;

        possibleMoves = 3;
        currentPlayer = currentPlayer == player1 ? player2 : player1;
        Debug.Log("Current player: " + currentPlayer);
        topText.text = "Current player: " + currentPlayer;
        Debug.Log(currentMatches);
    }

    public int getNumberOfMoves()
    {
        return possibleMoves;
    }

    public void decrementNumberOfMoves()
    {
        possibleMoves--;
    }
}

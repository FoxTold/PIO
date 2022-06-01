using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public  GameObject prefab;
    private GameObject spawnPoint;
    public int max_Zapalek = 10;
    private List<GameObject> listOfZapalki = new List<GameObject>();

    private int current_Zapalek=0;

    private const string gracz1 = "Player1";
    private const string gracz2 = "Player2";

    private string current_Gracz;

    private string winner;

    private int possibleMoves = 3;
    public GameObject napis;
    private Text txt;

    public GameObject winNapis;
    private Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText = winNapis.GetComponent<Text>();
        txt = napis.GetComponent<Text>();
        current_Gracz = gracz1;
        current_Zapalek = max_Zapalek;
        spawnPoint = this.gameObject;
        for(int i=0;i< max_Zapalek;i++)
        {
            GameObject zap = Instantiate(prefab);
            zap.transform.position = spawnPoint.transform.position;
            listOfZapalki.Add(zap); 
        }
        txt.text = "Current player: " + current_Gracz;

    }
    public void removeZapalka(GameObject zapalka)
    {
        listOfZapalki.Remove(zapalka);
        current_Zapalek--;
    }
    // Update is called once per frame
    void Update()
    {
        if (current_Zapalek <=0)
        {
            winner = current_Gracz ;
            Debug.Log("Wygral: " + winner);
            winText.text = "Winner: " + winner;
            current_Zapalek = 100000;
        }
    }

    public void   ChangeCurrentPlayer()
    {
        possibleMoves = 3;
        current_Gracz = current_Gracz == gracz1 ? gracz2 : gracz1;
        Debug.Log("Current player: " + current_Gracz);
        txt.text = "Current player: " + current_Gracz;
        Debug.Log(current_Zapalek);
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

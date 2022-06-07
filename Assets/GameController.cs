using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public  GameObject prefab;
    private GameObject spawnPoint;
    public int max_Zapalek = 120;
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
    
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject PlayAgain;
    [SerializeField] private GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        PlayAgain.SetActive(false);
        Menu.SetActive(false);
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
        button.SetActive(true);
        current_Zapalek--;
    }
    // Update is called once per frame
    void Update()
    {
        if (current_Zapalek <=0)
        {
            PlayAgain.SetActive(true);
            Menu.SetActive(true);
            winner = current_Gracz ;
            Debug.Log("Wygral: " + winner);
            txt.text = "";
            winText.text = "Winner: " + winner;
            current_Zapalek = 100000;
            Destroy(button);
        }
    }

    public void   ChangeCurrentPlayer()
    {
        if( possibleMoves != 3 )
        {
            possibleMoves = 3;
            current_Gracz = current_Gracz == gracz1 ? gracz2 : gracz1;
            Debug.Log("Current player: " + current_Gracz);
            txt.text = "Current player: " + current_Gracz;
            Debug.Log(current_Zapalek);
            button.SetActive(false);
        }
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

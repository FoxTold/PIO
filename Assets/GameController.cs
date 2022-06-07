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

    [SerializeField] private GameObject match1;
    [SerializeField] private GameObject match2;
    [SerializeField] private GameObject match3;

    [SerializeField] private GameObject counter;
    private Text counter_txt;

    [SerializeField] private AudioSource winningSound;
    [SerializeField] private AudioSource removingSound;
    [SerializeField] private AudioSource noMoveSound;
    [SerializeField] private AudioSource clickSound;


    // Start is called before the first frame update
    void Start()
    {
        counter_txt = counter.GetComponent<Text>();
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
        txt.text =  current_Gracz;

    }
    public void removeZapalka(GameObject zapalka)
    {
        updateCounter();
        if (possibleMoves <= 3)
            match3.SetActive(false);
        if (possibleMoves <= 2)
            match2.SetActive(false);
        if (possibleMoves <= 1)
        {
            match1.SetActive(false);
            noMoveSound.Play();
        }
        else
            removingSound.Play();

        listOfZapalki.Remove(zapalka);
        button.SetActive(true);
        current_Zapalek--;
        
    }
    // Update is called once per frame
    void Update()
    {
        updateCounter();
        if (current_Zapalek <=0)
        {
            counter.SetActive(false);
            PlayAgain.SetActive(true);
            Menu.SetActive(true);
            winner = current_Gracz ;
            Debug.Log("Wygral: " + winner);
            txt.text = "";
            winText.text = "Winner: " + winner;
            current_Zapalek = 100000;
            match1.SetActive(false);
            match2.SetActive(false);
            Destroy(button);
            winningSound.Play();
        }
    }

    public void   ChangeCurrentPlayer()
    {
        if( possibleMoves != 3 )
        {
            possibleMoves = 3;
            current_Gracz = current_Gracz == gracz1 ? gracz2 : gracz1;
            Debug.Log("Current player: " + current_Gracz);
            txt.text = current_Gracz;
            Debug.Log(current_Zapalek);
            button.SetActive(false);
            match1.SetActive(true);
            match2.SetActive(true);
            match3.SetActive(true);
            clickSound.Play();
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
    public void updateCounter()
    {
        counter_txt.text = "Matches left: "+current_Zapalek;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public GameController gamecontroller;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (gamecontroller.getNumberOfMoves() > 0)
        {
            Debug.Log(gamecontroller.getNumberOfMoves()-1);
            gamecontroller.removeZapalka(this.gameObject);
            gamecontroller.decrementNumberOfMoves();
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        gamecontroller=FindObjectOfType<GameController>().GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

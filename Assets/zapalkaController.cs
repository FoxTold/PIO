using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zapalkaController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        GameController.thisTurnTaken++;
        if (GameController.thisTurnTaken == 3)
        {
            Destroy(this.gameObject);
            GameController.changeTurn();
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

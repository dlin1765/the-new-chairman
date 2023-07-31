using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public enum GameState { PAUSE, PLAYERTURN, ENEMYTURN, ENEMY2TURN, ENEMY3TURN, START }

    public GameObject playerHandCopy;
    public GameObject enemyHandCopy;
    public GameObject deckHandCopy;
    public GameObject deckCopy;
    public GameObject cardCopy;
    public GameState state;
    PlayerHandController p1;
    EnemyHandController e1;
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.START;
    }

    // 0 - 12 clubs 
    // 13 - 25 diamonds
    // 26 - 38 hearts
    // 39 - 51 spades 

    // 6, 19, 32, 45 
    

    public void StartGame()
    {
        
        p1 = playerHandCopy.GetComponent<PlayerHandController>();
        e1 = enemyHandCopy.GetComponent<EnemyHandController>();
        state = GameState.ENEMYTURN;
        enemyTurn();
        //p1.printDeck();
    }


    private void enemyTurn()
    {
        e1.printDeck();
    }
}

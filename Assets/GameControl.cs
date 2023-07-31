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
    public GameObject tableTop;
    public Sprite[] spriteArray;
    public GameState state;
    PlayerHandController p1;
    EnemyHandController e1;
    ButtController d1;
    TableHandController t1; 
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.START;
    }

    void Update()
    {
        //if()
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
        d1 = deckHandCopy.GetComponent<ButtController>();
        t1 = tableTop.GetComponent<TableHandController>();
        state = GameState.ENEMYTURN;
        enemyTurn();
        //p1.printDeck();
    }


    private void enemyTurn()
    {
        // implement some kind of coroutine to make it so it pauses between turns 
        e1.printDeck();
        int pickOrder = 0; 
        if (t1.tablesHand.Count != 0)
        {
            pickOrder = 0;      
        }
        GameObject copy = GameObject.Find("ButtonController");
        GameObject cardTemp = GameObject.Find("card");
        //ButtController copy1 = copy.GetComponent<ButtController>();
        var tableTransform = t1.transform;
        var enemyTransform = e1.transform;
        int temp = t1.tablesHand.Count;
        t1.tablesHand.Add(e1.enemyHand[pickOrder]);
        //enemyTransform.GetChild(pickOrder).gameObject.GetComponent<card>().spriteRenderer.sprite = enemyTransform.GetChild(pickOrder).gameObject.GetComponent<card>().spriteArray[e1.enemyHand[pickOrder]];
        enemyTransform.GetChild(pickOrder).gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[e1.enemyHand[pickOrder]];
        enemyTransform.GetChild(pickOrder).gameObject.transform.SetParent(tableTransform, false);
        e1.enemyHand.RemoveAt(pickOrder);
        


        //tablesHand.RemoveRange(0, temp - 1);
    }
}

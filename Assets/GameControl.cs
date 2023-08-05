using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    public enum GameState { PAUSE, PLAYERTURN, ENEMYTURN, ENEMY2TURN, ENEMY3TURN, START }

    public GameObject playerHandCopy;
    public GameObject enemyHandCopy;
    public GameObject deckHandCopy;
  
    public GameObject cardCopy;
    public GameObject tableTop;
    public Sprite[] spriteArray;
    
    public GameState state;
    public bool cardPlayed = false;
    PlayerHandController p1;
    EnemyHandController e1;
    ButtController d1;
    TableHandController t1;
    card c1;
    public int cardTracker;
    public int turnOrder;
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.START;
        turnOrder = 0;
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
        c1 = cardCopy.GetComponent<card>();
        state = GameState.ENEMYTURN;
        StartCoroutine(enemyTurn());
        //p1.printDeck();
    }


    IEnumerator enemyTurn()
    {
        // implement some kind of coroutine to make it so it pauses between turns 
        //e1.printDeck();
        // start another coroutine that checks if the player has placed a card on the table top 
        int lowBound = 0;
        bool found = false;
        int highBound = 0;
        yield return new WaitForSeconds(2f);
        int pickOrder = 0; 
        if (t1.tablesHand.Count != 0) // if the table has cards on it, check for the suit so it can play the correct card
        {
            // implement the rules here 
            int tableNum = t1.tablesHand[t1.tablesHand.Count-1];
            // tableNum = 3 
   
            if(tableNum >= 0 && tableNum <= 12)
            {
                lowBound = 0;
                highBound = 12;
            }
            else if(tableNum > 12 && tableNum <= 25)
            {
                lowBound = 13;
                highBound = 25;
            }
            else if(tableNum > 25 && tableNum <= 38)
            {
                lowBound = 25;
                highBound = 38;
            }
            else
            {
                lowBound = 38;
                highBound = 51;
            }
            
            for(int i = 0; i < e1.enemyHand.Count; i++)
            {
                if ((e1.enemyHand[i] >= lowBound && e1.enemyHand[i] <= highBound) || (t1.tablesHand[t1.tablesHand.Count-1] % 13 == e1.enemyHand[i] % 13))
                {
                    pickOrder = i;
                    found = true;
                    break;
                }
            }
        }
        else // if there are no cards on the table, just play the first card in the hand
        {
            pickOrder = 0;
            found = true;
        }
        if (found == false) // if the ai does not have a card it can play, draw a card from the deck
        {
            GameObject copy = GameObject.Find("ButtonController");
            c1.SpawnCard(e1.gameObject, copy.GetComponent<ButtController>().deckList[0], false, 1);
            copy.GetComponent<ButtController>().deckList.RemoveAt(0);
        }
        else // if the AI has a card it can play, move the card from the hand to the table 
        {
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

            
        }
        // remember to add functionality to skip turns with aces by upping turn order by 2
        turnOrder++;
        // have to change it to player turn
        if (turnOrder == 1)
        {

        }
        else if (turnOrder == 2)
        {

        }
        else if (turnOrder == 2)
        {

        }
        else if (turnOrder == 3)
        {

        }
        else
        {
            Debug.Log("This should never happennn");
        }
        state = GameState.PLAYERTURN;
        p1.numCards = p1.playerHand.Count;
        cardTracker = p1.numCards;
        StartCoroutine(playerTurn());
        // if statement to change the state to the correct one 

    }

    IEnumerator playerTurn()
    {
        yield return new WaitUntil(() => playedCard());

        Debug.Log("player finished");
        state = GameState.ENEMYTURN;
        StartCoroutine(enemyTurn());
        // check if a card has been dropped on the table, if yes, change the state back to the enemy turn
        // add functionality to check if a player dropped a card during enemy turn, debug.log("playing out of order")
        

    }
    

    public bool playedCard()
    {
        /*
        if(state == GameState.PLAYERTURN)
        {
            Debug.Log("good play");
            return true;
        }
        else
        {
            Debug.Log("bad play");
            return false;
        }
        */
        if (state == GameState.PLAYERTURN)
        {
            if (cardTracker - 1 == p1.playerHand.Count || cardTracker + 1 == p1.playerHand.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            
            return false;
        }
    }
  
    
    
}

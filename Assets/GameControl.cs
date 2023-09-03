using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameControl : MonoBehaviour
{

    public enum GameState { PAUSE, PLAYERTURN, ENEMYTURN, ENEMY2TURN, ENEMY3TURN, START, PLAYERPENALTY }

    public GameObject playerHandCopy;
    public GameObject enemyHandCopy;
    public GameObject deckHandCopy;
    public GameObject dialogueManagerCopy;
    public GameObject cardCopy;
    public GameObject tableTop;
    public Sprite[] spriteArray;
    public Text CardTrackText;
    public GameObject SpeakingManager;
    public GameState state;
    public bool spokeCorrectly = true;
    public bool cardPlayed = false;
    public bool suitCorrect = false;
    public bool drew;

    public Text testText;
    public Text turnText;


    PlayerHandController p1;
    thevoices v1;
    EnemyHandController e1;
    ButtController d1;
    TableHandController t1;
    DialogManager dm1;
    card c1;
    public int cardTracker= 0;
    public int turnOrder;

    public float swingCD = 1000005.05f;
    public float nextSwing = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.START;
        turnOrder = 0;
        testText.gameObject.SetActive(true);
    }

    void Update()
    {
        if(state != GameState.START)
        {
            testText.text = cardTracker + "/ " + p1.playerHand.Count;
            if(playedCard())
            {
                turnText.text = "true/" + turnOrder;
            }
            else
            {
                turnText.text = "false/" + turnOrder;
            }
            
        }
        




    }

    // 0 - 12 clubs 
    // 13 - 25 diamonds
    // 26 - 38 hearts
    // 39 - 51 spades 

    // 6, 19, 32, 45 
    public bool wrongTurn(bool whenCard)
    {   
        if(!whenCard)
        {
            return true;
        }
        return false;

    }
    
    public GameState getState()
    {
        return state;
    }
    public void StartGame()
    {
        v1 = SpeakingManager.GetComponent<thevoices>();
        p1 = playerHandCopy.GetComponent<PlayerHandController>();
        e1 = enemyHandCopy.GetComponent<EnemyHandController>();
        d1 = deckHandCopy.GetComponent<ButtController>();
        t1 = tableTop.GetComponent<TableHandController>();
        c1 = cardCopy.GetComponent<card>();
        dm1 = dialogueManagerCopy.GetComponent<DialogManager>();
        state = GameState.ENEMYTURN;

        StartCoroutine(CheckForIllegalMove());
        //p1.printDeck();
    }

    /*
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
    */
    public void RuleDecider(int playedNum)
    {
        DialogueSet ds = new DialogueSet();
        List<DialogueSet> startWords = new List<DialogueSet>();
     
        bool dialogue = false;
        if (playedNum % 13 == 6)
        {
            ds.name = "???";
            ds.dialogue = "Have a nice day";
            dialogue = true;
  
        }
        if (playedNum % 13 == 0)
        {
            Debug.Log("skipped turn");
        }
        if (playedNum % 13 == 1)
        {
            Debug.Log("draw two cards");
        }
        if (playedNum % 13 == 10)
        {
       
            ds.name = "???";
            if(dialogue)
            {
                ds.dialogue = ds.dialogue + ", spades";
            }
            else
            {
                ds.dialogue = "spades";
            }
             // add functionality to pick a new suit using a random number generator 

            dialogue = true;

        }
        if (playedNum > 38 && playedNum <= 51)
        {
            ds.name = "???";
            if (dialogue)
            {
                ds.dialogue = ds.dialogue + ", " + (playedNum % 13 + 1) + " of spades";
            }
            else
            {
                ds.dialogue = (playedNum % 13 + 1) + " of spades";
            }
           
            dialogue = true;

        }

        if (e1.enemyHand.Count == 1)
        {
            ds.name = "???";
            if (dialogue)
            {
                ds.dialogue = ds.dialogue + ", I am the new chairman"; ;
            }
            else
            {
                ds.dialogue = "I am the new chairman";
            }
            dialogue = true;
            // add functionality to suspend this coroutine and go to a win screen
            
        }
        if (dialogue)
        {
            startWords.Add(ds);
            dm1.StartDialogue(startWords);
        }
     
    }
    IEnumerator enemyTurn() // 2 
    {
        // implement some kind of coroutine to make it so it pauses between turns 
        //e1.printDeck();
        // start another coroutine that checks if the player has placed a card on the table top 
        int lowBound = 0;
        bool found = false;
        int highBound = 0;
        

       // aces, sevens, jack, spades, two 

        int pickOrder = 0;
        if (t1.tablesHand.Count != 0) // if the table has cards on it, check for the suit so it can play the correct card
        {
            // implement the rules here 
            int tableNum = t1.tablesHand[t1.tablesHand.Count - 1];
            // tableNum = 3 

            if (tableNum >= 0 && tableNum <= 12)
            {
                lowBound = 0;
                highBound = 12;
            }
            else if (tableNum > 12 && tableNum <= 25)
            {
                lowBound = 13;
                highBound = 25;
            }
            else if (tableNum > 25 && tableNum <= 38)
            {
                lowBound = 25;
                highBound = 38;
            }
            else
            {
                lowBound = 38;
                highBound = 51;
            }

            for (int i = 0; i < e1.enemyHand.Count; i++)
            {
                if ((e1.enemyHand[i] >= lowBound && e1.enemyHand[i] <= highBound) || (t1.tablesHand[t1.tablesHand.Count - 1] % 13 == e1.enemyHand[i] % 13))
                {
                    pickOrder = i;
                    found = true;
                    break;
                }
            }

            

            // dialogue manager stuff here 

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
            RuleDecider(e1.enemyHand[pickOrder]);
            e1.enemyHand.RemoveAt(pickOrder);
        }
        // remember to add functionality to skip turns with aces by upping turn order by 2
        turnOrder = (turnOrder + 1) % 4;
        // have to change it to player turn
        if (turnOrder == 0)
        {

        }
        else if (turnOrder == 1)
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
        yield return null;
        // if statement to change the state to the correct one 

    }

    public void OutOfTurn()
    {
        StopAllCoroutines();
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(CheckForSpeaking());
    }

    IEnumerator CheckForIllegalMove() //1 
    {
        
        drew = false;
        bool played;
        DialogueSet ds = new DialogueSet();
        List<DialogueSet> startWords = new List<DialogueSet>();
        p1.numCards = p1.playerHand.Count;
        cardTracker = p1.numCards;
        if (state == GameState.ENEMYTURN)
        {
            double timer = 0.0;
            while (timer <= 30)
            {
                testText.text = cardTracker + "/ " + p1.playerHand.Count + "!";
                timer = timer + 0.1;
                yield return null;
                if (p1.isClicked())
                {
                    timer = 0.0;
                    // startcoroutine check for played card
                }
                played = playedCard();
               
                while (played)
                {
                    c1.PenalizePlayer();
                    
                    if (drew)
                    {
                        int temp = tableTop.transform.GetChild(t1.tablesHand.Count - 1).GetComponent<card>().num; // looks at the tables topdeck and gets the cards num

                        p1.AddCard(temp);
                        tableTop.transform.GetChild(t1.tablesHand.Count - 1).GetComponent<card>().isPlayerCard = true;

                        tableTop.transform.GetChild(t1.tablesHand.Count - 1).gameObject.transform.SetParent(playerHandCopy.transform, false);

                        t1.RemoveCard(t1.tablesHand.Count - 1);
                    }
                    ds.name = "???";
                    ds.dialogue = "playing out of order";
                    startWords.Add(ds);
                    dm1.StartDialogue(startWords);
                    timer = 0.0;
                    p1.numCards = p1.playerHand.Count;
                    cardTracker = p1.numCards;
                    played = false;
                }


            }
            StartCoroutine(enemyTurn());
        }
        yield return null;
    }

    IEnumerator CheckForSpeaking()
    {
     
            double timer = 0.0;
            while (timer <= 50)
            {
                timer = timer + 0.1;
                yield return null;
                if (v1.isTalking)
                {
                    timer = 0.0;
                }
                // if the player plays any more cards during this time, return it to their hand and penalize them 

            // this is where i will check for all the phrases that need to be said and if theyre not all right then the state will switch to player penalty
            }

            state = GameState.ENEMYTURN;
            StartCoroutine(CheckForIllegalMove());
    }
    /*
   
    IF (the player played correctly)
    {

	    IF ( the player needs to say something)
	
	        The player will say the phrase, while there is input coming in from the microphone, the code will not move on
	
	       
	
	    Else // the player does not need to say something
	
	    The code will wait out the window and pass the turn to the enemy
    }
    Else // the player misplayed
    {
	    The card will be returned to their hand and they will be penalized
    }

    */



    /*
    IEnumerator playerTurn()
    {
        spokeCorrectly = true;
        drew = false;
        bool suitCheck = false;
        yield return new WaitUntil(() => playedCard());
        if (!drew)
        {
            
              yield return new WaitUntil(() => playedCard());



            suitCheck = playerRules(t1.tablesHand[t1.tablesHand.Count - 1]); //this detects the rules that i need
            while (!suitCheck) // if the player does not play the correct suit
            {
                yield return new WaitForSeconds(1f);
                Debug.Log("WRONG SUIT BITCH");
                /*
                c1.PenalizePlayer();

                int temp = tableTop.transform.GetChild(t1.tablesHand.Count - 1).GetComponent<card>().num; // looks at the tables topdeck and gets the cards num
              
                p1.AddCard(temp);
                tableTop.transform.GetChild(t1.tablesHand.Count - 1).GetComponent<card>().isPlayerCard = true;
               
                tableTop.transform.GetChild(t1.tablesHand.Count - 1).gameObject.transform.SetParent(playerHandCopy.transform, false);
                
                t1.RemoveCard(t1.tablesHand.Count - 1);
                Debug.Log("penalize player done, now waiting for playedcard");
                
                


                
                yield return new WaitUntil(() => playedCard());
                Debug.Log("done with player");
                suitCheck = playerRules(t1.tablesHand[t1.tablesHand.Count - 1]);
                
                suitCheck = playerRules(t1.tablesHand[t1.tablesHand.Count - 1]);
            }


        }
        yield return CheckForSpeaking(); // checks if the player said all the things it needs to do



        /*
        if(spokeCorrectly)
        {
               state = GameState.ENEMYTURN;
               StartCoroutine(CheckForIllegalMove());
        }
        else
        {
                StartCoroutine(PenalizePlayer());
                // dialogue must be written here 
                



                state = GameState.ENEMYTURN;
                StartCoroutine(CheckForIllegalMove());

        }
         if the game state is still playerturn and not playerpenalty
		        ○ Wait out the window and pass the turn to the enemy
	     Else (game state is player penalty)
		        ○ Penalize the player and pass the turn to the enemy

        

        //Debug.Log("player finished");




        state = GameState.ENEMYTURN;
        StartCoroutine(CheckForIllegalMove());
        // check if a card has been dropped on the table, if yes, change the state back to the enemy turn
        // add functionality to check if a player dropped a card during enemy turn, debug.log("playing out of order")


    }
    */
    public bool CheckForSuit()
    {
        if(suitCorrect)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator PlayerTimer()
    {
        DialogueSet ds = new DialogueSet();
        List<DialogueSet> startWords = new List<DialogueSet>();
        while (!suitCorrect)
        {
            // give back the cards and penalize up date the numcards 
            c1.PenalizePlayer();
            int temp = tableTop.transform.GetChild(t1.tablesHand.Count - 1).GetComponent<card>().num; // looks at the tables topdeck and gets the cards num

            p1.AddCard(temp);
            tableTop.transform.GetChild(t1.tablesHand.Count - 1).GetComponent<card>().isPlayerCard = true;

            tableTop.transform.GetChild(t1.tablesHand.Count - 1).gameObject.transform.SetParent(playerHandCopy.transform, false);
                
            t1.RemoveCard(t1.tablesHand.Count - 1);
            p1.numCards = p1.playerHand.Count;
            cardTracker = p1.numCards;
            ds.name = "???";
            ds.dialogue = "Playing the incorrect suit";
            startWords.Add(ds);
            dm1.StartDialogue(startWords);


            yield return new WaitUntil(() => playedCard());
           
           
            bool suitCheck = playerRules(t1.tablesHand[t1.tablesHand.Count - 1]);
           
            if(suitCheck)
            {
                suitCorrect = true;
            }
        }
        
    }

    IEnumerator playerTurn()
    {
        spokeCorrectly = true;
        drew = false;
        bool suitCheck = false;
      

        // probably need to add another coroutine to check for speaking here because that would be talking 

        yield return new WaitUntil(() => playedCard());
        if (!drew)
        {
            suitCheck = playerRules(t1.tablesHand[t1.tablesHand.Count - 1]); //this detects the rules that i need
            if (!suitCheck)
            {
                suitCorrect = false;
            }
            else
            {
                suitCorrect = true;
            }
            StartCoroutine(PlayerTimer());
            yield return new WaitUntil(() => CheckForSuit());
            state = GameState.ENEMYTURN;
            turnOrder = (turnOrder + 1) % 4;
        }
        else
        {
            state = GameState.ENEMYTURN;
            turnOrder = (turnOrder + 1) % 4;
        }

        // if the player needs to say something otherwise itll pass
        yield return CheckForSpeaking(); // checks if the player said all the things it needs to do

        

        /*
        if(spokeCorrectly)
        {
               state = GameState.ENEMYTURN;
               StartCoroutine(CheckForIllegalMove());
        }
        else
        {
                StartCoroutine(PenalizePlayer());
                // dialogue must be written here 
                



                state = GameState.ENEMYTURN;
                StartCoroutine(CheckForIllegalMove());

        }
         if the game state is still playerturn and not playerpenalty
		        ○ Wait out the window and pass the turn to the enemy
	     Else (game state is player penalty)
		        ○ Penalize the player and pass the turn to the enemy

        */

        //Debug.Log("player finished");


        // this is where it was danny HASDJHLAKDJSKLAJSDKL

        /*
  
        state = GameState.ENEMYTURN;
        StartCoroutine(CheckForIllegalMove());
        */

        // check if a card has been dropped on the table, if yes, change the state back to the enemy turn
        // add functionality to check if a player dropped a card during enemy turn, debug.log("playing out of order")


    }
    IEnumerator CheckSuits(int playedNum)
    {
        int tableNum = t1.BelowDeck();

        int lowBound = 0;
        int highBound = 0;
        if (tableNum >= 0 && tableNum <= 12)
        {
            lowBound = 0;
            highBound = 12;
        }
        else if (tableNum > 12 && tableNum <= 25)
        {
            lowBound = 13;
            highBound = 25;
        }
        else if (tableNum > 25 && tableNum <= 38)
        {
            lowBound = 25;
            highBound = 38;
        }
        else
        {
            lowBound = 38;
            highBound = 51;
        }

        if ((playedNum >= lowBound && playedNum <= highBound) || (tableNum % 13 == playedNum % 13))
        {
            Debug.Log("CORRECT SUIT");
       
        }
        else
        {
            // this is where the table will spit back the players card because they played the incorrect suit
            Debug.Log("INCORRECT SUIT");


        }
        yield return null;
    }
    public bool playerRules(int playedNum)
    {
        int tableNum = t1.BelowDeck();
        
        int lowBound = 0;
        int highBound = 0;
        if (tableNum >= 0 && tableNum <= 12)
        {
            lowBound = 0;
            highBound = 12;
        }
        else if (tableNum > 12 && tableNum <= 25)
        {
            lowBound = 13;
            highBound = 25;
        }
        else if (tableNum > 25 && tableNum <= 38)
        {
            lowBound = 25;
            highBound = 38;
        }
        else
        {
            lowBound = 38;
            highBound = 51;
        }

        if ((playedNum >= lowBound && playedNum <= highBound) || (tableNum % 13 == playedNum % 13))
        {
            //Debug.Log("CORRECT SUIT");
            return true;
        }
        else
        {
            // this is where the table will spit back the players card because they played the incorrect suit
            //Debug.Log("INCORRECT SUIT");
            
            return false;

        }
        




        /*
        bool dialogue = false;
        if (playedNum % 13 == 6) // 7
        {

        }
        if (playedNum % 13 == 10) // jack
        {

           

        }
        if (playedNum > 38 && playedNum <= 51) // spades
        {
           

        }
        if (p1.playerHand.Count == 1) // last card being played
        {
           
            // add functionality to suspend this coroutine and go to a win screen

        }
        */
        /*
       
        */
        return false;
    }

public bool playedCard()
{ 
      
        if (state == GameState.PLAYERTURN)
        {
            if (cardTracker - 1 == p1.playerHand.Count || cardTracker + 1 == p1.playerHand.Count)
            {
                if(cardTracker + 1 == p1.playerHand.Count)
                {
                    drew = true;
                }
                
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

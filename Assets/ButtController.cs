using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DialogueSet
{
    public string name;
    public string dialogue; 

    public DialogueSet(string n, string d)
    {
        this.name = n;
        dialogue = d;
    }
};


public class ButtController : MonoBehaviour
{
    public GameObject _card;
    public GameObject player1hand;
    public GameObject enemy1hand;
    public GameObject enemy2hand;
    public GameObject enemy3hand;
    public GameObject StartButton;
    public GameObject startingText;
    public GameObject nameText;
    public GameObject DialogManager;
    
    private string deckPrint;
    public int turn;
    public List<int> deckList;
    public void CreateCard()
    {
        card cardCopy = _card.GetComponent<card>();
        cardCopy.SpawnCard(player1hand, deckList[0], true);
        deckList.RemoveAt(0);
        Debug.Log("Hello world");
    }
    public void StartGame()
    {
        Debug.Log("game start");
        player1hand = GameObject.Find("player1hand");
       
        startingText.SetActive(true);
        nameText.SetActive(true);
        enemy1hand = GameObject.Find("enemy1hand");
        enemy2hand = GameObject.Find("enemy2hand");
        enemy3hand = GameObject.Find("enemy3hand");
        StartButton = GameObject.Find("StartButton");
        DialogManager copy = DialogManager.GetComponent<DialogManager>();
        List<DialogueSet> startWords = new List<DialogueSet>();
        DialogueSet line1 = new DialogueSet("???", "The rules are simple");
        DialogueSet line2 = new DialogueSet("???", "The first rule, is that there is no talking");
        DialogueSet line3 = new DialogueSet("???", "The second rule is that there is NO talking about the rules");
        DialogueSet line4 = new DialogueSet("???", "I will start, and the turn order will be clockwise");
        DialogueSet line5 = new DialogueSet("???", "Start game.");
        startWords.Add(line1);
        startWords.Add(line2);
        startWords.Add(line3);
        startWords.Add(line4);
        startWords.Add(line5);

        copy.StartDialogue(startWords);
        
        card cardCopy = _card.GetComponent<card>();
        // player1hand p1hand = player1hand.GetComponent<player1hand>();
        //enemy1hand e1hand = enemy1hand.GetComponent<enemy1hand>();
        
        
        for (int i = 0; i < 5; i++)
        {

            cardCopy.SpawnCard(player1hand, deckList[0], true);
            deckList.RemoveAt(0);
            cardCopy.SpawnCard(enemy1hand, deckList[0], false);
            deckList.RemoveAt(0);
            cardCopy.SpawnCard(enemy2hand, deckList[0], false);
            deckList.RemoveAt(0);
            cardCopy.SpawnCard(enemy3hand, deckList[0], false);
            deckList.RemoveAt(0);
        }
        Destroy(StartButton.gameObject);
    }
    void Start()
    {
        deckList = new List<int>();
        for (int i = 0; i < 52; i++)
        {
            deckList.Add(i);
        }
        
        for (int i = 0; i < 52; i++)
        {
            int temp = deckList[i];
            int randomNumber = Random.Range(0, 52);
            deckList[i] = deckList[randomNumber];
            deckList[randomNumber] = temp;
        }
       // startingText = GameObject.Find("Text");
        startingText.SetActive(false);
        nameText.SetActive(false);
        

        /*

         player1hand = GameObject.Find("player1hand");
         enemy1hand = GameObject.Find("enemy1hand");
         enemy2hand = GameObject.Find("enemy2hand");
         enemy3hand = GameObject.Find("enemy3hand");
         card cardCopy = _card.GetComponent<card>();
         // player1hand p1hand = player1hand.GetComponent<player1hand>();
         //enemy1hand e1hand = enemy1hand.GetComponent<enemy1hand>();
         deckList = new List<int>();
         for (int i = 0; i < 52; i++)
         {
             deckList.Add(i);
         }
         for (int i = 0; i < 52; i++)
         {
             int temp = deckList[i];
             int randomNumber = Random.Range(0, 52);
             deckList[i] = deckList[randomNumber];
             deckList[randomNumber] = temp;
         }

         for (int i = 0; i < 52; i++)
         {
             deckPrint = deckPrint + deckList[i] + " ";
         }
         Debug.Log(deckPrint);
         /
         for (int i = 0; i < 5; i++)
         {

             cardCopy.SpawnCard(player1hand, deckList[0], true).isPlayerCard = true;
             cardCopy.setNum(deckList[0]);
             deckList.RemoveAt(0);
             cardCopy.SpawnCard(enemy1hand, deckList[0], false).isPlayerCard = false;
             deckList.RemoveAt(0);
             cardCopy.SpawnCard(enemy2hand, deckList[0], false).isPlayerCard = false;
             deckList.RemoveAt(0);
             cardCopy.SpawnCard(enemy3hand, deckList[0], false).isPlayerCard = false;
             deckList.RemoveAt(0);

             cardCopy.SpawnCard(player1hand, deckList[0], true);
             deckList.RemoveAt(0);
             cardCopy.SpawnCard(enemy1hand, deckList[0], false);
             deckList.RemoveAt(0);
             cardCopy.SpawnCard(enemy2hand, deckList[0], false);
             deckList.RemoveAt(0);
             cardCopy.SpawnCard(enemy3hand, deckList[0], false);
             deckList.RemoveAt(0);
         }



         for(int i = 0; i < 5; i++)
         {

         }

         // cardCopy.SpawnCard(e1hand);
         //cardCopy.SpawnCard(player1hand, deckList[0], true);
         //deckList.RemoveAt(0);
         */
    }   
}
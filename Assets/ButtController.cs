using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtController : MonoBehaviour
{
    public GameObject _card;
    public GameObject player1hand;
    public GameObject enemy1hand;
    public GameObject enemy2hand;
    public GameObject enemy3hand;
    private string deckPrint;
    public List<int> deckList;
    public void CreateCard()
    {
        card cardCopy = _card.GetComponent<card>();
        cardCopy.SpawnCard(player1hand, deckList[0], true);
        deckList.RemoveAt(0);
        Debug.Log("Hello world");
    }
    void Start()
    {
        Debug.Log("game start");
            
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
        }
        /*
        for(int i = 0; i < 5; i++)
        {
           
        }
        */    
            // cardCopy.SpawnCard(e1hand);
        
    }   
}

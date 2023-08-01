using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    public GameObject _card;
    public GameObject player1hand;
    public GameObject enemy1hand;
    public GameObject enemy2hand;
    public GameObject enemy3hand;
    public GameObject _deck;
    public List<int> playerHand;
    private string deckPrint;
    public bool played = false;
    public int numCards;
    // Start is called before the first frame update
    void Start()
    {
        _card = GameObject.Find("Card");
        _deck = GameObject.Find("Deck");
        player1hand = GameObject.Find("player1hand");
        enemy1hand = GameObject.Find("enemy1hand");
        enemy2hand = GameObject.Find("enemy2hand");
        enemy3hand = GameObject.Find("enemy3hand");
        card cardCopy = _card.GetComponent<card>();
        playerHand = new List<int>();
        numCards = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void printDeck()
    {
        for(int i = 0; i < playerHand.Count; i++)
        {
            Debug.Log(playerHand[i] + " ");
        }
    }
}

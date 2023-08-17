using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableHandController : MonoBehaviour
{
    public GameObject _card;
    public GameObject player1hand;
    public GameObject enemy1hand;
    public GameObject enemy2hand;
    public GameObject enemy3hand;
    public GameObject ButtController;
    public GameObject _deck;
    public List<int> tablesHand;
    public int topDeck;
    public int belowDeck;
    private string deckPrint;
    // Start is called before the first frame update
    void Start()
    {
        /*
        _card = GameObject.Find("Card");
        _deck = GameObject.Find("Deck");
        player1hand = GameObject.Find("player1hand");
        enemy1hand = GameObject.Find("enemy1hand");
        enemy2hand = GameObject.Find("enemy2hand");
        enemy3hand = GameObject.Find("enemy3hand");
        card cardCopy = _card.GetComponent<card>();
        tablesHand = new List<int>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (tablesHand.Count != 0)
            {
                for (int i = 0; i < tablesHand.Count; i++)
                {
                    Debug.Log(tablesHand[i]);
                }
            }
            else
            {
                Debug.Log("nothing here bb");
            }

        }
    }

    public int TopDeck()
    {
        if(tablesHand.Count > 0)
        {
            return tablesHand[tablesHand.Count - 1];
        }
        else
        {
            return -1;
        }
    }
    public int BelowDeck()
    {
       if(tablesHand.Count > 1)
        {
            return tablesHand[tablesHand.Count - 2];
        }
       else
        {
            return -1;
        }
    }
    public bool isFull()
    {
        if (tablesHand.Count >= 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void readdCards()
    {
        GameObject copy = GameObject.Find("ButtonController");
        GameObject cardTemp = GameObject.Find("card");
        ButtController copy1 = copy.GetComponent<ButtController>();
        var tableTransform = this.transform;
        int temp = tablesHand.Count;
        for (int i = 0; i < temp - 2; i++)
        {
            copy1.deckList.Add(tablesHand[i]);
            
            Destroy(tableTransform.GetChild(i).gameObject); 
            //_card 
            
        }
        tablesHand.RemoveRange(0, temp - 2);
        /*
        for (int i = 0; i < tablesHand.Count; i++)
        {
            int temp = copy.deckList[i];
            int randomNumber = Random.Range(0, tablesHand.Count);
            copy.deckList[i] = copy.deckList[randomNumber];
            copy.deckList[randomNumber] = temp;
        }
        */
    }
}

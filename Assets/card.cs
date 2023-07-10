using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    private string suit;
    private string number;
    private string color;
    public GameObject player1hand;
    public GameObject enemy1hand;
    public GameObject enemy2hand;
    public GameObject enemy3hand;
    public GameObject Card;
    public GameObject PlayerHandController;

    public SpriteRenderer spriteRenderer;

    public Sprite[] spriteArray;


    // Start is called before the first frame update
    void Start()
    {
        // add functionality to change the sprite based on the suit/number/color
        /*
        List<int> deckList = new List<int>();
        for(int i = 0; i < 52; i++)
        {
            deckList.Add(i); 
        }
        for(int i = 0; i < 52; i++)
        {
            int temp = deckList[i];
            int randomNumber = Random.Range(0, 52);
            deckList[i] = deckList[randomNumber];
            deckList[randomNumber] = temp;
        }
       
        for(int i = 0; i < 52; i++)
        {
            Debug.Log(deckList[i] + " ");
        }
        */
        // Debug.Log(deckList.Count);
       
        
    }

    public card SpawnCard(GameObject location, int cardNum, int whichHand)
    {
        /*
        GameObject cardCopy = Instantiate(gameObject);
        cardCopy.gameObject.SetActive(true);
        cardCopy.GetComponent<SpriteRenderer>().enabled = true;

        card CardObjCopy = cardCopy.GetComponent<card>();
        CardObjCopy.transform.SetParent(player1hand.transform, false);
        return CardObjCopy;
        */


        player1hand = GameObject.Find("player1hand");
        enemy1hand = GameObject.Find("enemy1hand");
        enemy2hand = GameObject.Find("enemy2hand");
        enemy3hand = GameObject.Find("enemy3hand");
        GameObject cardCopy = Instantiate(Card, new Vector3(0,0,0), Quaternion.identity);
        cardCopy.gameObject.SetActive(true);
        spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        card CardObjCopy = cardCopy.GetComponent<card>();
        CardObjCopy.transform.SetParent(location.transform, false);
        if (whichHand == 1)
        {
            PlayerHandController copy = PlayerHandController.GetComponent<PlayerHandController>();
            copy.playerHand.Add(cardNum);
            spriteRenderer.sprite = spriteArray[cardNum];
        }
        return CardObjCopy;
    }

    public void setSuit(string s)
    {
        suit = s;
    }
    public void setNum(string n)
    {
        number = n;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

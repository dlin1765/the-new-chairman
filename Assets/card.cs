using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    private string suit;
    private string number;
    private string color;
    public bool isPlayerCard;
    public bool clicked;
    public GameObject player1hand;
    public GameObject enemy1hand;
    public GameObject enemy2hand;
    public GameObject tablehand;
    public GameObject enemy3hand;
    public GameObject Card;
    private Vector3 temp;
    public GameObject PlayerHandController;
    private Vector3 mousePosition;
    public SpriteRenderer spriteRenderer;
    public Vector3 tablePosition; 
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

    public card SpawnCard(GameObject location, int cardNum, bool whichHand)
    {
        /*
        GameObject cardCopy = Instantiate(gameObject);
        cardCopy.gameObject.SetActive(true);
        cardCopy.GetComponent<SpriteRenderer>().enabled = true;

        card CardObjCopy = cardCopy.GetComponent<card>();
        CardObjCopy.transform.SetParent(player1hand.transform, false);
        return CardObjCopy;
        */
        Debug.Log("who's hand = " + whichHand);
        clicked = false;
        
        player1hand = GameObject.Find("player1hand");
        enemy1hand = GameObject.Find("enemy1hand");
        enemy2hand = GameObject.Find("enemy2hand");
        enemy3hand = GameObject.Find("enemy3hand");
        tablehand = GameObject.Find("tablehand");
        tablePosition = tablehand.transform.position;
        GameObject cardCopy = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
        cardCopy.gameObject.SetActive(true);
        spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        card CardObjCopy = cardCopy.GetComponent<card>();
        CardObjCopy.transform.SetParent(location.transform, false);
        if (whichHand)
        {
            Debug.Log("bro how");
            isPlayerCard = true;
            PlayerHandController copy = PlayerHandController.GetComponent<PlayerHandController>();
            copy.playerHand.Add(cardNum);
            spriteRenderer.sprite = spriteArray[cardNum];
            
        }
        else
        {
            isPlayerCard = false;
        }
        Debug.Log(isPlayerCard);
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
        if (clicked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
        }
    }
    void OnMouseDown()
    {
        Vector3[] arr = new Vector3[4];
        tablehand.GetComponent<RectTransform>().GetWorldCorners(arr);

        if (isPlayerCard)
        {
            if (clicked == true)
            {

                Debug.Log("mouse x = " + mousePosition.x + " mouse y = " + mousePosition.y);

                if (mousePosition.x > arr[0].x && mousePosition.x < arr[2].x && mousePosition.y > arr[0].y && mousePosition.y < arr[1].y)
                {
                    Debug.Log("in bounds");
                    isPlayerCard = false;

                }
                else
                {
                    transform.position = temp;

                }
                clicked = false;
                // drop the card into the tablehand grid and remove the number from the players hand
            }
            else
            {
                temp = transform.position;
                clicked = true;

            }
        }
            
    }
}

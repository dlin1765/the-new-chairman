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
    public GameObject _card;
    public GameObject _dialogue;
    private card saveTime;
    public int num;
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
        saveTime = _card.GetComponent<card>();
        



    }

    public card SpawnCard(GameObject location, int cardNum, bool whichHand)
    {
        Debug.Log("who's hand = " + whichHand);
        clicked = false;
        player1hand = GameObject.Find("player1hand");
        enemy1hand = GameObject.Find("enemy1hand");
        enemy2hand = GameObject.Find("enemy2hand");
        enemy3hand = GameObject.Find("enemy3hand");
        tablehand = GameObject.Find("tablehand");
        tablePosition = tablehand.transform.position;
        
        GameObject cardCopy = Instantiate(_card, new Vector3(0, 0, 0), Quaternion.identity);
        cardCopy.gameObject.SetActive(true);
        spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        card CardObjCopy = cardCopy.GetComponent<card>();
        CardObjCopy.transform.SetParent(location.transform, false);
        CardObjCopy.num = cardNum;
     
        /*
        Card = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
        Card.gameObject.SetActive(true);
        spriteRenderer = Card.GetComponent<SpriteRenderer>();
        card CardObjCopy = Card.GetComponent<card>();
        CardObjCopy.transform.SetParent(location.transform, false);
        */
        

        if (whichHand)
        {
            PlayerHandController copy = CardObjCopy.PlayerHandController.GetComponent<PlayerHandController>();
            copy.playerHand.Add(cardNum);
            CardObjCopy.isPlayerCard = true;
            spriteRenderer.sprite = spriteArray[cardNum];
        }
        else
        {
            CardObjCopy.isPlayerCard = false;
        }
        Debug.Log(isPlayerCard);
        return CardObjCopy;
    }

    public void setSuit(string s)
    {
        suit = s;
    }
    public void setNum(int n)
    {
        num = n;
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
        DialogManager dialogue = _dialogue.GetComponent<DialogManager>();
        if (dialogue.isDialogue)
        {

        }
        else
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
                        // drop the card into the tablehand grid and remove the number from the players hand
                        PlayerHandController copy = PlayerHandController.GetComponent<PlayerHandController>();
                        TableHandController copy1 = tablehand.GetComponent<TableHandController>();
                        saveTime.transform.SetParent(tablehand.transform, false);
                        copy1.tablesHand.Add(num);
                        int index1 = 0;
                        for (int i = 0; i < copy.playerHand.Count; i++)
                        {
                            if (copy.playerHand[i] == num)
                            {
                                index1 = i;
                                break;
                            }
                        }
                        copy.playerHand.RemoveAt(index1);
                        if (copy1.isFull())
                        {
                            copy1.readdCards();
                        }

                    }
                    else
                    {
                        transform.position = temp;

                    }
                    clicked = false;

                }
                else
                {
                    temp = transform.position;
                    clicked = true;

                }
            }

        }
            
    }
}

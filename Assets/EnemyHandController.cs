using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandController : MonoBehaviour
{

    public Animator animator;

    public int turnOrder;
    public bool started;

    public GameObject _card;
    public GameObject player1hand;
    public GameObject enemy1hand;
    public GameObject enemy2hand; 
    public GameObject enemy3hand;
    public GameObject _deck;
    public List<int> enemyHand;
    private string deckPrint;

    void Start()
    {
        //animator.SetBool("started", false);
    }

    // Update is called once per frame
    void Update()
    {
        
         
    }

    public void printDeck()
    {
        for (int i = 0; i < enemyHand.Count; i++)
        {
            Debug.Log(enemyHand[i] + " ");
        }
    }
}

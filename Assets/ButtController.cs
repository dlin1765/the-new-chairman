using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtController : MonoBehaviour
{
    public GameObject _card;
    public void CreateCard()
    {
        _card = GameObject.Find("Card");
        card cardCopy = _card.GetComponent<card>();
        cardCopy.SpawnCard();
        Debug.Log("Hello world");
    }
}

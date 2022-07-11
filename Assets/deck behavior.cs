using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deckbehavior : MonoBehaviour
{
    private List<card> thedeck = new List<card>();
    //private card c1 = new card("clubs", arr[i]);
    public deckbehavior()
    {
        string[] arr = new string[13];
        arr[0] = "ace";
        arr[1] = "two";
        arr[2] = "three";
        arr[3] = "four";
        arr[4] = "five";
        arr[5] = "six";
        arr[6] = "seven";
        arr[7] = "eight";
        arr[8] = "nine";
        arr[9] = "ten";
        arr[10] = "jack";
        arr[11] = "queen";
        arr[12] = "king";

        for(int i = 0; i < 13; i++)
        {
            thedeck.Add(new card("clubs", arr[i]));
        }
        for (int i = 0; i < 13; i++)
        {
            thedeck.Add(new card("spades", arr[i]));
        }
        for (int i = 0; i < 13; i++)
        {
            thedeck.Add(new card("diamonds", arr[i]));
        }
        for (int i = 0; i < 13; i++)
        {
            thedeck.Add(new card("hearts", arr[i]));
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

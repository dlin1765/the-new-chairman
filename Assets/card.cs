using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    private string suit;
    private string number;
    private string color;
    // Start is called before the first frame update
    void Start()
    {
        // add functionality to change the sprite based on the suit/number/color
        
    }

    public card(string s, string n)
    {
        suit = s;
        number = n; 
       
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

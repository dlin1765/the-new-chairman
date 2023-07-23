using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // The rules are simple, the first rule is there's no talking, the second is that there's no talking about the rules.
    // Start is called before the first frame update
    public Text startingText;
    public Text nameText;
    public bool isDialogue = false;
    public string sT;
    public string nT;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void StartDialogue(string theLine, string name)
    {
        
        startingText.text = theLine;
        nameText.text = name;
    }
}

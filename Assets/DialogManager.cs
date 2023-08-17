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
    public GameObject box;
    public bool isDialogue = false;
    public bool firstTalk = true;
    public string sT;
    public string nT;
    public List<DialogueSet> dialogueList;
    public GameObject enemyAI;
    public GameObject GameControllerCopy;

    void Start()
    {
        dialogueList = new List<DialogueSet>();
        isDialogue = false;
        box.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && isDialogue) // if isDialogue is true and the space bar is pressed it calls skip dialogue 
        {
            skipDialogue();
        }
    }


    public void StartDialogue(List<DialogueSet> d)
    {
        /*
        for (int i = 0; i < d.Count; i++) // add all the dialogue sets into dialogue list
        {
            dialogueList.Add(d[i]);
        }
        
        if (dialogueList.Count > 0) // if there's something in the dialogue list 
        {
            nameText.text = d[0].name;
            startingText.text = d[0].dialogue;
            dialogueList.RemoveAt(0); // set the text boxes to first dialogue set's stuff and remove it from the list CHANGE THIS BACK TO NON COMMENT
            isDialogue = true;
            startingText.gameObject.SetActive(true);
            nameText.gameObject.SetActive(true);
            box.gameObject.SetActive(true);
            StartCoroutine(DialogueTimer());
        }
        else
        {
            isDialogue = false;
        }
        */
        for (int i = 0; i < d.Count; i++) // add all the dialogue sets into dialogue list
        {
            dialogueList.Add(d[i]);
        }

        if (dialogueList.Count > 0) // if there's something in the dialogue list 
        {
            nameText.text = d[0].name;
            startingText.text = d[0].dialogue;
            dialogueList.RemoveAt(0); // set the text boxes to first dialogue set's stuff and remove it from the list CHANGE THIS BACK TO NON COMMENT
            isDialogue = true;
            startingText.gameObject.SetActive(true);
            nameText.gameObject.SetActive(true);
            box.gameObject.SetActive(true);
            StartCoroutine(DialogueTimer());
        }
        else
        {
            isDialogue = false;
        }

    }
    public void StartUnskippableDialogue(DialogueSet d)
    {
        StartCoroutine(RuleDialogue());
    }

    IEnumerator RuleDialogue()
    {

        yield return new WaitForSeconds(3f);
    }
    IEnumerator DialogueTimer()
    {   
        //yield return new WaitForSeconds(3f);
        
        double timer = 0.0;
        
        while (timer <= 50)
        {
            timer = timer + 0.1;
            if(Input.GetKeyDown("space") && isDialogue)
            {
                timer = 0.0;
               
            }
            yield return null;
        }
        
         skipDialogue();
        
        
    }
    
    public void skipDialogue()
    {
        //Debug.Log("good morning");
        if (dialogueList.Count > 0) // if the dialogue list has stuff in it it sets the text the second thing bc from start dialogue it removes the 
        {
            
            nameText.text = dialogueList[0].name;
            startingText.text = dialogueList[0].dialogue;
            dialogueList.RemoveAt(0);
            isDialogue = true;
            StartCoroutine(DialogueTimer());
        }
        else if (dialogueList.Count == 0) // if its zero, it destroys the boxes 
        {
            isDialogue = false;
            startingText.gameObject.SetActive(false);
            nameText.gameObject.SetActive(false);
            box.gameObject.SetActive(false);
            if(firstTalk)
            {
                EnemyHandController ai = enemyAI.GetComponent<EnemyHandController>();
                //ai.animator.SetBool("started", true);
              
                GameControl gC = GameControllerCopy.GetComponent<GameControl>();
                gC.StartGame();
                firstTalk = false;
            }
            // add functionality to set firstTalk back to true if you go back to start menu which i haven't done yet but will  
        }
        /*
        if (dialogueList.Count > 0) // if its still has stuff in it, remove the first thing 
        {
            dialogueList.RemoveAt(0);
        }
        */
    }
}

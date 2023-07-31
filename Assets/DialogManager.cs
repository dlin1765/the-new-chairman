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
        if (Input.GetKeyDown("space") && isDialogue)
        {
            skipDialogue();
        }
    }


    public void StartDialogue(List<DialogueSet> d)
    {
        

        for (int i = 0; i < d.Count; i++)
        {
            dialogueList.Add(d[i]);
        }
        nameText.text = d[0].name;
        startingText.text = d[0].dialogue;
        dialogueList.RemoveAt(0);
        if (dialogueList.Count > 0)
        {
            isDialogue = true;
            startingText.gameObject.SetActive(true);
            nameText.gameObject.SetActive(true);
            box.gameObject.SetActive(true);
        }
        else
        {
            isDialogue = false;
        }


    }
    
    public void skipDialogue()
    {
        if (dialogueList.Count > 0)
        {
            nameText.text = dialogueList[0].name;
            startingText.text = dialogueList[0].dialogue;
            isDialogue = true;
        }
        else if (dialogueList.Count == 0)
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
        if (dialogueList.Count > 0)
        {
            dialogueList.RemoveAt(0);
        }

    }
}

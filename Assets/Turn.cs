using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameControlCopy;
    public SpriteRenderer renderer;
    public GameObject DialogueManagerCopy;
    GameControl gc;

    void Start()
    {
        gc = GameControlCopy.GetComponent<GameControl>();
        renderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.state == GameControl.GameState.PLAYERTURN)
        {
            renderer.color = new Color(0f, 0f, 5f, 1f);
        }
        else if(gc.state == GameControl.GameState.ENEMYTURN)
        {
            renderer.color = new Color(5f, 0f, 0f, 1f);
        }
        
    }
    /*
    IEnumerator CheckForIllegalMove() //1 
    {

        drew = false;
        bool played;
        DialogueSet ds = new DialogueSet();
        List<DialogueSet> startWords = new List<DialogueSet>();
        p1.numCards = p1.playerHand.Count;
        cardTracker = p1.numCards; // 4 / 4! if  4-1 = 4 
        if (state == GameState.ENEMYTURN)
        {
            double timer = 0.0;
            while (timer <= 30)
            {
                testText.text = cardTracker + "/ " + p1.playerHand.Count + "!";
                timer = timer + 0.1;
                yield return null;
                if (p1.isClicked())
                {
                    timer = 0.0;
                    
                }
                played = playedCard();
                Debug.Log(played);
               


            }
            StartCoroutine(enemyTurn());
        }
        yield return null;
    }
    */
}

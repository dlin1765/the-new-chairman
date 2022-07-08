using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class thevoices : MonoBehaviour
{
    private KeywordRecognizer recognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("forward", Forward);
        actions.Add("day", Seven);
        recognizer = new KeywordRecognizer(actions.Keys.ToArray());
        recognizer.OnPhraseRecognized += RecognizedSpeech;
        recognizer.Start();
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward()
    {
        Debug.Log("have a nice day");
    }
    private void Seven()
    {
        Debug.Log("smelly man");
    }
}

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
    public List<string> phraseArr = new List<string>();
   
    public GameObject GameControlCopy;
    public SpriteRenderer renderer;
    GameControl gc;
    public event Action<float> BelowLowThreshold;
    public event Action<float> AboveHighThreshold;

    [SerializeField] private int _sampleWindow = 64;
    [SerializeField] private float _lowThreshold;
    [SerializeField] private float _highThreshold;

    private AudioClip _microphoneClip;
    private string _microphoneName;
    private bool _listening;
    private float _currentLoudness;

    public float lowThreshold => _lowThreshold;
    public float highThreshold => _highThreshold;
    public bool isListening => _listening;
    public float currentLoudness => _currentLoudness;

    public bool isTalking = false;
    public List<string> localPhraseArr = new List<string>();
    void Start()
    {
        Debug.Log(localPhraseArr.Count);
        actions.Add("forward", Forward);
        actions.Add("have a nice day", Seven);
        actions.Add("spades", Seven);
        actions.Add("clubs", Seven);
        actions.Add("hearts", Seven);
        actions.Add("diamonds", Seven);
        actions.Add("jack of spades", Seven);
        actions.Add("2 of spades", Seven);
        actions.Add("3 of spades", Seven);
        actions.Add("4 of spades", Seven);
        actions.Add("5 of spades", Seven);
        actions.Add("6 of spades", Seven);
        actions.Add("7 of spades", Seven);
        actions.Add("8 of spades", Seven);
        actions.Add("9 of spades", Seven);
        actions.Add("10 of spades", Seven);
        actions.Add("queen of spades", Seven);
        actions.Add("king of spades", Seven);
        actions.Add("i am the new chairman", Seven);
        gc = GameControlCopy.GetComponent<GameControl>();
        renderer = this.GetComponent<SpriteRenderer>();
        recognizer = new KeywordRecognizer(actions.Keys.ToArray());
        recognizer.OnPhraseRecognized += RecognizedSpeech;
        recognizer.Start();
    }
    void Awake()
    {
        _microphoneName = Microphone.devices[0];
        _microphoneClip = Microphone.Start(_microphoneName, true, 20, AudioSettings.outputSampleRate);
        if (_microphoneClip != null)
            _listening = true;
        else
            this.enabled = false;
    }

    public bool FindPhrases(List<string> phrases)
    {
        for (int i = 0; i < phrases.Count; i++)
        {
            if (!localPhraseArr.Contains(phrases[i]))
            {
                return false;
            }
        }
        return true;
    }

    void Update()
    {
        _currentLoudness = GetLoudnessFromAudioClip(Microphone.GetPosition(_microphoneName), _microphoneClip, _sampleWindow);

        /*if (_currentLoudness < _lowThreshold)
        {
            //BelowLowThreshold?.Invoke(_currentLoudness);
            Debug.Log("ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ");
        }

        else if (_currentLoudness > _highThreshold)
        {
            //AboveHighThreshold?.Invoke(_currentLoudness);
            Debug.Log("A:LKSJDLAS:JD:LKASJDLKJASDLKJASLKDJklj");
        }
        */
        if(_currentLoudness <= 0.0099) // tweak this maybe to see if this doesn't work with other mics //0.000099 too sensitive
        {
            isTalking = false;
            renderer.color = new Color(0f, 5f, 0f, 1f);
        }
        else
        {
            isTalking = true;
            renderer.color = new Color(5f, 0f, 0f, 1f);
        }
        //if(gc)
        
    }

    public static float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip, int sampleWindow)
    {
        var startPosition = clipPosition - sampleWindow;
        if (startPosition < 0) return 0;

        var waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        //compute loudness
        var totalLoudness = 0f;

        for (var i = 0; i < sampleWindow; ++i)
            totalLoudness += Mathf.Abs(waveData[i]);

        return totalLoudness / sampleWindow;
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
        /*
            if player turn, add it to the thing
            if not player turn, penalize 
        */
        localPhraseArr.Add(speech.text);
    }



    private void Forward()
    {
        //Debug.Log("have a nice day");
    }
    private void Seven()
    {
       
    }

    public void Clear()
    {
        localPhraseArr.Clear();
    }
    
}

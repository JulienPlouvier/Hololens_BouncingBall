using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class VoiceCommand : MonoBehaviour {

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();


    // Use this for initialization
    void Start () {

        keywords.Add("Reset", () => { this.BroadcastMessage("OnReset"); });
        keywords.Add("Forward", () => { this.BroadcastMessage("OnForward"); });
        keywords.Add("Backward", () => { this.BroadcastMessage("OnBackward"); });
        keywords.Add("Move", () => { this.BroadcastMessage("OnMove"); });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
            keywordAction.Invoke();
    }

}

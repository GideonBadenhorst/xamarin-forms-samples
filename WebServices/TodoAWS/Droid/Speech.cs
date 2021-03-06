﻿using Android.Speech.Tts;
using System.Collections.Generic;

namespace TodoAWSSimpleDB.Droid
{
    public class Speech : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech textToSpeech;
        string toSpeak;

        public void Speak(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                toSpeak = text;
                if (textToSpeech == null)
                {
                    textToSpeech = new TextToSpeech(MainActivity.Instance, this);
                }
                else
                {
                    var p = new Dictionary<string, string>();
                    textToSpeech.Speak(toSpeak, QueueMode.Flush, p);
                }
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                var p = new Dictionary<string, string>();
                textToSpeech.Speak(toSpeak, QueueMode.Flush, p);
            }
        }
    }
}

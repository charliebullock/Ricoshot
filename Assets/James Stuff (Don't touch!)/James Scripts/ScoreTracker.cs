using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    [Serializable]
    public class UICounters
    {
        public string name;
        public int counter;
        public Text counterDisplay;
    }
    public UICounters[] MenuCounters;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour
{
    private int scores;
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private TMP_Text _textOnPanel;

    public  void addScore()
    {
        scores++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        string i = scores.ToString();
        _text.text = "score: " +i;
        _textOnPanel.text = "score: " + i;
    }
}

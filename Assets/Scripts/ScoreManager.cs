using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private Int32 _score = 0;
    private TextMeshProUGUI _scoreText;
    public Int32 Score => _score;
    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void UpdateText()
    {
        _scoreText.text = $"{_score}";
    }
    public void AddScore()
    {
        _score += 1;
        UpdateText();
    }

    public void ResetScore()
    {
        _score = 0;
        UpdateText();
    }
}

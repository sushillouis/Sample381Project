using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString("D3");
    }
    public int score;
    public Text scoreText;
    // Update is called once per frame
    void Update()
    {
        
    }
}

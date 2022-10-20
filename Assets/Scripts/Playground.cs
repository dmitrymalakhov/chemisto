using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playground : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause(bool enable)
    {
        Time.timeScale = enable ? 0.0f : 1.0f;
    }

    public void SetScore(int score) {
        scoreText.text = "SCORE: " + score.ToString();
    }
}

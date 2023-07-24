using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI Title;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI HighScore;

    // Start is called before the first frame update
    void Start()
    {
        Score.text = "Score: " + GameManager.instance.Score.ToString();
        HighScore.text = "High Score: " + GameManager.instance.HighScore.ToString();
        GameManager.instance.Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgainPushed()
    {
        SceneManager.LoadScene("Level " + 1);
    }
}

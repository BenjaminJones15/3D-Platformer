using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score = 0;
    public int HighScore = 0;
    public static GameManager instance;

    public int CurrentLevel = 1;
    public int HighestLevel = 2;
    

    public void Awake()
    {
        if (instance == null) { 
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void IncreaseScore(int amount) {
        Score += amount;
        if (Score > HighScore) { 
            HighScore = Score;
        }
    }

    public void ResetLevel() { 
        Score = 0;
        CurrentLevel = 1;
        SceneManager.LoadScene("Level " + CurrentLevel);
    }

    public void NextLevel() {
        if (CurrentLevel < HighestLevel){
            CurrentLevel += 1;
        } else {
            CurrentLevel = 1;
        }

        SceneManager.LoadScene("Level " + CurrentLevel);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Score = 0;
    public int HighScore = 0;
    public static GameManager instance;
    private HUDManager hudmanager;

    public int CurrentLevel = 1;
    public int HighestLevel = 2;
    

    public void Awake()
    {
        if (instance == null) { 
            instance = this;
        } else if (instance != this){
            instance.hudmanager = FindObjectOfType<HUDManager>();
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        hudmanager = FindObjectOfType<HUDManager>();
    }

    public void IncreaseScore(int amount) {
        Score += amount;
        if (hudmanager != null){
            hudmanager.UpdateHUD();
        }
        if (Score > HighScore) {
            HighScore = Score;
        }
    }

    public void ResetLevel() {
        //might need to load cameras here too?
        Score = 0;
        if (hudmanager != null){
            hudmanager.UpdateHUD();
        }
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

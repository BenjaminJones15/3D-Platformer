using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHUD(){
        ScoreLabel.text = "Score: " + GameManager.instance.Score;
    }
}

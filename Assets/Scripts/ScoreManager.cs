using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;

    public int score = 0;
    
    void Awake() {
        // Singleton
        if(Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " ";
    }

    public void AddPoint() {
        score ++;
        scoreText.text = score.ToString() + " ";
    }

}

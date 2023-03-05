using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [FormerlySerializedAs("prefabs")]
    public List <GameObject> obstaclePrefabs;
    public float obstacleInterval = 1;
    public float obstacleSpeed = 10;
    public float obstacleOffsetX = 0;
    public Vector2 obstacleOffsetY = new Vector2 (0,0);
    public TextMeshProUGUI gameOverText;
    
    private bool isGameOver = false;

    void Awake ()
    {
        //Singleton
        if (Instance != null && Instance != this){
            Destroy(this);} 
            else{
                Instance = this;
                }
    }
    public bool IsGameActive() {
        return !isGameOver;
    }

    public bool IsGameOver() {
        return isGameOver;
    }

    public void EndGame() {
        // Set flag
        isGameOver = true;

        //Print Game Over
        gameOverText.gameObject.SetActive(true);

        // Reload scene
        StartCoroutine(ReloadScene(3));
    }
    private IEnumerator ReloadScene(float delay){
        // Wait
        yield return new WaitForSeconds(delay);

        // Reload scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}   

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    
    public GameObject gameOverPanel;
    public GameObject taptext;
    public Text score;
    public Text highscore1;
    public Text highscore2;
    public Text gameScore;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;   
        }
    }

    void Start()
    {
        highscore1.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void GameStart()
    {
        
        taptext.SetActive(false);
        





    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore2.text = PlayerPrefs.GetInt("HighScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }


    // Update is called once per frame
    void Update()
    {
        gameScore.text = ScoreManager.instance.score.ToString();
    }
}

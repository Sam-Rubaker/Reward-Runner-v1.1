using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager1 : MonoBehaviour
{
    bool startStop = false;

    // public int highscore;

    void Start()
    {
        // updateHighScore();
    }

    // public void MenuBtn()
    // {
    //     SceneManager.LoadScene("MainMenu");
    // }
    
    public TextMeshProUGUI scoreBox;
    public TextMeshProUGUI highBox;
    public int score = 0; //initialize score to 0
    

    public void UpdateScore(int update)
    {
        //update ui text score box
        //print("ehre");
        //scoreBox.tezxt = "Hello World";
        score = update + score; //update score by 1
        scoreBox.text = score.ToString(); //display new score

        // if(score > PlayerPrefs.GetInt("highscore", highscore))
        // {
        //     highscore=score;
        //     PlayerPrefs.SetInt("highscore", highscore);
        //     // updateHighScore();
        //     PlayerPrefs.Save();
        // }
    }

    public bool StartStop()
    {
        if(startStop == true)
        {
            startStop = false;
            return startStop;
        }
        else
        {
            startStop = true;
            return startStop;
            //Debug.Log("hello?");
        }
    }
    // public void updateHighScore(){
    //     highBox.text = PlayerPrefs.GetInt("highscore", highscore).ToString();
    // }
}

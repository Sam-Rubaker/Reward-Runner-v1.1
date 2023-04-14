using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    
    public TextMeshProUGUI highBox;

    public void Start(){
        updateHighScore();
    }

    public void StartBtn(){
        SceneManager.LoadScene("Main");
    }
    public void updateHighScore(){
        highBox.text = PlayerPrefs.GetInt("highscore").ToString();
    }
}

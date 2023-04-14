using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreBox;
    public int score = 0; //initialize score to 0
    public void UpdateScore(){
        //update ui text score box
        print("ehre");
        //scoreBox.text = "Hello World";
        score++; //update score by 1
        scoreBox.text = score.ToString(); //display new score
    }
}

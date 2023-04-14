using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameManager gameManager;
     public void OnTriggerEnter(Collider collider){ //<-- collider of object that we have collided with
        if(collider.gameObject.tag == "Obstacle"){
            print("Collided");
            //call GameManager Script function. 
            //The function in the GameManager script will update UI and update score.
            gameManager.GetComponent<GameManager>().UpdateScore();

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameManager.GetComponent<GameManager>().UpdateScore();
    }

    
}

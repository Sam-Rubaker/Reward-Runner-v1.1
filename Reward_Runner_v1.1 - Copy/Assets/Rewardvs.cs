using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewardvs : MonoBehaviour
{

   // GameObject[] changeObjects;

    void Start()
    {
        //changeObjects = GameObject.FindGameObjectWithTag("Obstacle");

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.tag == "Player"){
            // Debug.Log("Detected");
            Destroy(gameObject);
            //gameObject.tag.

        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medpoints : MonoBehaviour
{
    public AudioSource impactSound;

    GameManager1 gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager1>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.tag);
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player"){
            gm.UpdateScore(+25);
            impactSound.Play();
            Debug.Log("Detected");
            Destroy(gameObject);

        }
        //Debug.Log("Detected");
        //Debug.Log(other.gameObject.name);
    }
}

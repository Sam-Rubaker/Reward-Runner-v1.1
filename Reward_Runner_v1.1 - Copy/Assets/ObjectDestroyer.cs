using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    // Choose your audio sources for impacts
    public AudioSource highSound;
    public AudioSource medSound;
    public AudioSource lowSound;
    
    //
    public GameObject applePrefab;
    //
    public int numApplesToSpawn = 100; //This needs to >= number of rewards possible to collect. Janky, could be better.
    public Transform appleContainer;
    public Transform cartPosition;

    private List<GameObject> applePool;

    GameManager1 gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager1>();
        applePool = new List<GameObject>();
        
        // Generate the apples that will fill cart and make invisible initially
        for (int i = 0; i < numApplesToSpawn; i++)
        {
            GameObject apple = Instantiate(applePrefab);
            apple.transform.SetParent(transform);
            apple.SetActive(false);
            applePool.Add(apple);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectApple(GameObject apple)
    {
        apple.SetActive(false);
        applePool.Add(apple);

        GameObject containerApple = Instantiate(applePrefab);
        containerApple.transform.SetParent(appleContainer, false);
        containerApple.transform.localPosition = Vector3.zero;
        containerApple.SetActive(true);

        Rigidbody rb = containerApple.GetComponent<Rigidbody>();
        rb.useGravity = true;
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "High"){
            gm.UpdateScore(+50);
            highSound.Play();
            //Debug.Log("Detected");
            other.gameObject.SetActive(false);
            CollectApple(other.gameObject);
            CollectApple(other.gameObject);
            CollectApple(other.gameObject);
        }

        else if (other.gameObject.tag == "Med"){
            gm.UpdateScore(+25);
            medSound.Play();
            //Debug.Log("Detected");
            other.gameObject.SetActive(false);
            CollectApple(other.gameObject);
            CollectApple(other.gameObject);
        }

        else if (other.gameObject.tag == "Low"){
            gm.UpdateScore(+5);
            lowSound.Play();
            //Debug.Log("Detected");
            other.gameObject.SetActive(false);
            CollectApple(other.gameObject);
        }  
    }
}


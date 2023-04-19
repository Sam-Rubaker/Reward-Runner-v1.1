using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public AudioSource highSound;
    public AudioSource medSound;
    public AudioSource lowSound;

    public GameObject applePrefab;
    public int numApplesToSpawn = 26;
    public Transform appleContainer;
    public Transform cartPosition;

    private List<GameObject> applePool;


    GameManager1 gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager1>();
        applePool = new List<GameObject>();
        
        for (int i = 0; i <numApplesToSpawn; i++)
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
        

        //disperse collected apples
        // int numApplesInCart = appleContainer.childCount;
        // float xOffset = -(numApplesInCart - 1) *0.5f * appleContainer.GetChild(0).localScale.x;
        // containerApple.transform.localPosition += new Vector3(xOffset + (numApplesInCart - 1) * appleContainer.GetChild(0).localScale.x, 0, 0);
    }

    private void OnTriggerEnter(Collider other) {
        // Debug.Log(other.gameObject.tag);
        // Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "High"){
            gm.UpdateScore(+15);
            highSound.Play();
            //Debug.Log("Detected");
            other.gameObject.SetActive(false);
            CollectApple(other.gameObject);
            CollectApple(other.gameObject);
            CollectApple(other.gameObject);

        }
        else if (other.gameObject.tag == "Med"){
            gm.UpdateScore(+10);
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
        //Debug.Log("Detected");
        //Debug.Log(other.gameObject.name);
    }
}


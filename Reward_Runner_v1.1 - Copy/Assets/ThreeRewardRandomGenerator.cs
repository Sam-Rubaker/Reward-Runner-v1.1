using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeRewardRandomGenerator : MonoBehaviour
{
    // Create all variables that can be changed in unity depending on trial subject etc.
    // choose prefabs for rewards and which object that distance will be measured from (should be set to front of the treadmill or the HMD)
    public GameObject highReward;
    public GameObject medReward;
    public GameObject lowReward;
    public GameObject targetPrefab;

    // Declare how many shells there are - this should match how many rewards - TODO MAKE THIS MATCH AUTOMATICALLY
    // Also choose the shell prefab
    public GameObject[] shellPrefabs;
    
    // Enter 1 for a rich environment or 2 for poor - default is 1
    public int OneForRichTwoForPoor = 1;
    
    // Self expanatory
    public float objectSpacing = 50.0f;
    public float shellVisibleRange = 50.0f;
    public float rewardVisibleRange = 40.0f;
    
    //Choose the reward mesh and filter for physics, by default this is apple
    public Mesh mesh;
    public MeshFilter meshfilter;

    // Initialize various arrays and groups of game objects to be generated. Set index to 0 for collision counter
    private GameObject[] rewards;
    private GameObject[] shells;
    private float[] rewardDistances;
    private float[] shellDistances;
    private int currentObjectIndex = 0;
   
    void Start()
    {
        // Rich environment
        if (OneForRichTwoForPoor == 1)
        {
            // Create a list of the possible rewards
            List<GameObject> rewardTypes = new List<GameObject>();
            rewardTypes.AddRange(new GameObject[] 
            
            // // 70%-High, 20%-Med, 10%-Low      --------------------- TODO make this less clunky  
            // {   
            //     highReward, highReward, highReward, highReward, highReward, highReward, highReward,
            //     medReward, medReward,
            //     lowReward
            // });

            // 70%-High, 20%-Med, 10%-Low      --------------------- TODO make this less clunky  
            {   
                highReward, highReward, highReward, highReward, highReward, highReward, highReward, highReward, highReward, highReward, highReward, highReward, highReward, highReward,
                medReward, medReward, medReward, medReward,
                lowReward, lowReward
            });

            // Randomize the rewards
            ShuffleList(rewardTypes);

            // Instantiate rewards and shells
            rewards = new GameObject[rewardTypes.Count];
            shells = new GameObject[shellPrefabs.Length];
            rewardDistances = new float[rewards.Length];
            shellDistances = new float[shells.Length];

            // This is the good stuff. Generate rewards and shells at the preset spacing and randomized and then give them rigid bodies and colliders
            // for collision detection. Also give a tag to each depending on what it is. 
            // IMPORTANT - First create a tag in Unity that matches what you want each to be called, for some reason it doesn't create a 
            // new tag, just sets the gameObject.Tag to something already created. Shells don't need rigid bodies or collides

            for (int i = 0; i < rewardTypes.Count; i++)
            {
                GameObject newReward = Instantiate(rewardTypes[i], transform.position + new Vector3(-i * objectSpacing, 1.0f, 0.0f), Quaternion.identity, transform);
                newReward.transform.SetParent(transform);
                newReward.SetActive(false);
                newReward.AddComponent<MeshFilter>();
                newReward.AddComponent<MeshRenderer>();

                Rigidbody rb = newReward.AddComponent<Rigidbody>();
                rb.useGravity = false;
                BoxCollider collider = newReward.AddComponent<BoxCollider>();
                collider.isTrigger = true;

                if (rewardTypes[i] == highReward)
                {
                    newReward.tag = "High";
                }
                else if (rewardTypes[i] == medReward)
                {
                    newReward.tag = "Med";
                }
                else if (rewardTypes[i] == lowReward)
                {
                    newReward.tag = "Low";
                }
                
                rewards[i] = newReward;
            
                GameObject newShell = Instantiate(shellPrefabs[i], transform.position + new Vector3(-i * objectSpacing, 1.0f, 0.0f), Quaternion.identity, transform);
                newShell.transform.SetParent(transform);
                newShell.SetActive(false);
                shells[i] = newShell;
                newShell.tag = "Shell";
            }
        }

        // Poor environment - same as above
        else
        {
            List<GameObject> rewardTypes = new List<GameObject>();
            rewardTypes.AddRange(new GameObject[] 

            // // 70%-Low, 20%-Med, 10%-High      --------------------- TODO make this less clunky to change amount of rewards
            // {   
            //     lowReward, lowReward, lowReward, lowReward, lowReward, lowReward, lowReward,
            //     medReward, medReward,
            //     highReward
            // });

            // 70%-Low, 20%-Med, 10%-High      --------------------- TODO make this less clunky to change amount of rewards
            {   
                lowReward, lowReward, lowReward, lowReward, lowReward, lowReward, lowReward, lowReward, lowReward, lowReward, lowReward, lowReward, lowReward, lowReward,
                medReward, medReward, medReward, medReward,
                highReward, highReward
            });

            ShuffleList(rewardTypes);

            rewards = new GameObject[rewardTypes.Count];
            shells = new GameObject[shellPrefabs.Length];
            rewardDistances = new float[rewards.Length];
            shellDistances = new float[shells.Length];

            for (int i = 0; i < rewardTypes.Count; i++)
            {
                GameObject newReward = Instantiate(rewardTypes[i], transform.position + new Vector3(-i * objectSpacing, 1.0f, 0.0f), Quaternion.identity, transform);
                newReward.transform.SetParent(transform);
                newReward.SetActive(false);
                newReward.AddComponent<MeshFilter>();
                newReward.AddComponent<MeshRenderer>();

                Rigidbody rb = newReward.AddComponent<Rigidbody>();
                rb.useGravity = false;               
                BoxCollider collider = newReward.AddComponent<BoxCollider>();
                collider.isTrigger = true;

                if (rewardTypes[i] == highReward)
                {
                    newReward.tag = "High";
                }
                else if (rewardTypes[i] == medReward)
                {
                    newReward.tag = "Med";
                }
                else if (rewardTypes[i] == lowReward)
                {
                    newReward.tag = "Low";
                }
                
                rewards[i] = newReward;
            
                GameObject newShell = Instantiate(shellPrefabs[i], transform.position + new Vector3(-i * objectSpacing, 1.0f, 0.0f), Quaternion.identity, transform);
                newShell.transform.SetParent(transform);
                newShell.SetActive(false);
                shells[i] = newShell;
                newShell.tag = "Shell";
            }
        }      
    }

    void Update()
    {
        // Update reward and shell distances
        for (int i = 0; i < rewards.Length; i++)
        {
            rewardDistances[i] = Vector3.Distance(rewards[i].transform.position, targetPrefab.transform.position);
            shellDistances[i] = Vector3.Distance(shells[i].transform.position, targetPrefab.transform.position);
        }

        // Check if shell is within range and activate it
        if (shellDistances[currentObjectIndex] < shellVisibleRange && rewardDistances[currentObjectIndex] > rewardVisibleRange)
        {
            shells[currentObjectIndex].SetActive(true);
            rewards[currentObjectIndex].SetActive(false);
            
        }

        // Check if reward is within range and activate it and deactivate shell 
        else if (shellDistances[currentObjectIndex] < shellVisibleRange && rewardDistances[currentObjectIndex] <= rewardVisibleRange)
        {
            shells[currentObjectIndex].SetActive(false);
            rewards[currentObjectIndex].SetActive(true);
            currentObjectIndex++;  // TODO FIXIT - Something is happening here after the last reward is collected with indexing, doesn't break anything but gives error
        }

        else 
        {
            shells[currentObjectIndex].SetActive(false);
            rewards[currentObjectIndex].SetActive(false);
        }
    }

    // Create the shuffle method to randomize reward order
    void ShuffleList(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject temp = list[i];
            int randomIndex = Random.Range(i,list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }   
}
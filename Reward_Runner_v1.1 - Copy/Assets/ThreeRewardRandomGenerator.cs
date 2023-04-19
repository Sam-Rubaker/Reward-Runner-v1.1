using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeRewardRandomGenerator : MonoBehaviour
{
    public GameObject highReward;
    public GameObject medReward;
    public GameObject lowReward;

    public GameObject[] shellPrefabs;
    public float objectSpacing = 50.0f;
    public float shellVisibleRange = 50.0f;
    public float rewardVisibleRange = 50.0f;
    public GameObject targetPrefab;

    private GameObject[] rewards;
    private GameObject[] shells;
    private float[] rewardDistances;
    private float[] shellDistances;
    public int currentObjectIndex = 0;
   
    public Mesh mesh;
    public MeshFilter meshfilter;
    
    void Start()
    {
        // Create a list of the possible rewards
        List<GameObject> rewardTypes = new List<GameObject>();
        rewardTypes.AddRange(new GameObject[] 
        {   
            highReward, highReward, highReward, highReward, highReward, highReward, highReward,
            medReward, medReward,
            lowReward
        });

        ShuffleList(rewardTypes);

        // instantiate rewards and shells
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

                // give each reward a rigid body and box collider and a tag
                Rigidbody rb = newReward.AddComponent<Rigidbody>();
                rb.useGravity = false;
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
                
                BoxCollider collider = newReward.AddComponent<BoxCollider>();
                collider.isTrigger = true;
                
                rewards[i] = newReward;
            
                GameObject newShell = Instantiate(shellPrefabs[i], transform.position + new Vector3(-i * objectSpacing, 1.0f, 0.0f), Quaternion.identity, transform);
                newShell.transform.SetParent(transform);
                newShell.SetActive(false);
                shells[i] = newShell;
            }
            
    }

    void Update()
    {
        // update object distances
        for (int i = 0; i < rewards.Length; i++)
        {
            rewardDistances[i] = Vector3.Distance(rewards[i].transform.position, targetPrefab.transform.position);
            shellDistances[i] = Vector3.Distance(shells[i].transform.position, targetPrefab.transform.position);
        }

        // check if shell is within range and activate it
        if (shellDistances[currentObjectIndex] < shellVisibleRange && rewardDistances[currentObjectIndex] > rewardVisibleRange)
        {
            shells[currentObjectIndex].SetActive(true);
            rewards[currentObjectIndex].SetActive(false);
            
        }

        // check if object is within range and activate it
        else if (shellDistances[currentObjectIndex] < shellVisibleRange && rewardDistances[currentObjectIndex] <= rewardVisibleRange)
        {
            shells[currentObjectIndex].SetActive(false);
            rewards[currentObjectIndex].SetActive(true);
            currentObjectIndex++;
        }
        else 
        {
            shells[currentObjectIndex].SetActive(false);
            rewards[currentObjectIndex].SetActive(false);
        }
        

    }

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMain : MonoBehaviour
{
    GameManager1 gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        gm.StartStop();
    }
}

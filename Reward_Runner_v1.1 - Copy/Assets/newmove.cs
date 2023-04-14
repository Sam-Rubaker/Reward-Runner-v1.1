using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newmove : MonoBehaviour
{
    GameManager1 gm;
    //bool startStop = false; 

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) ){//&& gm.StartStop())
            this.transform.position -= transform.forward * 0.02f;
            //gm.UpdateScore(1);
            
        }
        // else if (Input.GetKeyDown(KeyCode.S))
        //     this.transform.position += Vector3.back;
        else if (Input.GetKeyDown(KeyCode.A))
            this.transform.position += Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D))
            this.transform.position += Vector3.right;
    }
}

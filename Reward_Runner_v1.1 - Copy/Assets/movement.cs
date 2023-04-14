using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class movement : MonoBehaviour
{
    

    public Button myButton;
    // public bool Stop_Start;
    // Start is called before the first frame update
    void Start()
    {
        // Button btn = myButton.GetComponent<Button>();
        // btn.onClick.AddListener(TaskOnClick);
        // Stop_Start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //if (start && Input.GetKeyDown(KeyCode.W)) //Stop_Start == true && 
            this.transform.position += Vector3.right/25;
        else if (Input.GetKeyDown(KeyCode.S))
            this.transform.position += Vector3.back;
        else if (Input.GetKeyDown(KeyCode.A))
            this.transform.position += Vector3.left;
        else if (Input.GetKeyDown(KeyCode.D))
            this.transform.position += Vector3.right;
    }

    // void TaskOnClick() {
    //     if(Stop_Start == false){
    //         Stop_Start = true;
    //     }
    //     else{
    //         Stop_Start = false;
    //     }
    // }
}

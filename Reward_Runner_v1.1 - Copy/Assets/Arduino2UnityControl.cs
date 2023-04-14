using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduino2UnityControl : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM6",9600);
    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(sp.IsOpen)
        {
            // try
            // {
                if(sp.ReadByte()==1)
                {
                    print(sp.ReadByte());
                    transform.Translate(Vector3.left * 1/4);

                }

            // }
            // catch(System.Exception)
            // {
                
            // }
        }
        
    }
}

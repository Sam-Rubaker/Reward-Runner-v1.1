using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Diagnostics;
using System.Threading;

public class readSocket : MonoBehaviour
{
     //Use this for initialization of Unity as the listener
     TcpListener listener;
     float tmSpeed;
     Stopwatch timePer = new Stopwatch();
     float timeSince;
  
     // Start is called before the first frame update
     void Start()
     {
          listener = new TcpListener (IPAddress.Parse("127.0.0.1"),55001);
          listener.Start();
          UnityEngine.Debug.Log("is listening");
          timePer.Start();
     }

    //Update is called once per frame
    void Update()
     {      
          timePer.Stop();  
          timeSince = (float)timePer.ElapsedMilliseconds;
          //UnityEngine.Debug.Log("timeSince is reading:" + timeSince);
       
          // Move the environment forward, 
          this.transform.position += Vector3.right * tmSpeed * timeSince / 1000.0f;
          timePer.Restart();

          if(!listener.Pending())                        
          {
               // UnityEngine.Debug.Log("inside not pending");
          }
          else
          {

          //UnityEngine.Debug.Log("socket comes");

          TcpClient client = listener.AcceptTcpClient();
          NetworkStream ns = client.GetStream();
          StreamReader reader = new StreamReader(ns);

          tmSpeed = float.Parse(reader.ReadLine(),CultureInfo.InvariantCulture.NumberFormat);
          // UnityEngine.Debug.Log("tmSpeed is reading:" + tmSpeed);

          }
     }
}




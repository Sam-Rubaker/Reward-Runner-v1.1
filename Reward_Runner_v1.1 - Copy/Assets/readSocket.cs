using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    // float countdownTimer;

     Stopwatch timePer = new Stopwatch();
     float timeSince;

     // public float timeRemaining = 10;
     // public Text countdownText;
  
     // Start is called before the first frame update
     void Start()
     {
          listener = new TcpListener (IPAddress.Parse("127.0.0.1"),55001);
          listener.Start();
          //UnityEngine.Debug.Log("is listening");
          timePer.Start();
     }


    //Update is called once per frame 
    void Update()
     {      
          timePer.Stop();  
          timeSince = (float)timePer.ElapsedMilliseconds;
          //UnityEngine.Debug.Log("timeSince is reading:" + timeSince);
       
          // Move the environment forward, 
          this.transform.position += Vector3.right * tmSpeed * timeSince / 955.0f;
          // if (tmSpeed == 0)
          // {
          //      tmSpeed = 2;
          // }
          // this.transform.position += Vector3.right * (2.0f - tmSpeed) * timeSince / 955.0f;



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
//////////////////////////////////////////////////////////////////////////////////////////////////
          if (reader.Peek() >= 0)
               {
               string line = reader.ReadLine();
               if (line != null)
               {
                    float value;
                    if (float.TryParse(line, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                    {
                         if (value == 42)
                         {
                              //UnityEngine.Debug.Log("Start Countdown timer");
                              GameObject countdownTimer = GameObject.FindGameObjectWithTag("Timer");
                              countdownTimer.SetActive(false);
                         }
                         else
                         {
                              tmSpeed = value;
                         }
                    }
                    else
                    {
                         //UnityEngine.Debug.Log("Could not parse float value");
                    }
               }
          }

//////////////////////////////////////////////////////////////////////////////////////////////////////////



     //      if (float.Parse(reader.ReadLine(),CultureInfo.InvariantCulture.NumberFormat) == 42)
     //      {
     //           UnityEngine.Debug.Log("Start Countdown timer");
     //           GameObject countdownTimer = GameObject.FindGameObjectWithTag("Timer");
     //           countdownTimer.SetActive(false);
     //      }
     //      else
     //      {
     //           tmSpeed = float.Parse(reader.ReadLine(),CultureInfo.InvariantCulture.NumberFormat);

     //      }
     //     // countdownTimer = float.Parse(reader.ReadLine(),CultureInfo.InvariantCulture.NumberFormat);
     //      //UnityEngine.Debug.Log("tmspeed" + tmSpeed);

          }
     }
}




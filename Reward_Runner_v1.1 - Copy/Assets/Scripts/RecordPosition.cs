using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Text;

public class RecordPosition : MonoBehaviour
{
    public Vector3 QuadPosition;
    public Vector3 QuestPosition;
    // public Vector3 QuestRotation;
    // public Vector3 LeftShoePosition;
    // public Vector3 LeftShoeRotation;
    // public Vector3 RightShoePosition;
    // public Vector3 RightShoeRotation;

    public int newCount = 1;
    string sessionFolder;
    public string subject;
    public string trial;

    public int highRewardLog;
    public int medRewardLog;
    public int lowRewardLog;

    public int shellLog;
    void Start()
    {
        //Create a new directory for each subject if one does not already exist
        string slashes = "\\";
        // string subjectFolder = "E:\\Users\\jsamr\\OneDrive - UCB-O365\\Thesis Work\\PositionData\\" + subjectID;
        // C:\\Users\\Vicon-OEM\Documents\\GitHub\\Reward-Runner-v1.1\\Reward_Runner_v1.1 - Copy\\Assets\\PositionData\\
        //string subjectFolder = "F:\\Users\\Public\\Documents\\Unity\\Dec10ObstacleRunner\\Working Box Runnerv2\\Assets\\PositionData\\" + subjectID;
        string subjectFolder = "C:\\Users\\Vicon-OEM\\Documents\\GitHub\\Reward-Runner-v1.1\\Reward_Runner_v1.1 - Copy\\Assets\\PositionData\\" + subject + slashes;
        string countPath = subjectFolder + "count.csv";
        
        //Check to see if the directory already exists and if it does, add 1 to the count
        if (Directory.Exists(subjectFolder)) 
        {
            //Debug.Log("Subject Folder already Exists, adding 1 to count");
            
            //Adding 1 to the count file
            using (var reader = new StreamReader(countPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    int record = (csv.GetField<int>("Count"));
                    //Debug.Log("The current count is " + record);
                    newCount = newCount + record;
                    //Debug.Log("The new count is " + newCount);
                }
           
            }

            var updatedCount = new List<Foo1> { new Foo1 { Count = newCount + 1 } };
            using (var writer = new StreamWriter(countPath))
            using (var csv1 = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv1.WriteRecords(updatedCount);
            }


        }


        //if the directory does not exist, create it and a "count" file inside it to be used for making unique trial CSVs 
        else
        {
            //creating subject folder
            var count = new List<Foo1>
            {
                new Foo1 {Count = 1}
            };

            Directory.CreateDirectory(subjectFolder);
            using (var writer = new StreamWriter(countPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture) )
            {
                csv.WriteRecords(count);
            }
        }

        //Get position on startup
        QuadPosition = GameObject.Find("Quad").transform.position;
        QuestPosition = GameObject.Find("Quest1").transform.position;
        // QuestRotation = GameObject.Find("Quest1").transform.eulerAngles;
        // LeftShoePosition = GameObject.Find("LeftShoe").transform.position;
        // LeftShoeRotation = GameObject.Find("LeftShoe").transform.eulerAngles;
        // RightShoePosition = GameObject.Find("RightShoe").transform.position;
        // RightShoeRotation = GameObject.Find("RightShoe").transform.eulerAngles;
        highRewardLog = GameObject.FindGameObjectsWithTag("High").Length;
        medRewardLog = GameObject.FindGameObjectsWithTag("Med").Length;
        lowRewardLog = GameObject.FindGameObjectsWithTag("Low").Length;
        shellLog = GameObject.FindGameObjectsWithTag("Shell").Length;


        float quadX = QuadPosition.x;
        // float quadY = QuadPosition.y;
        // float quadZ = QuadPosition.z;

        float questX = QuestPosition.x;
        float questY = QuestPosition.y;
        float questZ = QuestPosition.z;
        // float questRx = QuestRotation.x;
        // float questRy = QuestRotation.y;
        // float questRz = QuestRotation.z;

        // float leftX = LeftShoePosition.x;
        // float leftY = LeftShoePosition.y;
        // float leftZ = LeftShoePosition.z;
        // float leftRx = LeftShoeRotation.x;
        // float leftRy = LeftShoeRotation.y;
        // float leftRz = LeftShoeRotation.z;

        // float rightX = RightShoePosition.x;
        // float rightY = RightShoePosition.y;
        // float rightZ = RightShoePosition.z;
        // float rightRx = RightShoeRotation.x;
        // float rightRy = RightShoeRotation.y;
        // float rightRz = RightShoeRotation.z;
        
        // Create csv headers that align with Foo class
        var records = new List<Foo>
        {
            new Foo { Time = GetTimeStamp(),HighRewardLog = highRewardLog, MedRewardLog = medRewardLog, LowRewardLog = lowRewardLog, ShellLog = shellLog, QuadX = quadX,  //QuadY = quadY,  QuadZ = quadZ, 
                                            QuestX = questX, QuestY = questY, QuestZ = questZ}, // QuestRx = questRx, QuestRy = questRy, QuestRz = questRz,
                                            // LeftX = leftX, LeftY = leftY, LeftZ = leftZ, LeftRx = leftRx, LeftRy = leftRy, LeftRz = leftRz,
                                            // RightX = rightX, RightY = rightY, RightZ = rightZ, RightRx = rightRx, RightRy = rightRy, RightRz = rightRz},
        };

        // Create new session folders
        string counter = (subject + newCount.ToString() + trial + ".csv");
        using (var writer = new StreamWriter(subjectFolder + counter))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            csv.WriteRecords(records);
        sessionFolder = subjectFolder + counter;
    }


    void Main()
    {
        QuadPosition = GameObject.Find("Quad").transform.position;
        QuestPosition = GameObject.Find("Quest1").transform.position;
        // QuestRotation = GameObject.Find("Quest1").transform.eulerAngles;
        // LeftShoePosition = GameObject.Find("LeftShoe").transform.position;
        // LeftShoeRotation = GameObject.Find("LeftShoe").transform.eulerAngles;
        // RightShoePosition = GameObject.Find("RightShoe").transform.position;
        // RightShoeRotation = GameObject.Find("RightShoe").transform.eulerAngles;
        highRewardLog = GameObject.FindGameObjectsWithTag("High").Length;
        medRewardLog = GameObject.FindGameObjectsWithTag("Med").Length;
        lowRewardLog = GameObject.FindGameObjectsWithTag("Low").Length;
        shellLog = GameObject.FindGameObjectsWithTag("Shell").Length;

        float quadX = QuadPosition.x;
        // float quadY = QuadPosition.y;
        // float quadZ = QuadPosition.z;

        float questX = QuestPosition.x;
        float questY = QuestPosition.y;
        float questZ = QuestPosition.z;
        // float questRx = QuestRotation.x;
        // float questRy = QuestRotation.y;
        // float questRz = QuestRotation.z;

        // float leftX = LeftShoePosition.x;
        // float leftY = LeftShoePosition.y;
        // float leftZ = LeftShoePosition.z;
        // float leftRx = LeftShoeRotation.x;
        // float leftRy = LeftShoeRotation.y;
        // float leftRz = LeftShoeRotation.z;

        // float rightX = RightShoePosition.x;
        // float rightY = RightShoePosition.y;
        // float rightZ = RightShoePosition.z;
        // float rightRx = RightShoeRotation.x;
        // float rightRy = RightShoeRotation.y;
        // float rightRz = RightShoeRotation.z;

        var records = new List<Foo>
        {
            new Foo { Time = GetTimeStamp(), HighRewardLog = highRewardLog, MedRewardLog = medRewardLog, LowRewardLog = lowRewardLog, ShellLog = shellLog, QuadX = quadX,  //QuadY = quadY,  QuadZ = quadZ,  
                                            QuestX = questX, QuestY = questY, QuestZ = questZ}, // QuestRx = questRx, QuestRy = questRy, QuestRz = questRz,
                                            // LeftX = leftX, LeftY = leftY, LeftZ = leftZ, LeftRx = leftRx, LeftRy = leftRy, LeftRz = leftRz,
                                            // RightX = rightX, RightY = rightY, RightZ = rightZ, RightRx = rightRx, RightRy = rightRy, RightRz = rightRz},
        };

        // Append to the file.
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            // Don't write the header again.
            HasHeaderRecord = false,
        };
        using (var stream = File.Open(sessionFolder, FileMode.Append))
        using (var writer = new StreamWriter(stream))
        using (var csv = new CsvWriter(writer, config))
            csv.WriteRecords(records);
    }



    // Update is called once per frame

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            Main();
            


        }
    }


    public struct Foo
    {
        public string Time { get; set; }

        public int HighRewardLog {get; set; }
        public int MedRewardLog {get; set; }
        public int LowRewardLog {get; set; }
        public int ShellLog {get; set; }

        public float QuadX { get; set;}
        // public float QuadY { get; set;}
        // public float QuadZ { get; set;}

        public float QuestX { get; set; }
        public float QuestY { get; set; }
        public float QuestZ { get; set; }
        // public float QuestRx { get; set; }
        // public float QuestRy { get; set; }
        // public float QuestRz { get; set; }

        // public float LeftX { get; set; }
        // public float LeftY { get; set; }
        // public float LeftZ { get; set; }
        // public float LeftRx { get; set; }
        // public float LeftRy { get; set; }
        // public float LeftRz { get; set; }

        // public float RightX { get; set; }
        // public float RightY { get; set; }
        // public float RightZ { get; set; }
        // public float RightRx { get; set; }
        // public float RightRy { get; set; }
        // public float RightRz { get; set; }
    }

    public struct Foo1
    {
        public int Count { get; set; }
       
    }
    static string GetTimeStamp()
    {
        //return System.DateTime.Now.ToString();
        return System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();

    }



}

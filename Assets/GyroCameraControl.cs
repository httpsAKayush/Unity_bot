using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class GyroSender : MonoBehaviour
{
    private UdpClient udpClient;
    private string serverIP = "192.168.137.122"; // Broadcast IP for local network
    private int port = 12345;
    private Vector3 rot; // Rotation rate
    private string mov; // Movement direction

    void Start()
    {
        rot = Vector3.zero;
        // Enable the gyroscope
        Input.gyro.enabled = true;

        // Initialize the UdpClient with broadcast enabled
        try
        {
            udpClient = new UdpClient();
            udpClient.EnableBroadcast = true;
            Debug.Log("UDP client initialized with broadcast enabled");
        }
        catch (SocketException e)
        {
            Debug.LogError("SocketException: " + e.Message);
        }
    }

    void Update()
    {
        if (udpClient != null)
        {
            // Read gyroscope data
            rot.x = -Input.gyro.rotationRateUnbiased.x;
            rot.y = -Input.gyro.rotationRateUnbiased.y;
            rot.z = Input.gyro.rotationRateUnbiased.z;

            // Apply rotation to the object
            transform.Rotate(rot.x, rot.y, rot.z);

            // Get the current rotation in world space (Euler angles)
            Vector3 worldRotation = transform.rotation.eulerAngles;

            // Determine movement direction
            if (worldRotation.y > 30f && worldRotation.y <= 180f)
            {
                mov = "RIGHT";
            }
            else if (worldRotation.y > 180f && worldRotation.y <= 330f)
            {
                mov = "LEFT";
            }
            else if (worldRotation.x > 7f && worldRotation.x <= 180f)
            {
                mov = "BACKWARD";
            }
            else
            {
                mov = "FORWARD";
            }

            // Create and send the movement data
            string dataToSend = mov;
            byte[] data = Encoding.ASCII.GetBytes(dataToSend);
            udpClient.Send(data, data.Length, serverIP, port);

            Debug.Log("Sent: " + dataToSend);
        }
    }

    void OnApplicationQuit()
    {
        // Close the UDP client
        if (udpClient != null)
        {
            udpClient.Close();
            Debug.Log("UDP client closed");
        }
    }
}



// using System.Net.Sockets;
// using System.Text;
// using Unity.VisualScripting;
// using UnityEngine;

// public class GyroSender : MonoBehaviour
// {
//     private TcpClient client;
//     private NetworkStream stream;
//     private string serverIP = "192.168.137.195"; // Replace with ESP8266 IP
//     private int port = 12345;
//     Vector3 rot; // Rotation rate
//     string dir;
//     string mov;

//     void Start()
//     {
//         rot = Vector3.zero;
//         // Enable the gyroscope
//         Input.gyro.enabled = true;

//         // Connect to the ESP8266
//         try
//         {
//             client = new TcpClient(serverIP, port);
//             stream = client.GetStream();
//             Debug.Log("Connected to ESP8266");
//         }
//         catch (SocketException e)
//         {
//             Debug.LogError("SocketException: " + e.Message);
//         }
//     }

//     void Update()
//     {
//         if (stream != null && stream.CanWrite)
//         {
//             // Read gyroscope data
//             rot.x = -Input.gyro.rotationRateUnbiased.x;
//             rot.y = -Input.gyro.rotationRateUnbiased.y;
//             rot.z = Input.gyro.rotationRateUnbiased.z;

//             // Apply rotation to the object
//             transform.Rotate(rot.x, rot.y, rot.z);

//             // Get the current rotation in world space (Euler angles)
//             Vector3 worldRotation = transform.rotation.eulerAngles;

//             // Log and send the rotation data
//             Debug.Log("World Rotation: " + worldRotation);

//             if(worldRotation.y>=0f){
//                 if(worldRotation.y<=180f && worldRotation.y>=30f){
                      
//                         dir = "RIGHT";
//                 }
//                 else if(worldRotation.y>=180f && worldRotation.y<=330f){
                
//                     dir = "LEFT";
//                 }
//                 else{
//                     dir="";
//                 }
//             }
            
//             if(worldRotation.x>=0){
//                       if(worldRotation.x>7f && worldRotation.x<=180f){
//                            mov = "BACKWARD";}
//                       else{
//                       mov = "FORWARD";
//                       }
//             }
            
            


//             // Create a string with the data
//             string dataToSend = $"MOV:{mov},DIR:{dir}\n";

//             // Convert to bytes and send
//             byte[] data = Encoding.ASCII.GetBytes(dataToSend);
//             stream.Write(data, 0, data.Length);

//             Debug.Log("Sent: " + dataToSend);
//         }
//     }

//     void OnApplicationQuit()
//     {
//         // Close the connection
//         if (stream != null) stream.Close();
//         if (client != null) client.Close();
//         Debug.Log("Connection closed");
//     }
// }

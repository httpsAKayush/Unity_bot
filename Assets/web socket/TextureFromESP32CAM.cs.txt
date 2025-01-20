// using NativeWebSocket;
// using UnityEngine;

// public class TextureFromESP32CAM : MonoBehaviour
// {
//     private WebSocket _webSocket;

//     // Start is called before the first frame update
//     async void Start()
//     {
//         _webSocket = new WebSocket(url:"ws://192.168.201.41:8000");
//         _webSocket.OnOpen += () => { print("Connection Open!"); };
//         _webSocket.OnError += (e) => { print("Error :" + e); };
//         _webSocket.OnClose += (e) => { print("Connection Close!"); };
//         _webSocket.OnMessage += (bytes) =>   print("onMessage length :" + bytes.Length);
//         await _webSocket.Connect();

        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//     }

//     private async void OnApplicationQuit()
//     {
//         await _webSocket.Close();
//     }
// }


using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;

public class ESP32CameraFeed : MonoBehaviour
{
    [Header("WebSocket Configuration")]
    [Tooltip("WebSocket URL of the ESP32-CAM")]
    [SerializeField] private string websocketURL = "ws://192.168.132.41:8888";

    [Header("UI Configuration")]
    [Tooltip("RawImage component for displaying the camera feed")]
    public RawImage display;

    private WebSocket ws;
    private Texture2D texture;
    private bool frameUpdated = false;
    private byte[] latestFrameData;

    void Start()
    {
        // Validate RawImage assignment
        if (display == null)
        {
            Debug.LogError("RawImage not assigned! Please assign a RawImage in the Inspector.");
            return;
        }

        // Initialize WebSocket
        try
        {
            ws = new WebSocket(websocketURL);
            ws.OnMessage += OnWebSocketMessage;
            ws.OnOpen += (sender, e) => Debug.Log("WebSocket connected!");
            ws.OnError += (sender, e) => Debug.LogError($"WebSocket Error: {e.Message}");
            ws.OnClose += (sender, e) => Debug.LogWarning("WebSocket closed!");

            ws.Connect();
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to initialize WebSocket: {ex.Message}");
        }
    }

    private void OnWebSocketMessage(object sender, MessageEventArgs e)
    {
        if (e.IsBinary)
        {
            latestFrameData = e.RawData;
            frameUpdated = true;
        }
    }

    void Update()
    {
        if (frameUpdated && latestFrameData != null)
        {
            frameUpdated = false;

            try
            {
                if (texture == null)
                {
                    texture = new Texture2D(2, 2);
                }

                texture.LoadImage(latestFrameData);
                display.texture = texture;
                display.SetNativeSize();
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error updating texture: {ex.Message}");
            }
        }
    }

    void OnDestroy()
    {
        if (ws != null)
        {
            ws.Close();
            ws = null;
        }
    }
}

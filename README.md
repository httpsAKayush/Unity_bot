VR-Controlled Bot

A VR-controlled bot using a Unity APK, a mobile headset (gyro sensor), ESP8266, and an ESP32-CAM. This project enables real-time control of a robot using head movements, allowing immersive navigation and camera streaming.

Features

VR Headset Control: Uses a mobile phone's gyroscope sensor to control the bot's movement.

Real-Time Video Streaming: ESP32-CAM streams live footage from the bot's perspective.

Wireless Communication: ESP8266 facilitates communication between Unity and the bot.

WebSocket Integration: The hardware and server components are handled via WebSocket communication.

Project Structure

Unity_bot/
├── Assets/
│   ├── WebSocket.zip  # Contains hardware and server-related scripts
│   ├── Scripts/        # Unity C# scripts for bot control
│   ├── Scenes/         # Unity scenes for the VR interface
│   ├── Prefabs/        # Prefabricated game objects
│   ├── Models/         # 3D models used in the application
│   ├── Textures/       # Textures for UI and objects
├── README.md          # Project documentation

Requirements

Hardware:

Mobile phone with a gyroscope sensor

VR headset (e.g., Google Cardboard)

ESP8266

ESP32-CAM

Motor driver & chassis

Software:

Unity Engine (latest version recommended)

Arduino IDE (for ESP8266 & ESP32-CAM programming; included in WebSocket.zip)

WebSocket Server (included in WebSocket.zip)

Setup & Installation

Unity Setup:

Clone this repository.

Open Unity_bot in Unity.

Import WebSocket.zip inside Assets/.

Build the Unity project as an APK and install it on your mobile device.

Hardware Setup:

Flash the ESP8266 and ESP32-CAM with the provided firmware (inside WebSocket.zip).

Power the ESP8266 and ESP32-CAM with an appropriate power source.

Ensure your mobile device and ESP modules are connected to the same network.

Running the Project:

Launch the Unity APK on your mobile headset.

Start the WebSocket server from WebSocket.zip.

Move your head to control the bot and view the camera feed in real time.

Future Improvements

Implementing AI-based path correction.

Enhancing WebRTC-based low-latency video streaming.

Adding voice command support.

Contributing

Feel free to fork this repository, create issues, and submit pull requests for improvements.

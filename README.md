VR Controlled Bot
📌 Project Overview
A VR-controlled bot using a mobile headset's gyroscope, ESP8266, and ESP32-CAM. Control the bot with head movements while receiving a live video feed via WebSockets.

🛠️ Components Used
Unity APK → VR interface for head-tracking control.
ESP8266 → Handles WebSocket communication & motor control.
ESP32-CAM → Streams live video feed.
WebSocket Server → Enables real-time communication.
📂 Project Structure
scss
Copy
Edit
VR-Controlled-Bot/
│── Unity_bot/  
│   ├── Assets/  
│   │   ├── WebSocket (Contains server & hardware-related files)  
│   ├── APK (Unity Android application)  
│── Hardware/ (ESP8266 & ESP32-CAM code)  
│── README.md  
⚡ Key Features
✅ Head-tracking control – Move the bot by tilting your head.
✅ Live video streaming – Real-time view from ESP32-CAM.
✅ Low-latency WebSocket communication – Faster response times.
✅ Standalone system – Works with a mobile VR headset.

🚀 How to Set Up
1️⃣ Flash ESP8266 with motor control & WebSocket server code.
2️⃣ Flash ESP32-CAM for live video streaming.
3️⃣ Install Unity APK on an Android device with a VR headset.
4️⃣ Ensure all devices are on the same network.
5️⃣ Tilt your head to navigate the bot!

🔥 Future Enhancements
🎙️ Voice commands for extra control.
🤖 AI-based obstacle detection.
🚀 Optimized WebSocket performance for even smoother control.

# Audiology-Version-2

### Project Overview
The Audiology Interactive Learning Application is a cutting-edge digital project aimed at enhancing the learning experience for audiology students, professionals, and individuals interested in the field. This project focuses on developing an immersive, user-friendly, and engaging platform that covers various aspects of audiology, including hearing assessment, hearing aid and more.
https://miro.com/app/board/uXjVOxO0kDs=/

### Purpose
The Audiology Interactive Learning Platform aims to revolutionize audiology education and training, providing an innovative solution for learners at all stages of their professional journey. With its combination of immersive learning experiences, personalized pathways, and collaborative features, this platform will be a valuable resource for the audiology community.
Unity version 2021.3.11f

## Converting to Desktop version
- ### Main Menu Controller Script
  - Awake function
      - Set StateNameController.IsDesktopVersion to true
- ### Title Screen Scene  
  -  Canvas
      - Disable Curve UI Setting
  -  XRRigPlayer
      - Disable Canvas Cursor GameObject
      - Disable CUI Camera Controller
  - Event System
      - Disable curved UI Input Module
      - Enable Standalone Input Module

- ### Game 1 Scene
  - MainCanvas GameObject
      - Disable Curve UI Settings
  - MainMenuPanel 
      - Disable Curve UI Settings
  - Event System
      - Disable curved UI Input Module
      - Enable Standalone Input Module
  - XRRigPlayer	
      - Disable Canvas Cursor GameObject
      - Disable CUI Camera Controller
 - ### Button Control Script
    - // Create a condition statement to handle desktop version
 - ### SkyBoxVideo Script
    - // Create a condition statement to handle desktop version


 

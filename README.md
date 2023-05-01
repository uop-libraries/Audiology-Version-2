# Audiology-Version-2

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


 

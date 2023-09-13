
# Uploading projects to the Google Play Store

### Prerequisites & Suggestions
- The maximum size for your project should be around a gigabyte. To be hyper specific, Google Play asks that it is under 1.073741824 gigabytes.
- If your project is larger than that, this guide will not help you. Google Play is very stingy when it comes to file size! I researched quite a bit into how we could upload something larger, but all my attempts came up empty. It is suggested that you find a way to cut down certain parts of your project that are causing trouble.
- Typically speaking, the larger files will end up stored in your Assets folder. They may be things like videos, high poly models, images with large resolutions, etc. If need be, compress your videos, retopologize your models, and shrink your images. A good software for video compression is [Handbrake.](https://handbrake.fr/)

## On Unity
To start off, go to File > Build Settings.
### Build Settings
- Switch your platform to Android. If it's grayed out, Unity's documentation has a [setup guide.](https://docs.unity3d.com/Manual/android-sdksetup.html)
- Be sure to check the box next to "Build App Bundle (Google Play)". This is one of the two steps that will allow you to upload projects that are more than Google Play's APK size limit of only 150 megabytes.
- There will be a button in the bottom left corner called "Player Settings". Click it.

### Player Settings
There should be five dropdown options at the bottom of your new window. Open "Other Settings".
#### Other Settings
- Ignore most of what just showed up until you're able to find the section labeled "Identification".
- Check the box next to "Override Default Package Name" and insert your package name. In this case, our package name was "com.TheCube.AudiologyVR".
- Set your version to whatever you want.
- Set "Bundle Version Code" to 1. Every time you upload the project to the Google Play Store, this number will need to be different. So, if you make an update and need to publish a new release, change it to 2 or whichever number comes next. Otherwise, Google Play will tell you that you can't upload your build.
- Set your "Minimum API Level" to the highest level available. As I'm writing this, it's 34, and Google Play will not allow a project to be uploaded if it's using a version lower than 33. This will likely change in the future, so picking the highest API level is your safest bet.
- Set your "Target API Level" to Automatic.
- Leave this drop down and open up "Publishing Settings".
#### Publishing Settings
- Click  "Keystore Manager". It'll open up a new window.
- Inside, create a new keystore and save it wherever you like so long as you don't lose it. The file you make here will be important later.
- Now that you have a new keystore, give it a password. The only other options in this window that matter are "Alias" and the passwords below that.
- Alias will just be a name you need to remember. Call it whatever you like and give it a password, too. For simplicity's sake, I recommend making it the same password as your keystore.
- Click "Add key" and leave the window.
- Check the box next to "Custom Keystore".
- Click the "Select..." button and use the keystore you just made.
- Insert your password under Path.
- The "Alias" part should have been made available. Pick the Alias you made and insert the password for it as well.
- At the very bottom of Publishing Settings, there should be an option that says, "Split Application Binary". Check the box next to it. This is the second step for uploading large files to Google Play.

### Back to Build Settings
- With all that done, hit "Build" and save the file under a name you like. Unity will have you press "OK" a few times throughout the building process when it computes the size of your file.
- Once that's all finished up, you should have an AAB file ready.

## On the Google Play Console
- Create a new app if you don't have one already.
- There are a multitude of ways to upload your app to the Google Play Store. Pick whichever suits you best -- Production, Open Testing, Closed Testing, etc. -- anything works as long as you end up at a page labeled "Create (blank) release". You may have to create a track or hit a button labeled "Edit release" to make it to this page.
- When you've made it there, you may notice that this is the place where you'll be able to upload your project. Don't be rash, though. Make sure to click "Change signing key" first.

### Uploading your signing key
- First, you'll be prompted with a small pop-up. Just hit "Change app signing key" again.
- You should now be taken to a new popup window with four options. Select "Export and upload a key from Java keystore".
- You'll notice a list laid out before you now. Download the files Google is giving you (the encryption public key and PEPK tool.)
- Now it's time for you to find the .keystore file you created earlier. Put it, along with the other files you just got, into a new folder together.
- Inside the folder, create a .bat file and paste in the command that Google has provided back at the place you downloaded the files.
- Replace the sections that Google had in bold with the information you have regarding your key. So for me, I changed "foo.keystore" to "newaudiology.keystore" and the alias "foo" to "uopkey". Put the full path, starting from C (or whichever drive you're using), to the encryption_public_key.pm file in quotation marks. You can keep output.zip the same.
- For the sake of having an example, here's how my .bat file looked:
```
java -jar pepk.jar --keystore=newaudiology.keystore --alias=uopkey --output=output.zip --include-cert --rsa-aes-encryption --encryption-key-path="C:\Users\Cube_Admin\Documents\GitHub\Audiology-Version-2\Audiology Project Unity\encryption_public_key.pem"
pause
```
- When you run the program, it should ultimately result in your brand new output.zip file. Upload this back at Google's page where it says "Upload generated ZIP".
#### A quick note on Java troubleshooting
When I initially ran the program, it wouldn't work despite having the JDK version it was asking for. If this happens to you, what fixed it for me was installing OpenJDK 11 from [this website.](https://www.openlogic.com/openjdk-downloads?field_java_parent_version_target_id=406&field_operating_system_target_id=436&field_architecture_target_id=391&field_java_package_target_id=All)

### Uploading your AAB file
- With that finished, you should be able to simply drag your AAB file straight into the "App bundles" area.
- Give it a release name, wait for it to upload, and hit next.
- Google might throw you some errors that relate to not having assigned a country or any testers. This can be fixed pretty easily by going back and managing your current track. There, you should be able to find a couple tabs where you can fill out the necessary info.
- Once you've gotten rid of all your errors, feel free to go to the "Publishing overview" page and send in your changes for review!

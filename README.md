##Jenkins Daemon
*/Library/LaunchDaemons/org.jenkins-ci.plist*
~~~
sudo launchctl unload /Library/LaunchDaemons/org.jenkins-ci.plist
sudo launchctl load /Library/LaunchDaemons/org.jenkins-ci.plist
~~~
*edit like this:*
~~~
<dict>
	<key>JENKINS_HOME</key>
	<string>LOGIN_ACCOUNT_HOME_FOLDER/Home</string>
</dict>

<key>UserName</key>
	<string>LOGIN_ACCOUNT</string>
~~~

##Jenkins
* 젠킨스 설치
* GIT plugin, Testflight plugin 설치
* Configure System -> Git plugin: user.name, user.email 세팅
* Configure System -> Test Flight: Token Pair Name, API Token, Team Token
	* 참조: https://testflightapp.com/api/doc/
* New Job:
	* Job Name
	* Check Build a free-style software project
* Job configuration -> Source Code Management: Git
	* Repository URL: https://ID:PASSWORD@github.com/waltz4lucy/Jenkins.git
* Job configuration -> Build -> Invoke Ant:
	* Targets: main or ios or android
		* 참고: build.xml
* Job configuration -> Post-build Actions -> Upload to Testflight:
	* Token Pair: Select token pair
	* IPA/APK Files: builds/ios/*.ipa, builds/android/*.apk

##build.properties
*edit like this:*
~~~
keychain.password = LOGIN_ACCOUNT_PASSWORD
APP_NAME = APP_NAME (Match Unity BuildSettings)
~~~

##Shell Command
~~~
ant main
ant ios
ant android
~~~

##Unity3d Build Parameter
Unity3D Build: -quit -batchmode -executeMethod PerformBuild.CommandLineBuild
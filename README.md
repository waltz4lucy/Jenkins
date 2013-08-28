##Jenkins Daemon
*위치: /Library/LaunchDaemons/org.jenkins-ci.plist*
~~~
sudo launchctl unload /Library/LaunchDaemons/org.jenkins-ci.plist
sudo launchctl load /Library/LaunchDaemons/org.jenkins-ci.plist
~~~
*아래와 같이 수정:*
~~~
<dict>
	<key>JENKINS_HOME</key>
	<string>LOGIN_ACCOUNT_HOME_FOLDER/Home</string>
</dict>

<key>UserName</key>
	<string>LOGIN_ACCOUNT</string>
~~~
젠킨스 계정 권한 문제 해결은 이 방법이 가장 간단함.

##Jenkins Setting
### Configure System
* GIT plugin, Testflight plugin 설치
* Configure System -> Git plugin: 세팅 안 하면 빌드 할 때마다 젠킨스 이름으로 계정 생성됨
	* user.name
	* user.email
* Configure System -> Test Flight:
	* Token Pair Name
	* API Token
	* Team Token
	* 참조: https://testflightapp.com/api/doc/
	
### Job
* New Job:
	* Job Name
	* Check Build a free-style software project
* Job configuration -> Source Code Management -> Git:
	* Repository URL: https://ID:PASSWORD@github.com/waltz4lucy/Jenkins.git
* Job configuration -> Build -> Invoke Ant:
	* Targets: main or ios or android
		* 참고: build.xml
* Job configuration -> Post-build Actions -> Upload to Testflight:
	* Token Pair: 미리 세팅된 Token pair 선택
	* IPA/APK Files: builds/ios/*.ipa, builds/android/*.apk
	
* Job configuration -> Build Triggers
	* 커밋 마다 할건지 

##Unity Build Setting
* Assets/Editor/PerformBuild.cs
* 빌드 할 씬 추가
* PlayerSettings:
	* Company Name
	* Product Name
	* Bundle Identifier
	* Bundle Version

##build.properties
*아래와 같이 수정:*
~~~
keychain.password = LOGIN_ACCOUNT_PASSWORD
APP_NAME = APP_NAME (Match Unity BuildSettings)
~~~

##Ant Shell Command
~~~
ant main
ant ios
ant android
~~~

## Uninstall Jenkins
*위치: /Library/Application Support/Jenkins*
~~~
Uninstall.command
~~~
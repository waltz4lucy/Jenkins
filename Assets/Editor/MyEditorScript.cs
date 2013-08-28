using UnityEditor;

class MyEditorScript
{
     static void PerformBuild ()
     {
         string[] scenes = { "Assets/jenkins.unity" };
         BuildPipeline.BuildPlayer(scenes, ...);
     }
}
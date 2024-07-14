using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenüManager : MonoBehaviour
{
    public void ChangeScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit(); // Quit the application in a built game
        #endif
    }
}

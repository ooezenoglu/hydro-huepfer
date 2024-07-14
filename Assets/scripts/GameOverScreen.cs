using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// unwichtig
public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;


    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f; // restart the game
    }

    public void ExitButton()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // for editor
        #else
                Application.Quit(); // for build-versions outside the editor
        #endif
    }
}

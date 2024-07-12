using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public GameOverScreen gameOverScreen;
    public LogicScript levels;

    public AudioClip audioClipBackground;

    public void GameOver()
    {
        Time.timeScale = 0f; // stop the game
        
        if (backgroundMusic.clip == audioClipBackground)
        {
            backgroundMusic.Stop();
            BackgroundMusic2.Instance.StopGrowling();
        }
       
        // display game over screen
        gameOverScreen.Setup(levels.score);
    }
}

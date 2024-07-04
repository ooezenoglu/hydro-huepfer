using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public GameOverScreen gameOverScreen;
    int nLevels = 0;

    public AudioClip audioClipBackground;

    public void GameOver()
    {
        Time.timeScale = 0f; // stop the game
        
        if (backgroundMusic.clip == audioClipBackground)
        {
            backgroundMusic.Stop(); // stop the background music
        }

        // display game over screen
        gameOverScreen.Setup(nLevels);
    }
}

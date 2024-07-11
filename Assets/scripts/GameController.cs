using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public GameOverScreen gameOverScreen;
    public LogicScript levels;

    public AudioClip audioClipBackground;

    public PlayableDirector deathClip;


    public void GameOver()
    {
        Time.timeScale = 0f; // stop the game
        
        if (backgroundMusic.clip == audioClipBackground)
        {
            backgroundMusic.Stop(); // stop the background music
        }

        StartCoroutine(DeathSequence());
    }

    public IEnumerator DeathSequence()
    {
        deathClip.Play();
        yield return new WaitForSecondsRealtime(3);

        // display game over screen
        gameOverScreen.Setup(levels.score);
    }
}

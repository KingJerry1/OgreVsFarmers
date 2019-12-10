using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool isMuted = false;

    public GameObject PauseMenuUI;
    public GameObject OptionsMenu;
    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Options() {
        PauseMenuUI.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void MuteMusic() {
        isMuted = ! isMuted;
        audioSource.volume =  isMuted ? 0 : 1;
    }

    public void BackToMenu() {
        PauseMenuUI.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame() {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public Slider SFXSlider;
    public Slider SoundtrackSlider;
    // public AudioSource pauseSound, resumeSound;

    void CheckVolumeLevels()
    {
        if (PlayerPrefs.GetInt("soundtrack_volume_set") == 1)
        {
            SoundtrackSlider.value = PlayerPrefs.GetFloat("soundtrack_volume");
        }
        if (PlayerPrefs.GetInt("sfx_volume_set") == 1)
        {
            SFXSlider.value = PlayerPrefs.GetFloat("sfx_volume");
        }
    }

    void Start()
    {
        CheckVolumeLevels();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused) Pause();
            
            else if (gameIsPaused) Unpause();
        }
    }

    public void SetSFXVolume()
    {
        PlayerPrefs.SetFloat("sfx_volume", SFXSlider.value);
        PlayerPrefs.SetInt("sfx_volume_set", 1);
        PlayerPrefs.Save();
        print("set sfx volume: " + PlayerPrefs.GetFloat("sfx_volume"));
    }

    public void SetSoundtrackVolume()
    {
        PlayerPrefs.SetFloat("soundtrack_volume", SoundtrackSlider.value);
        PlayerPrefs.SetInt("soundtrack_volume_set", 1);
        PlayerPrefs.Save();
        print("set soundtrack volume: " + PlayerPrefs.GetFloat("soundtrack_volume"));
    }

    public void Pause() 
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        pauseMenu.SetActive(true);
        CheckVolumeLevels();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Unpause()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        pauseMenu.SetActive(false);
    }

}

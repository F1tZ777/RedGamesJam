using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    [SerializeField] private GameObject Pause, _GameOver;

    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public enum Scene
    {
        MainMenu,
        UpgradesStore,
        Drilling
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.MainMenu.ToString());
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic("MainMenuBGM");
    }

    public void LoadUpgradesStore()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.UpgradesStore.ToString());
    }

    public void LoadDrilling()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.Drilling.ToString());
    }

    public void pause()
    {
        Time.timeScale = 0f;
        Pause.SetActive(true);
    }

    public void resume()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);

    }

    public void gameOver()
    {
        SoundManager.Instance.PlaySound("DrillBreak");
        Time.timeScale = 0f;
        _GameOver.SetActive(true);
    }
}

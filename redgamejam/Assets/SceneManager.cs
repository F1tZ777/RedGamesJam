using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    public void Awake()
    {
        Instance = this;
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

    public void LoadUpgradesStore()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.UpgradesStore.ToString());
    }

    public void LoadDrilling()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.Drilling.ToString());
    }
}

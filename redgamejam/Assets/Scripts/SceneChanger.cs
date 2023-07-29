using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{

    public void play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("UpgradesStore");
        SoundManager.Instance.PlaySound("UIButtonSFX");
    }

    public void back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        SoundManager.Instance.PlaySound("UIButtonSFX");
    }

    public void resume()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cave");
        SoundManager.Instance.PlaySound("UIButtonSFX");
    }

    public void audioButton()
    {
        SoundManager.Instance.PlaySound("UIButtonSFX");
    }
}

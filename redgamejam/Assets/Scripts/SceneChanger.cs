using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{

    public void play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("UpgradesStore");
    }

    public void back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void resume()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Drilling");
    }
}

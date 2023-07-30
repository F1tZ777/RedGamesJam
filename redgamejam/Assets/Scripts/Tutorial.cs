using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Page1, Page2, Page3;

    public void Open()
    {
        SoundManager.Instance.PlaySound("UIButtonSFX");
    }

    public void Next()
    {
        SoundManager.Instance.PlaySound("FlipPage");
        if (Page1.activeSelf == true)
        {
            Page1.SetActive(false);
            Page2.SetActive(true);
        }
        else if (Page2.activeSelf == true)
        {
            Page2.SetActive(false);
            Page3.SetActive(true);
        }
    }

    public void Prev()
    {
        SoundManager.Instance.PlaySound("FlipPage");
        if (Page2.activeSelf == true)
        {
            Page2.SetActive(false);
            Page1.SetActive(true);
        }

        else if(Page3.activeSelf == true)
        {
            Page3.SetActive(false);
            Page2.SetActive(true);
        }
    }

    public void Exit()
    {
        Page1.SetActive(true);
        Page2.SetActive(false);
        Page3.SetActive(false);
    }
}

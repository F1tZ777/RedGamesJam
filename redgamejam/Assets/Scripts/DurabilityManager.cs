using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DurabilityManager : MonoBehaviour
{
    public Slider slider;
    void Start()
    {

    }
    void Update()
    {
        slider.maxValue = PlayerData.instance.maxDurability;
        slider.value = PlayerData.instance.currentDurability;
    }
}

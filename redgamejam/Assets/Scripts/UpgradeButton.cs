using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] GameObject _super, _ultra;
    [SerializeField] Button _upgradebar;

    public void Upgrade()
    {
        if (_super.activeSelf == false && PlayerData.instance.money >= 200)
        {
            _super.SetActive(true);
            PlayerData.instance.drillPow = 2;
            PlayerData.instance.maxDurability = 200;
            PlayerData.instance.money -= 200;
        }
        else if (_ultra.activeSelf == false && PlayerData.instance.money >= 400)
        {
            _ultra.SetActive(true);
            _upgradebar.interactable = false;
            PlayerData.instance.drillPow = 3;
            PlayerData.instance.maxDurability = 300;
            PlayerData.instance.money -= 400;
        }
    }
}

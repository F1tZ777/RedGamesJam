using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] GameObject _super, _ultra;
    [SerializeField] Button _upgradebar;
    public TMP_Text kitamounttext;

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

    public void RepairKitInventory()
    {
        /*if (PlayerData.instance.money >= 50)
        {*/
            PlayerData.instance.repairkit += 1;
        //}
    }

    private void Update()
    {
        kitamounttext.text = PlayerData.instance.repairkit.ToString();
    }
}

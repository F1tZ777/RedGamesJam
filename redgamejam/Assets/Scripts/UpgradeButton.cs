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
        if (_super.activeSelf == false)
        {
            _super.SetActive(true);
        }
        else if (_ultra.activeSelf == false)
        {
            _ultra.SetActive(true);
            _upgradebar.interactable = false;
        }
    }
}

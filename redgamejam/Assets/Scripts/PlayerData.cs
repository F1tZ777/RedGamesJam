using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public int drillPow = 1;
    public int maxDurability = 100;
    public int currentDurability;
    public int money;
    public int repairkit = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        currentDurability = maxDurability;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

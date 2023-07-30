using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshPro scoreText;
    [SerializeField] private TMPro.TextMeshPro resource1Text;
    [SerializeField] private TMPro.TextMeshPro resource2Text;

    public float resource1;
    public float resource2;
    public float durability;

    public bool powerDrill = false;
    public bool highBeam = false;
    public int repairKit = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public static Tile instance;
    public int moveTimer;
    public int maxHP = 1;
    public int currentHP;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        currentHP = maxHP;
        mainCamera = Camera.main;
        StartCoroutine("moveUp");
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsObjectWithinCameraYBounds(transform.position))
        {
            Destroy(this.gameObject, 1f);
        }
    }

    private IEnumerator moveUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveTimer);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
        }
    }

    bool IsObjectWithinCameraYBounds(Vector3 worldPosition)
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(worldPosition);
        return viewportPoint.y <= 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        PlayerData.instance.money += 1;
    }
}

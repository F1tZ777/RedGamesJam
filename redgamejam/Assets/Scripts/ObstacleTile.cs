using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTile : MonoBehaviour
{
    public int moveTimer;
    private Camera mainCamera;

    void Start()
    {
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private float moveTimer = 1f;

    void Start()
    {
        StartCoroutine("moveUp");
    }
    private IEnumerator moveUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveTimer);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
        }
    }
}

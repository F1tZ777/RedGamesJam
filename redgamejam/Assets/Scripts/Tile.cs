using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int moveTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("moveUp");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + 1f, transform.position.y + 1f);
    }

    private IEnumerator moveUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveTimer);
            transform.position = new Vector2(transform.position.x + 1f, transform.position.y + 1f);
        }
    }
}

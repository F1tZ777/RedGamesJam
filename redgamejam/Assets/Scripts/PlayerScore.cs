using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private float score;
    void Awake()
    {
        score = 0;
        StartCoroutine(UpdateScore());
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            score += 1;
            yield return new WaitForSeconds(1);
        }
    }
}

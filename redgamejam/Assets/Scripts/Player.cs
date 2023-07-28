using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int moveTimer;
    private Vector2 startPos;
    [SerializeField] private int swipeDistance = 50;
    private bool isFingerDown;
    public LayerMask obstacle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("moveUp");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D downCheck = Physics2D.Raycast(transform.position, Vector2.down, 1f, obstacle);
        RaycastHit2D upCheck = Physics2D.Raycast(transform.position, Vector2.up, 1f, obstacle);
        RaycastHit2D leftCheck = Physics2D.Raycast(transform.position, Vector2.left, 1f, obstacle);
        RaycastHit2D rightCheck = Physics2D.Raycast(transform.position, Vector2.right, 1f, obstacle);

        // Controls For mobile
        if (isFingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            isFingerDown = true;
        }
        if (isFingerDown == true && Input.touchCount > 0)
        {
            if (Input.touches[0].position.y >= startPos.y + swipeDistance && upCheck.collider == null)
            {
                isFingerDown = false;
                transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
                Debug.Log("Up");
            }
            else if (Input.touches[0].position.y <= startPos.y - swipeDistance && downCheck.collider == null)
            {
                isFingerDown = false;
                transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
                Debug.Log("Down");
            }
            else if (Input.touches[0].position.x <= startPos.x + swipeDistance && rightCheck.collider == null)
            {
                isFingerDown = false;
                transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                Debug.Log("Right");
            }
            else if (Input.touches[0].position.x <= startPos.x - swipeDistance && leftCheck.collider == null)
            {
                isFingerDown = false;
                transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                Debug.Log("Left");
            }
        }

        if (isFingerDown == true && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            isFingerDown = false;
        }


        // Controls For PC Testing
        if (isFingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isFingerDown = true;
        }
        if (isFingerDown == true)
        {
            if (Input.mousePosition.y >= startPos.y + swipeDistance && upCheck.collider == null)
            {
                isFingerDown = false;
                transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
                Debug.Log("Up");
            }
            else if (Input.mousePosition.y <= startPos.y - swipeDistance && downCheck.collider == null)
            {
                isFingerDown = false;
                transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
                Debug.Log("Down");
            }
            else if (Input.mousePosition.x >= startPos.x + swipeDistance && rightCheck.collider == null)
            {
                isFingerDown = false;
                transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                Debug.Log("Right");
            }
            else if (Input.mousePosition.x <= startPos.x - swipeDistance && leftCheck.collider == null)
            {
                isFingerDown = false;
                transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                Debug.Log("Left");
            }
        }

        if (isFingerDown == true && Input.GetMouseButtonUp(0))
        {
            isFingerDown = false;
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
}

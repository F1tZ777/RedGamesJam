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
    public LayerMask tile;
    private float lowestPos;

    // Start is called before the first frame update
    void Start()
    {
        lowestPos = transform.position.y;
        StartCoroutine("moveUp");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D downObsCheck = Physics2D.Raycast(transform.position, Vector2.down, 1f, obstacle);
        RaycastHit2D upObsCheck = Physics2D.Raycast(transform.position, Vector2.up, 1f, obstacle);
        RaycastHit2D leftObsCheck = Physics2D.Raycast(transform.position, Vector2.left, 1f, obstacle);
        RaycastHit2D rightObsCheck = Physics2D.Raycast(transform.position, Vector2.right, 1f, obstacle);

        RaycastHit2D downTileCheck = Physics2D.Raycast(transform.position, Vector2.down, 1f, tile);
        RaycastHit2D upTileCheck = Physics2D.Raycast(transform.position, Vector2.up, 1f, tile);
        RaycastHit2D leftTileCheck = Physics2D.Raycast(transform.position, Vector2.left, 1f, tile);
        RaycastHit2D rightTileCheck = Physics2D.Raycast(transform.position, Vector2.right, 1f, tile);

        // Controls For mobile
        if (isFingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            isFingerDown = true;
        }
        if (isFingerDown == true && Input.touchCount > 0)
        {
            if (Input.touches[0].position.y >= startPos.y + swipeDistance)
            {
                isFingerDown = false;
                if (upTileCheck.collider != null)
                {
                    Tile tile = upTileCheck.collider.GetComponent<Tile>();
                    if (PlayerData.instance.drillPow >= tile.currentHP)
                        transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
                    else
                        tile.currentHP = tile.currentHP - PlayerData.instance.drillPow;
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                }
                else if (upObsCheck.collider != null)
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                else
                    transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
                Debug.Log("Up");
            }
            else if (Input.touches[0].position.y <= startPos.y - swipeDistance)
            {
                isFingerDown = false;
                if (downTileCheck.collider != null)
                {
                    Tile tile = downTileCheck.collider.GetComponent<Tile>();
                    if (PlayerData.instance.drillPow >= tile.currentHP)
                        transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
                    else
                        tile.currentHP = tile.currentHP - PlayerData.instance.drillPow;
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                }
                else if (downObsCheck.collider != null)
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                else
                    transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
                Debug.Log("Down");
            }
            else if (Input.touches[0].position.x <= startPos.x + swipeDistance)
            {
                isFingerDown = false;
                if (rightTileCheck.collider != null)
                {
                    Tile tile = rightTileCheck.collider.GetComponent<Tile>();
                    if (PlayerData.instance.drillPow >= tile.currentHP)
                        transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                    else
                        tile.currentHP = tile.currentHP - PlayerData.instance.drillPow;
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                }
                else if (rightObsCheck.collider != null)
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                else
                    transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                Debug.Log("Right");
            }
            else if (Input.touches[0].position.x <= startPos.x - swipeDistance)
            {
                isFingerDown = false;
                if (leftTileCheck.collider != null)
                {
                    Tile tile = leftTileCheck.collider.GetComponent<Tile>();
                    if (PlayerData.instance.drillPow >= tile.currentHP)
                        transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                    else
                        tile.currentHP = tile.currentHP - PlayerData.instance.drillPow;
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                }
                else if (leftObsCheck.collider != null)
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                else
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
            if (Input.mousePosition.y >= startPos.y + swipeDistance)
            {
                isFingerDown = false;
                if (upTileCheck.collider != null)
                {
                    Tile tile = upTileCheck.collider.GetComponent<Tile>();
                    if (PlayerData.instance.drillPow >= tile.currentHP)
                        transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
                    else
                        tile.currentHP = tile.currentHP - PlayerData.instance.drillPow;
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                }
                else if (upObsCheck.collider != null)
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                else
                    transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
                Debug.Log("Up");
            }
            else if (Input.mousePosition.y <= startPos.y - swipeDistance)
            {
                isFingerDown = false;
                if (downTileCheck.collider != null)
                {
                    Tile tile = downTileCheck.collider.GetComponent<Tile>();
                    if (PlayerData.instance.drillPow >= tile.currentHP)
                        transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
                    else
                        tile.currentHP = tile.currentHP - PlayerData.instance.drillPow;
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                }
                else if (downObsCheck.collider != null)
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                else
                    transform.position = new Vector2(transform.position.x, transform.position.y - 1f);

                Debug.Log("Down");
            }
            else if (Input.mousePosition.x >= startPos.x + swipeDistance)
            {
                isFingerDown = false;
                if (rightTileCheck.collider != null)
                {
                    Tile tile = rightTileCheck.collider.GetComponent<Tile>();
                    if (PlayerData.instance.drillPow >= tile.currentHP)
                        transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                    else
                        tile.currentHP = tile.currentHP - PlayerData.instance.drillPow;
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                }
                else if (rightObsCheck.collider != null)
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                else
                    transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
                Debug.Log("Right");
            }
            else if (Input.mousePosition.x <= startPos.x - swipeDistance)
            {
                isFingerDown = false;
                if (leftTileCheck.collider != null)
                {
                    Tile tile = leftTileCheck.collider.GetComponent<Tile>();
                    if (PlayerData.instance.drillPow >= tile.currentHP)
                        transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                    else
                        tile.currentHP = tile.currentHP - PlayerData.instance.drillPow;
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                }
                else if (leftObsCheck.collider != null)
                    PlayerData.instance.currentDurability = PlayerData.instance.currentDurability - 1;
                else
                    transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
                Debug.Log("Left");
            }
        }

        if (isFingerDown == true && Input.GetMouseButtonUp(0))
        {
            isFingerDown = false;
        }

        if (transform.position.y < lowestPos)
        {
            ScoreManager.instance.AddScore(10);
            lowestPos = transform.position.y;
        }
    }

    private IEnumerator moveUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveTimer);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
            lowestPos = lowestPos + 1f;
        }
    }
}

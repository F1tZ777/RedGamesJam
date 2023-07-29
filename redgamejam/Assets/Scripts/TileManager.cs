using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public int _width, _height;
    private int randomNumber;
    [SerializeField] private Transform _cam;
    [SerializeField] GameObject _tile;
    [SerializeField] GameObject _obstacleTile;
    [SerializeField] GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayMusic("CaveBGM");
        GenerateGrid();
        StartCoroutine("spawnTile");
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                if (y<7)
                    Instantiate(_tile, new Vector3(x, y), Quaternion.identity);
                else if (x == 2 && y ==7)
                    Instantiate(_player, new Vector3(x, y), Quaternion.identity);
            }
        }
        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10f);
    }

    private IEnumerator spawnTile()
    {
        while (true)
        {
            yield return new WaitForSeconds(Tile.instance.moveTimer);
            for (int x = 0; x < _width; x++)
            {
                if (Random.Range(0, 100) >= 90)
                    Instantiate(_obstacleTile, new Vector3(x, 0), Quaternion.identity);
                else
                    Instantiate(_tile, new Vector3(x, 0), Quaternion.identity);

            }
        }
    }
}

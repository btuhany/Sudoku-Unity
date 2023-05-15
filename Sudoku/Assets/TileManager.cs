using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    [SerializeField] Tile _tilePrefab;
    [SerializeField] GameObject _borderPrefab;
    Tile[,] _tiles = new Tile[9,9];
    [SerializeField] Transform _bordersParentTransform;


    [SerializeField] float _borderWidth= 0.1f;
    GridLayoutGroup _gridGroup;
    private void Awake()
    {
        _gridGroup = GetComponent<GridLayoutGroup>();
    }
    private void Start()
    {
        InstantiateTiles();
        InstantiateBorders();
    }
    void InstantiateTiles()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Tile newTile = Instantiate(_tilePrefab, this.transform);
                newTile.Row = i + 1;
                newTile.Column = j + 1;
                newTile.SetNumber(-1);
                _tiles[i, j] = newTile;
            }
        }
    }
    void InstantiateBorders()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject border =  Instantiate(_borderPrefab, _bordersParentTransform);
            border.transform.localScale = new Vector3(_borderWidth, 9 * _gridGroup.cellSize.y / 100, 1);
            if (i == 0)
                border.transform.position = new Vector3(this.transform.position.x - _gridGroup.cellSize.x * 1.5f, this.transform.position.y, 0);
            else
                border.transform.position = new Vector3(this.transform.position.x + _gridGroup.cellSize.x * 1.5f, this.transform.position.y, 0);
        }
        for (int i = 0; i < 2; i++)
        {
            GameObject border = Instantiate(_borderPrefab, _bordersParentTransform);
            border.transform.localScale = new Vector3(9*_gridGroup.cellSize.x/100, _borderWidth, 1);
            if (i == 0)
                border.transform.position = new Vector3(this.transform.position.x , this.transform.position.y - _gridGroup.cellSize.y * 1.5f, 0);
            else
                border.transform.position = new Vector3(this.transform.position.x , this.transform.position.y + _gridGroup.cellSize.y * 1.5f, 0);
        }

    }
}

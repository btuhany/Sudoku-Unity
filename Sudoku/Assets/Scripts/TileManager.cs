using System.Collections;
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

    public static TileManager Instance;
    public event System.Action OnTileHighlighted;
    private void Awake()
    {
        _gridGroup = GetComponent<GridLayoutGroup>();
        Instance = this;
    }
    private void OnEnable()
    {
        GameManager.Instance.OnGameStart += HandleOnGameStart;
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
                newTile.Row = i+1;
                newTile.Column = j+1;
                newTile.SetNumber(-1);
                _tiles[j, i] = newTile;
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
    void HandleOnGameStart()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j <9; j++)
            {
                if (_tiles[i, j].Number > 0)
                {
                    _tiles[i, j].DeactivateButton();
                    
                }
            }
        }
    }
    bool IsThereSameColumnNumber(int row, int number)
    {
        for (int i = 0; i < 9; i++)
        {
            if (_tiles[i, row].Number == number)
            {
                HighlightTile(_tiles[i, row]);
                return true;
            }
        }
        return false;
    }
    bool IsThereSameRowNumber(int column, int number)
    {
        for (int i = 0; i < 9; i++)
        {
            if (_tiles[column, i].Number == number)
            {
                HighlightTile(_tiles[column,i]);
                return true;
            }
        }
        return false;
    }
    bool IsThereSameBoxNumber(int row, int column, int number)
    {
        int leftUpTileRow;
        int leftUpColumn;

        if (row < 3)
        {
            leftUpTileRow = 0;
        }
        else if(row <6)
        {
            leftUpTileRow = 3;
        }
        else
        {
            leftUpTileRow = 6;
        }

        if (column < 3)
        {
            leftUpColumn = 0;
        }
        else if (column < 6)
        {
            leftUpColumn = 3;
        }
        else
        {
            leftUpColumn = 6;
        }

 
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_tiles[leftUpColumn + i, leftUpTileRow + j].Number == number)
                {
                    HighlightTile(_tiles[leftUpColumn + i, leftUpTileRow + j]);
                    return true;
                }
            }
        }
        return false;
    }
    public bool IsThereSameNumberRowColumnBox(int row,int column,int number)
    {
        if(IsThereSameBoxNumber(row,column,number))
        { return true; }
        if (IsThereSameColumnNumber(row, number))
        { return true; }
        if (IsThereSameRowNumber(column, number))
        { return true; }
        return false;
    }
    public bool IsGameFinished()
    {
        foreach (Tile tile in _tiles)
        {
            if (tile.Number > 0)
                return false;
        }
        return true;
    }
    void HighlightTile(Tile tile)
    {
        OnTileHighlighted?.Invoke();
        StartCoroutine(HighlightTileFadeInOut(tile));
    }
    IEnumerator HighlightTileFadeInOut(Tile tile)
    {
        float elapsed = 0f;
        float duration = 1f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);

            tile.Image.color = Color.Lerp(Color.white, Color.red, t);
            
            elapsed += Time.deltaTime;
            yield return null;
        }
        elapsed = 0f;
        duration = 1f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            for (int i = 0; i < 9; i++)
            {
                tile.Image.color = Color.Lerp(Color.red, Color.white, t);
            }
            
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}

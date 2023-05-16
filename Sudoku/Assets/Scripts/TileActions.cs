using System;
using UnityEngine;

public class TileActions : MonoBehaviour
{

    Tile SelectedTile;
    
   
    public static TileActions Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void OnEnable()
    {
        GameManager.Instance.OnGameStart += HandleOnGameStart;
        TileManager.Instance.OnTileHighlighted += ClearSelectedTile;
    }

    private void HandleOnGameStart()
    {
        if(SelectedTile)
        {
            ClearSelectedTile();
        }
    }

    public void SelectTile(Tile selectedTile)
    {
        if (SelectedTile == selectedTile)
        {
            ClearSelectedTile();
        }
        else if(SelectedTile)
        {
            SelectedTile.GetUnselected();
            SelectedTile = selectedTile;
        }
        else
        {
            SelectedTile = selectedTile;
        }
      
    }
    public bool IsAnyTileSelected(int number)
    {
        if (SelectedTile == null) return false;
        if (SelectedTile.Number == number) return false;
        return true;
    }
    public bool TryAssignNumberToTile(int number)
    {
        if (TileManager.Instance.IsThereSameNumberRowColumnBox(SelectedTile.Row - 1, SelectedTile.Column - 1, number))
            return false;
        SelectedTile.SetNumber(number);
        if (TileManager.Instance.IsGameFinished())
            GameManager.Instance.GameFinished();
        return true;
    }
    void ClearSelectedTile()
    {
        SelectedTile.GetUnselected();
        SelectedTile = null;
    }
}

using UnityEngine;

public class TileActions : MonoBehaviour
{

    Tile SelectedTile;
    
   
    public static TileActions Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void SelectTile(Tile selectedTile)
    {
        SelectedTile = selectedTile;
    }
    public void UnselectTile()
    {
        SelectedTile = null;
    }
    public void AssignNumberToTile(int number)
    {
        if (SelectedTile == null) return;
        SelectedTile.SetNumber(number); 
    }

}

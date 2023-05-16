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
        if (SelectedTile == selectedTile)
        {
            selectedTile.GetUnselected();
            SelectedTile= null;
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
    public void AssignNumberToTile(int number)
    {
        if (SelectedTile == null) return;
        SelectedTile.SetNumber(number); 
    }

}

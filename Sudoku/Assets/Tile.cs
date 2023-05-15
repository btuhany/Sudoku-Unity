using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [HideInInspector] public int Row;
    [HideInInspector] public int Column;
    [HideInInspector] public int Number;

    Button _button;
    TextMeshProUGUI _text;
    bool _isSelected;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        _button.onClick.AddListener(() => HandleTileButton());
    }
    public void SetNumber(int number)
    {
        Number = number;
        if (number < 0)
            _text.SetText(" ");
        else
            _text.SetText(Number.ToString());
    }
    void HandleTileButton()
    {
        if(_isSelected)
        {
            _isSelected = false;
            SelectedStateProcess();
        }
        else
        {
            _isSelected = true;
            UnselectedStateProcess();
        }
    }
    void UnselectedStateProcess()
    {
        //change colour
        TileActions.Instance.SelectTile(this);

    }
    void SelectedStateProcess()
    {
        //change colour
        TileActions.Instance.UnselectTile();

    }
    void DebugTile()
    {
        Debug.Log("Row: " + Row.ToString());
        Debug.Log("Column: " + Column.ToString());
    }
}

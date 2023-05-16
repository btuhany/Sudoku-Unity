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
    Image _image;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _image = GetComponent<Image>();
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
    public void DeactivateButton()
    {
        _button.interactable= false;
    }
    void HandleTileButton()
    {
        GetSelected();
    }
    void GetSelected()
    {
        //change colour
        _image.color = new Color(1f,0.8f,0.77f);
        TileActions.Instance.SelectTile(this);

    }
    public void GetUnselected()
    {
        _image.color = Color.white;
    }

    void DebugTile()
    {
        Debug.Log("Row: " + Row.ToString());
        Debug.Log("Column: " + Column.ToString());
    }
}

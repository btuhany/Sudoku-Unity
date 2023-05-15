using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InputButton : MonoBehaviour
{
    private int _number;

    Button _button;
    TextMeshProUGUI _text;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        _button.onClick.AddListener(() => TryAssignNumber());
    }
    void TryAssignNumber()
    {
        TileActions.Instance.AssignNumberToTile(_number);
    }
    public void SetNumber(int newNumber)
    {
        _number = newNumber;
        _text.SetText(_number.ToString());

    }
    void DebugNumber()
    {
        Debug.Log(_number);
    }
}

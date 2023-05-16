using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InputButton : MonoBehaviour
{
    private int _number;


    Button _button;
    TextMeshProUGUI _text;
    Image _image;
    Color _initialImageColor;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _image= GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        _initialImageColor = _image.color;
        _button.onClick.AddListener(() => TryAssignNumber());
    }
    void TryAssignNumber()
    {
        if (!TileActions.Instance.IsAnyTileSelected(_number)) return;

        if(!TileActions.Instance.TryAssignNumberToTile(_number))
        {
            StopAllCoroutines();
            _image.color = _initialImageColor;
            StartCoroutine(ColorFadeInOut());
        }
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
    IEnumerator ColorFadeInOut()
    {
        float elapsed = 0f;
        float duration = 1f;
        
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed/ duration);
            _image.color = Color.Lerp(_initialImageColor, Color.red, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        elapsed = 0f;
        duration = 1f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            _image.color = Color.Lerp(Color.red, _initialImageColor, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}

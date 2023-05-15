using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButtonsManager : MonoBehaviour
{
    [SerializeField] InputButton _inputPrefab;

   
    private void Awake()
    {
        for (int i = 1; i <= 9; i++)
        {
            InputButton inputButton = Instantiate(_inputPrefab, this.transform);
            inputButton.SetNumber(i);
        }
    }
}

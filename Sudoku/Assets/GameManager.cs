using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event System.Action OnGameStart;
    public static GameManager Instance;
    private void Awake()
    {
        Instance= this;
    }
    public void StartGame()
    {
        OnGameStart?.Invoke();
    }
}

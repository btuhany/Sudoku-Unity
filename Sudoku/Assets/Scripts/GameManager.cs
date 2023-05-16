using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event System.Action OnGameStart;
    public static GameManager Instance;
    bool _isGameStarted;
    private void Awake()
    {
        Instance= this;
    }
    public void StartGame()
    {
        _isGameStarted=true;
        OnGameStart?.Invoke();
    }
    public void GameFinished()
    {
        if (!_isGameStarted) return;
        Debug.Log("Finished");
    }
}

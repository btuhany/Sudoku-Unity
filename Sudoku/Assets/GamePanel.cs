using UnityEngine;

public class GamePanel : MonoBehaviour
{
    public void StartButton()
    {
        GameManager.Instance.StartGame();
    }
}

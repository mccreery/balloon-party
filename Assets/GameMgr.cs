using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public GameObject menu;
    public GameObject gamePrefab;

    private GameObject currentGame;

    public void StartGame()
    {
        currentGame = Instantiate(gamePrefab);
        menu.SetActive(false);
    }

    public void QuitToMenu()
    {
        Destroy(currentGame);
        menu.SetActive(true);
    }
}

using UnityEngine;

public class Pause : MonoBehaviour
{
    public string pauseButton = "Pause";
    public GameObject pauseMenu;

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown(pauseButton))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Time.timeScale = pauseMenu.activeSelf ? 1 : 0;
        }
    }

    public void QuitToMenu()
    {
        FindObjectOfType<GameMgr>().QuitToMenu();
    }
}

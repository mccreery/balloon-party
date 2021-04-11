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
            Time.timeScale = pauseMenu.activeSelf ? 0.0f : 1.0f;
        }
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1.0f;
        FindObjectOfType<GameMgr>().QuitToMenu();
    }
}

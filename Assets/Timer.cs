using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour
{
    public float maxTime;

    private float startTime;
    private Text text;

    private void Start()
    {
        startTime = Time.time;
        text = GetComponent<Text>();
        timesUp.SetActive(false);
    }

    public Pause pause;

    private void Update()
    {
        float timeLeft = maxTime - (Time.time - startTime);

        if (timeLeft < 0)
        {
            StartCoroutine(WaitAndQuit());
        }
        else
        {
            int seconds = Mathf.CeilToInt(timeLeft);
            text.text = "Time: " + (seconds / 60) + ":" + (seconds % 60).ToString("D2");
        }
    }

    public GameObject timesUp;

    private IEnumerator WaitAndQuit()
    {
        Time.timeScale = 0;

        timesUp.SetActive(true);
        timesUp.GetComponentInChildren<Text>().text = "<b>Time's Up!</b>\nScore: " + FindObjectOfType<Score>().score;
        yield return new WaitForSeconds(5);
        pause.QuitToMenu();
    }
}

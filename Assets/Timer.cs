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
    }

    public Pause pause;

    private void Update()
    {
        float timeLeft = maxTime - (Time.time - startTime);

        if (timeLeft < 0)
        {
            pause.QuitToMenu();
        }
        else
        {
            int seconds = Mathf.CeilToInt(timeLeft);
            text.text = "Time: " + (seconds / 60) + ":" + (seconds % 60).ToString("D2");
        }
    }
}

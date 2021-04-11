using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    public int score;
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public Pause pause;

    private void Update()
    {
        text.text = "Score: " + score;
    }
}

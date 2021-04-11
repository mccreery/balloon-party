using UnityEngine;

public class KidSpawner : MonoBehaviour
{
    public GameObject kidPrefab;
    public int count;

    public Rect spawnArea;

    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject kid = Instantiate(kidPrefab, transform);
            kid.transform.position = spawnArea.GetRandomPoint();
            kid.GetComponent<Kid>().CorrectZ();
        }
    }
}

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
            Instantiate(kidPrefab, transform);
            kidPrefab.transform.position = spawnArea.GetRandomPoint();
        }
    }
}

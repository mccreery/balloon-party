using UnityEngine;

public class Kid : MonoBehaviour
{
    public Sprite[] heads;
    public Sprite[] bodies;

    public SpriteRenderer head;
    public SpriteRenderer body;

    public float standStillMean;
    public float standStillVariance;

    public Rect walkableArea;
    public float walkSpeed;

    private float nextMoveTime;

    private void Start()
    {
        Sprite headSprite = heads[Random.Range(0, heads.Length)];
        Sprite bodySprite = bodies[Random.Range(0, bodies.Length)];

        head.sprite = headSprite;
        body.sprite = bodySprite;

        PlanNextMove();
    }

    private Vector2? target;

    private void Update()
    {
        if (target.HasValue)
        {
            Vector3 position = Vector2.MoveTowards(transform.position, target.Value, walkSpeed * Time.deltaTime);
            // Draw closer to bottom kids in front
            position.z = position.y;

            transform.position = position;

            if ((target.Value - (Vector2)position).sqrMagnitude < 0.1f)
            {
                target = null;
                PlanNextMove();
            }
        }
        else if (Time.time >= nextMoveTime)
        {
            target = walkableArea.GetRandomPoint();
        }
    }

    private void PlanNextMove()
    {
        nextMoveTime = Time.time + standStillMean + Random.Range(-standStillVariance, standStillVariance);
    }
}

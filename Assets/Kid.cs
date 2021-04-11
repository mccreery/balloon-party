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

    public Sprite[] requests;

    public GameObject requestBubble;
    public SpriteRenderer requestSprite;

    public float requestMean;
    public float requestVariance;

    private float nextRequestTime;

    private void Start()
    {
        Sprite headSprite = heads[Random.Range(0, heads.Length)];
        Sprite bodySprite = bodies[Random.Range(0, bodies.Length)];

        head.sprite = headSprite;
        body.sprite = bodySprite;

        PlanNextMove();
        PlanNextRequest();

        requestBubble.SetActive(false);
    }

    private Vector2? target;

    public bool Requested { get; private set; }

    public void CompleteRequest()
    {
        Requested = false;
        requestBubble.SetActive(false);
        PlanNextRequest();
    }

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

        if (!Requested && Time.time > nextRequestTime)
        {
            Requested = true;
            requestBubble.SetActive(true);
            requestSprite.sprite = requests[Random.Range(0, requests.Length)];
        }
    }

    private void PlanNextMove()
    {
        nextMoveTime = Time.time + standStillMean + Random.Range(-standStillVariance, standStillVariance);
    }

    private void PlanNextRequest()
    {
        nextRequestTime = Time.time + requestMean + Random.Range(-requestVariance, requestVariance);
    }
}

using System.Collections;
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

    public Sprite happyEmote;
    public Sprite sadEmote;

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

    public void CorrectZ()
    {
        // Draw closer to bottom kids in front
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    public void CompleteRequest(bool good)
    {
        if (currentCoroutine == null)
        {
            requestSprite.sprite = good ? happyEmote : sadEmote;
            currentCoroutine = StartCoroutine(DelayBubbleClose(good));
        }
    }

    private Coroutine currentCoroutine;

    public float showEmoteTime;

    private IEnumerator DelayBubbleClose(bool good)
    {
        if (good) FindObjectOfType<Score>().score++;

        yield return new WaitForSeconds(showEmoteTime);
        Requested = false;
        requestBubble.SetActive(false);
        PlanNextRequest();

        currentCoroutine = null;
    }

    public int ReqIndex;

    private void Update()
    {
        if (target.HasValue)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.Value, walkSpeed * Time.deltaTime);
            CorrectZ();

            if ((target.Value - (Vector2)transform.position).sqrMagnitude < 0.1f)
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

            ReqIndex = Random.Range(0, requests.Length);
            requestSprite.sprite = requests[ReqIndex];
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

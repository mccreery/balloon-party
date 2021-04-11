using UnityEngine;

public class Walk : MonoBehaviour
{
    public Rect walkableArea;
    public float walkSpeed;

    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        float horz = Input.GetAxisRaw("Horizontal");

        if (horz < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horz > 0)
        {
            spriteRenderer.flipX = false;
        }

        Vector3 walk = new Vector2(horz, Input.GetAxisRaw("Vertical")).normalized;
        Vector2 position = transform.position + walk * walkSpeed * Time.deltaTime;
        position = walkableArea.Clamp(position);

        transform.position = new Vector3(position.x, position.y, position.y);
    }
}

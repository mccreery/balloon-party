using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string button = "Fire1";

    private List<Kid> kidsInRange = new List<Kid>();

    public GameObject interactBubble;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Kid kid = other.gameObject.GetComponent<Kid>();

        if (kid == null ||!kidsInRange.Contains(kid))
        {
            kidsInRange.Add(kid);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Kid kid = collision.gameObject.GetComponent<Kid>();
        kidsInRange.Remove(kid);
    }

    private void Update()
    {
        Kid kid = GetKid();
        interactBubble.SetActive(kid != null);

        if (kid != null && Input.GetButtonDown(button))
        {
            kid.CompleteRequest();
        }
    }

    private Kid GetKid()
    {
        float distance = Mathf.Infinity;
        Kid closestKid = null;

        foreach (Kid kid in kidsInRange)
        {
            if (kid.Requested && Vector2.Distance(kid.transform.position, transform.position) < distance)
            {
                closestKid = kid;
            }
        }
        return closestKid;
    }
}

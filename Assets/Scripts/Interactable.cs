using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocus = false;

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    void Update()
    {
        if (isFocus)
        {
            Debug.Log("Press I to interact");
            if (Input.GetKeyDown(KeyCode.I))
                Interact();
        }
    }

    public virtual void Interact()
    {
        Debug.Log("interact!");
    }

    public void SetIsFocus(Transform playerTransform)
    {
        float distance = Vector3.Distance(interactionTransform.position, playerTransform.position);
        isFocus = distance <= radius;
    }
}

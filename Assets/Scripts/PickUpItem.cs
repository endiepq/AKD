using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{
    private bool isPickedUp = false;
    private bool isPlacedInPickup = false;
    public bool IsPlacedInPickup
    {
        get { return isPlacedInPickup; }
        set { isPlacedInPickup = value; }
    }
    private Transform playerHand;
    public static PickupItem currentHeldItem = null;

    private void Start()
    {
        playerHand = GameObject.FindWithTag("PlayerHand").transform;
    }

    public void Interact()
    {
        if (!isPlacedInPickup && currentHeldItem == null)
        {
            PickUp();
        }
    }

    public string GetInteractionMessage()
    {
        return currentHeldItem == null ? "Нажмите H чтобы взять предмет" : string.Empty;
    }

    private void PickUp()
    {
        isPickedUp = true;
        currentHeldItem = this;

        transform.position = playerHand.position;
        transform.rotation = playerHand.rotation;
        transform.SetParent(playerHand);

        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.isKinematic = true;
        }
    }

    public void Drop()
    {
        isPickedUp = false;
        isPlacedInPickup = false;
        currentHeldItem = null;

        transform.SetParent(null);

        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.isKinematic = false;
        }
    }
}

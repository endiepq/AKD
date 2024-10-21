using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{
    private bool isPickedUp = false;
    private Transform playerHand; // Ссылка на позицию "руки" игрока (где предмет будет удерживаться)
    public bool isPlacedInPickup = false;

    private void Start()
    {
        playerHand = GameObject.FindWithTag("PlayerHand").transform; // Найти объект с тегом "PlayerHand" для удержания предметов
    }

    public void Interact()
    {
        if (!isPickedUp && !isPlacedInPickup)
        {
            PickUp();
        }
        else if (isPickedUp && !isPlacedInPickup)
        {
            PlaceInPickup();
        }
    }

    public string GetInteractionMessage()
    {
        if (isPickedUp)
        {
            return "Нажмите H чтобы положить предмет в пикап";
        }
        else
        {
            return "Нажмите H чтобы взять предмет";
        }
    }

    private void PickUp()
    {
        isPickedUp = true;

        transform.position = playerHand.position;
        transform.rotation = playerHand.rotation;
        transform.SetParent(playerHand);

        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.isKinematic = true;
        }
    }

    private void PlaceInPickup()
    {
        PickupTruck truck = FindObjectOfType<PickupTruck>();

        if (truck != null)
        {
            if (truck.PlaceObjectInTruck(this))
            {
                isPickedUp = false;
                isPlacedInPickup = true;
            }
        }
    }

    public void Drop()
    {
        isPickedUp = false;

        transform.SetParent(null);

        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.isKinematic = false;
        }
    }
}

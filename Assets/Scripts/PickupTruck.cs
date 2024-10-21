using UnityEngine;

public class PickupTruck : MonoBehaviour, IInteractable
{
    public Transform[] cargoSpots;
    private int currentSpotIndex = 0;

    public void Interact()
    {
        if (PickupItem.currentHeldItem != null)
        {
            PlaceObjectInTruck(PickupItem.currentHeldItem);
        }
    }

    public string GetInteractionMessage()
    {
        return PickupItem.currentHeldItem != null ? "Нажмите H чтобы положить предмет в пикап" : string.Empty;
    }

    private bool PlaceObjectInTruck(PickupItem item)
    {
        if (currentSpotIndex < cargoSpots.Length)
        {
            item.transform.position = cargoSpots[currentSpotIndex].position;
            item.transform.rotation = cargoSpots[currentSpotIndex].rotation;
            item.transform.SetParent(cargoSpots[currentSpotIndex]);

            item.Drop();
            item.IsPlacedInPickup = true;

            currentSpotIndex++;
            return true;
        }
        else
        {
            return false;
        }
    }
}

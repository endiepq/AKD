using UnityEngine;

public class PickupTruck : MonoBehaviour
{
    public Transform[] cargoSpots; // Точки для размещения предметов в пикапе

    private int currentSpotIndex = 0;

    public bool PlaceObjectInTruck(PickupItem item)
    {
        if (currentSpotIndex < cargoSpots.Length)
        {
            item.transform.position = cargoSpots[currentSpotIndex].position;
            item.transform.rotation = cargoSpots[currentSpotIndex].rotation;
            item.transform.SetParent(cargoSpots[currentSpotIndex]);

            item.Drop();
            item.isPlacedInPickup = true;

            currentSpotIndex++;
            return true;
        }
        else
        {
            Debug.Log("Все места в пикапе заняты!");
            return false;
        }
    }
}

using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool isOpen = false;
    private bool isAnimating = false;

    private float openAngle = 90f;
    private float animationSpeed = 3f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private Transform doorParent;

    void Start()
    {
        doorParent = transform.parent;
        closedRotation = doorParent.transform.localRotation;
        openRotation = Quaternion.Euler(doorParent.transform.localEulerAngles + new Vector3(0, openAngle, 0));
    }

    void Update()
    {
        if (isAnimating)
        {
            if (isOpen)
            {
                doorParent.transform.localRotation = Quaternion.Lerp(doorParent.transform.localRotation, openRotation, Time.deltaTime * animationSpeed);

                if (Quaternion.Angle(doorParent.transform.localRotation, openRotation) < 0.1f)
                {
                    doorParent.transform.localRotation = openRotation;
                    isAnimating = false;
                }
            }
            else
            {
                doorParent.transform.localRotation = Quaternion.Lerp(doorParent.transform.localRotation, closedRotation, Time.deltaTime * animationSpeed);

                if (Quaternion.Angle(doorParent.transform.localRotation, closedRotation) < 0.1f)
                {
                    doorParent.transform.localRotation = closedRotation;
                    isAnimating = false;
                }
            }
        }
    }

    public void Interact()
    {
        if (!isAnimating)
        {
            isOpen = !isOpen;
            isAnimating = true;
        }
    }

    public string GetInteractionMessage()
    {
        return isOpen ? "Нажмите H чтобы закрыть дверь" : "Нажмите H чтобы открыть дверь";
    }
}

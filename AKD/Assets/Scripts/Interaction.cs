using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    private float interactDistance = 3f;
    public TMP_Text interactText;
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactText.text = interactable.GetInteractionMessage();
                interactText.enabled = true;

                if (Input.GetKeyDown(KeyCode.H))
                {
                    interactable.Interact();
                }
            }
            else
            {
                interactText.enabled = false;
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public List<Interactable> interactables;
    public GameObject interactTestActionPrefab;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Interactable>())
            interactables.Add(collider.GetComponent<Interactable>());
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Interactable>())
            interactables.Remove(collider.GetComponent<Interactable>());
    }

    public void OnInteract()
    {
        foreach (var interactable in interactables)
            Interact(interactable);
    }

    private void Interact(Interactable interactable)
    {
        Instantiate(interactTestActionPrefab, transform.position, Quaternion.identity);
    }
}

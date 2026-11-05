using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string ItemName;

    public string GetItemName()
    {
        return ItemName;
    }
}
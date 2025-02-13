using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public enum Resource
{
    Stone,
    Wood,
    Iron
}

 public class ResourceSource : MonoBehaviour
{
    public static ResourceSource Instance { get; set; }

    public Resource type;
    public int quantity;

    public UnityEvent onQuantityChange;

    public void GatherResource(int amount, Unit gatheringUnit)
    {
        quantity -= amount;

        int amountToGive = amount;

        if (quantity < 0)
        {
            amountToGive = amount + quantity;
        }

        if (quantity <= 0)
        {
            Destroy(gameObject);
        }

        if (onQuantityChange != null)
        {
            onQuantityChange.Invoke();
        }
    }
}
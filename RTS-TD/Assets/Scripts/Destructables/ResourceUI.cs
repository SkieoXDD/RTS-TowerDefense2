using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI resourceQuantity;
    public ResourceSource resource;
    void OnMouseEnter()
    {
        popupPanel.SetActive(true);
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        popupPanel.SetActive(false);
    }

    public void OnQuantityChange()
    {
        resourceQuantity.text = resource.quantity.ToString();
    }
}

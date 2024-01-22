using UnityEngine;
using UnityEngine.UI;

public class InventoryDescription : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemDescriptionText;

    public void Awake()
    {
        RefreshDescription();
    }

    public void RefreshDescription()
    {
        if (itemIcon != null) itemIcon.gameObject.SetActive(false);
        if (itemName != null) itemName.text = "";
        if (itemDescriptionText != null) itemDescriptionText.text = "";
    }

    public void SetDescription(ItemClass item)
    {
        if (item != null)
        {
            if (itemIcon != null)
            {
                itemIcon.gameObject.SetActive(true);
                itemIcon.sprite = item.itemIcon;
            }
            if (itemName != null) itemName.text = item.itemName;
            if (itemDescriptionText != null) itemDescriptionText.text = item.itemDescription;
        }
        else
        {
            RefreshDescription(); // Clear the description if the item is null
        }
    }
}

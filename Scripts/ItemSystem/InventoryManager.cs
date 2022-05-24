using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Attributes

    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    #endregion

    #region Unity Metods

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
    }

    #endregion

    #region Equippable Items Metods

    private void EquipFromInventory(Item item)
    {
        if (item is EquippableItems)
        {
            Equip((EquippableItems)item);
        }

        if (item is ConsumableItem)
        {
            if (item.Use() && item.amount > 0)
            {
                item.amount--;
                if (item.amount<=0)
                {
                    inventory.RemoveItems(item);
                }
            }
        }
    }

    private void UnequipFromEquipPanel(Item item)
    {
        if (item is EquippableItems)
        {
            Unequip((EquippableItems)item);
        }
    }

    public void Equip(EquippableItems item)
    {
        if (inventory.RemoveItems(item))
        {
            EquippableItems previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItems item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }

    #endregion
}
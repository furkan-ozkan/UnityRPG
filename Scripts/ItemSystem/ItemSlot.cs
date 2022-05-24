using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour,IPointerClickHandler
{
    #region Attributes

    public event Action<Item> OnRightClickEvent;
    private Item _item;
    public Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.icon;
                image.enabled = true;
            }
        }
    }
    [SerializeField] Image image;

    #endregion

    #region Unity Metods - Interface Metods

    // When a change happen update the image component.
    protected virtual void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();
    }

    // It triggers when right click used on GUI and its trigger Events.
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (item !=null && OnRightClickEvent !=null)
            {
                OnRightClickEvent(item);
            }
        }
    }

    #endregion
}
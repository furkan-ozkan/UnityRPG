using UnityEngine;

public class LeverPart : MonoBehaviour,IInteraction
{
    public Inventory _inventory;
    public Item item;
    public void Action()
    {
        if (_inventory.RemoveItems(item))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<BridgeDrop>().enabled = true;
            Destroy(GetComponent<LeverPart>());
        }
    }
}

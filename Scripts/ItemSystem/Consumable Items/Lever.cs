using UnityEngine;

[CreateAssetMenu(menuName = "Create/Item/Consumables/Lever")]
public class Lever : ConsumableItem
{
    public override bool Use()
    {
        Debug.Log("It works on my machine!");
        return true;
    }
}

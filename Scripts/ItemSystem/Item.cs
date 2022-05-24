using UnityEngine;

[CreateAssetMenu(menuName = "Create/Item/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int amount;
    public virtual bool Use()
    {
        return false;
    }
}

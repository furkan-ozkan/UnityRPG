using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Chest,
    Pauldron,
    Gloves,
    Boots,
    Weapon,
    Ring1,
    Ring2,
    Earring1,
    Earring2,
    Neckless,
    Belt
}
[CreateAssetMenu(menuName = "Create/Item/Equippable Item")]
public class EquippableItems : Item
{
    #region General Attributes

    [Header("General Attributes")] [Space]
    public EquipmentType equipmentType;

    public int gemSlots;

    public int agiStat;
    public int intStat;
    public int strStat;

    public float itemDurability;

    #endregion

    #region Weapon Attributes

    [Header("Weapon Attributes")] [Space]
    public float weaponDamege;
    public float weaponCritChance;

    #endregion

    #region Armor Attributes

    [Header("Armor Attributes")] [Space]
    public int armorRate;
    public int armorHealth;

    #endregion

    #region Trinket Attributes

    [Header("Trinket Attributes")] [Space]
    public float critRate;

    #endregion
}
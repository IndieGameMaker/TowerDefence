
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Cunsumable
}

public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public int quantity;
    public bool isMultiple;
}

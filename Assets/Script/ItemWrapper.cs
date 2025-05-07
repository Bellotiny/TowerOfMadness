using UnityEngine;

[System.Serializable]
public class ItemWrapper
{
    [SerializeField] private InventoryItem item;
    [SerializeField] private int count;

    public InventoryItem GetItem(){
        return item;
    }
    public int GetItemCount(){
        return count;
    }
}

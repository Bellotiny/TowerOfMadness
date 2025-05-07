using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Inventory inventory;
    void Start()
    {
        inventory.InitInventory();
    }

}

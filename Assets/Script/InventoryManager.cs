using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public TextMeshProUGUI appleText;
    public TextMeshProUGUI watermelonText;
    public TextMeshProUGUI orbText;

    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string itemTag)
    {
        if (inventory.ContainsKey(itemTag))
        {
            inventory[itemTag]++;
        }
        else
        {
            inventory[itemTag] = 1;
        }

        Debug.Log($"Collected {itemTag}. Total: {inventory[itemTag]}");
        UpdateInventoryUI();
    }

    public int GetItemCount(string itemTag)
    {
        return inventory.ContainsKey(itemTag) ? inventory[itemTag] : 0;
    }

    private void UpdateInventoryUI()
    {
        if (appleText != null)
            appleText.text = "" + GetItemCount("Apple");

        if (watermelonText != null)
            watermelonText.text = "" + GetItemCount("Watermelon");

        if (orbText != null)
            orbText.text = "" + GetItemCount("Orb");
    }

    public Dictionary<string, int> GetInventory()
    {
        return inventory;
    }
    public void RefreshUI()
    {
        UpdateInventoryUI();
    }
}

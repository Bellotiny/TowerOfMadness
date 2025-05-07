
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Scriptable Objects/InventoryItem")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private Vector3 itemLocalPositition;
    [SerializeField] private Vector3 itemLocalRotation;

    public Sprite GetSprite(){
        return itemSprite;
    }

    public GameObject GetPrefab(){
        return itemPrefab;
    }

    public Vector3 GetItemLocalPositition(){
        return itemLocalPositition;
    }

    public Quaternion GetRotation(){
        return Quaternion.Euler(itemLocalRotation);
    }
}

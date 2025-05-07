using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TMP_Text itemCount;
    [SerializeField] private Button button;

    public void InitSlot(Sprite sprite, int iCount){
        itemSprite.sprite = sprite;
        UpdateItemCount(iCount);
    }
    public void UpdateItemCount(int iCount){
        itemCount.text = iCount.ToString();
    }
    public void AssignButtonCallback(System.Action onClickCallBack){
        button.onClick.AddListener( ()=> onClickCallBack());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]

public class Item : ScriptableObject
{
    public string itemName; // 아이템의 이름
    public Sprite itemImage; // 아이템의 이미지
    public GameObject itemPrefab; // 아이템의 프리팹
    public ItemType itemType;
	public string weaponType; // 무기유형

    public enum ItemType
	{
        Equipment, //장비
        Used, //소모품
        ETC //기타
	}
	
}

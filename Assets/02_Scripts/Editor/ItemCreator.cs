using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemCreator : EditorWindow
{
    private string itemName = "New Item";
    private ItemType itemType = ItemType.Weapon;
    private int quantity = 1;
    private bool isMulitple = false;
    
    [MenuItem("Window/Item Creator")]
    private static void ShowWindow()
    {
        GetWindow<ItemCreator>("아이템 생성");
    }

    private void OnGUI()
    {
        itemName = EditorGUILayout.TextField("아이템 명", itemName);
        itemType = (ItemType)EditorGUILayout.EnumPopup("아이템 종류", itemType);
        quantity = EditorGUILayout.IntField("수량", quantity);
        isMulitple = EditorGUILayout.Toggle("복수 보유 여부", isMulitple);

        if (GUILayout.Button("아이템 생성"))
        {
            ItemData data = ScriptableObject.CreateInstance<ItemData>();
            data.itemName = itemName;
            data.itemType = itemType;
            data.quantity = quantity;
            data.isMultiple = isMulitple;
            
            AssetDatabase.CreateAsset(data, $"Assets/{itemName}.asset");
            AssetDatabase.SaveAssets();
        }
    }
}

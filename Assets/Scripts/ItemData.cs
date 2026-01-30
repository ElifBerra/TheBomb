using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Game/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Settings")] 
    public string itemName; 
    public float fallSpeed; 
    public int scoreValue;

    public bool isBomb = false;

    [Header("Visuals")]
    public Sprite itemSprite;
    public Color itemColor = Color.white;
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestItem : MonoBehaviour {
    public KeyCode predefinedKey = KeyCode.Alpha1;
    public KeyCode generateItemKey = KeyCode.Space;
    public KeyCode idToItem = KeyCode.Tab;
    private Item item;
    private Image image;

    void Start() {
        item = ItemGenerator.GenerateRandomItem();
        item.DebugLog();
        image = GetComponent<Image>();
        if(image != null)
            image.sprite = item.GetSprite();
    }

	void Update() {
        if(Input.GetKeyDown(generateItemKey))
            GenerateNewItem();
        if(Input.GetKeyDown(idToItem))
            RecreateItem();
        if(Input.GetKeyDown(predefinedKey))
            GeneratePredefined();
    }

    private void GenerateNewItem() {
        item = ItemGenerator.GenerateRandomItem();
        DebugAndDisplay();
    }
    private void RecreateItem() {
        item = ItemGenerator.IDToItem(item.ID);
        DebugAndDisplay();
    }
    private void GeneratePredefined() {
        item = ItemGenerator.GeneratePredefinedItem(EPredefinedItem.TEST_QUEST);
        DebugAndDisplay();
    }

    private void DebugAndDisplay() {
        item.DebugLog();
        if(image != null)
            image = GetComponent<Image>();
        image.sprite = item.GetSprite();
    }
	
}

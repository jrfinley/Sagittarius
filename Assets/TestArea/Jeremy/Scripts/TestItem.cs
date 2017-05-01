using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestItem : MonoBehaviour {
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
    }

    private void GenerateNewItem() {
        item = ItemGenerator.GenerateRandomItem();
        item.DebugLog();
        if(image != null)
            image = GetComponent<Image>();
        image.sprite = item.GetSprite();
    }
    private void RecreateItem() {
        item = ItemGenerator.IDToItem(item.ID);
        item.DebugLog();
        if(image == null)
            image = GetComponent<Image>();
        image.sprite = item.GetSprite();
    }
	
}

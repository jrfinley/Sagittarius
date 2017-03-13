using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestItem : MonoBehaviour {
    public KeyCode generateItemKey = KeyCode.Space;
    private Item item;
    private Image image;

    void Start() {
        item = ItemGenerator.GenerateItem();
        item.DebugLog();
        image = GetComponent<Image>();
        if(image != null)
            image.sprite = Resources.Load<Sprite>("ItemIcons/" + item.IconName);
    }

	void Update() {
        if(Input.GetKeyDown(generateItemKey))
            GenerateNewItem();
    }

    private void GenerateNewItem() {
        item.RemoveFromIDDatabase();
        item = ItemGenerator.GenerateItem();
        item.DebugLog();
        image = GetComponent<Image>();
        if(image != null)
            image.sprite = Resources.Load<Sprite>("ItemIcons/" + item.IconName);
    }
	
}

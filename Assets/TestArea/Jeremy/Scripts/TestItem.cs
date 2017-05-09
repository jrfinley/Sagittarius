using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestItem : MonoBehaviour {
    public KeyCode predefinedOne = KeyCode.Alpha1;
    public KeyCode predefinedTwo = KeyCode.Alpha2;
    public KeyCode predefinedThree = KeyCode.Alpha3;
    public KeyCode predefinedFour = KeyCode.Alpha4;
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
        if(Input.GetKeyDown(predefinedOne))
            GeneratePredefinedNoMods();
        if(Input.GetKeyDown(predefinedTwo))
            GeneratePredefinedMods();
        if(Input.GetKeyDown(predefinedThree))
            GeneratePredefinedBaseNoMods();
        if(Input.GetKeyDown(predefinedFour))
            GeneratePredefinedBaseMods();
    }

    private void GenerateNewItem() {
        item = ItemGenerator.GenerateRandomItem();
        DebugAndDisplay();
    }
    private void RecreateItem() {
        item = ItemGenerator.IDToItem(item.ID);
        DebugAndDisplay();
    }
    private void GeneratePredefinedNoMods() {
        item = ItemGenerator.GeneratePredefinedItem(EPredefinedItem.TEST_QUEST_NO_MODS);
        DebugAndDisplay();
    }
    private void GeneratePredefinedMods() {
        item = ItemGenerator.GeneratePredefinedItem(EPredefinedItem.TEST_QUEST_MODS);
        DebugAndDisplay();
    }
    private void GeneratePredefinedBaseNoMods() {
        item = ItemGenerator.GeneratePredefinedItem(EPredefinedItem.TEST_QUEST_BASE_NO_MODS);
        DebugAndDisplay();
    }
    private void GeneratePredefinedBaseMods() {
        item = ItemGenerator.GeneratePredefinedItem(EPredefinedItem.TEST_QUEST_BASE_MODS);
        DebugAndDisplay();
    }

    private void DebugAndDisplay() {
        item.DebugLog();
        if(image != null)
            image = GetComponent<Image>();
        image.sprite = item.GetSprite();
    }
	
}

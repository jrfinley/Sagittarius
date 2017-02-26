using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestItem : MonoBehaviour {
    private Item item;
    private Image image;

	void Start () {
        item = ItemGenerator.Instance.GenerateItem();
        ItemDatabase.Instance.AddItem(item);
        item.DebugLog();
        image = GetComponent<Image>();
        if (image != null)
            image.sprite = Resources.Load<Sprite>("ItemIcons/" + item.IconName);
	}
	
}

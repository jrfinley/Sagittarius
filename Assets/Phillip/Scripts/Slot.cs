using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
attached to the slot prefab object, allows for the adding and stacking of items
as well as this holds the UseItem function which is what is being called from
the child object UseItem on the SlotItem Prefab, its utilizing unitys built in ontouch/ onclick 
functionality to create simple effective on touch use of items
*/
public class Slot : MonoBehaviour
{
    private Stack<Item> items;//handles all items a stack contains * .push = add to stack, .pop = remove top item from stack

    public Stack<Item> Items
    {
        get { return items; }
        set { items = value; }
    }

    public Text stackText;

    public Sprite slotEmpty;
    public Sprite slotHighLight;

    public bool IsEmpty
    {
        get { return items.Count == 0; }//if 0 its returning false
    }
    public bool IsAvaliable
    {
        get { return CurrentItem.maxSize > items.Count; }
    }
    public Item CurrentItem
    {
        get { return items.Peek(); }
    }


    void Start()
    {
        items = new Stack<Item>();

        RectTransform slotRect = GetComponent<RectTransform>();
        RectTransform textRect = stackText.GetComponent<RectTransform>();

        int txtScaleFactor = (int)(slotRect.sizeDelta.x * .60f);

        stackText.resizeTextMaxSize = txtScaleFactor;
        stackText.resizeTextMinSize = txtScaleFactor;
    }

    public void AddItem(Item item)//adds more items of same type to stack, note: there is a stack cap in this system
    {
        items.Push(item);

        if(items.Count > 1)
        {
            stackText.text = items.Count.ToString();
        }

        ChangeSprite(item.spriteNeutral, item.spriteHighLighted);
    }

    private void ChangeSprite(Sprite neutral, Sprite highLight)//allows the player to have visual aid when object is being interacted with
    {
        GetComponent<Image>().sprite = neutral;

        SpriteState st = new SpriteState();
        st.highlightedSprite = highLight;
        st.pressedSprite = neutral;

        GetComponent<Button>().spriteState = st;
    }

    public void UseItem()//while slots not empty will check the item and then proceed to use item
    {
        if (!IsEmpty)
        {
            items.Pop().UseItem();

            stackText.text = items.Count > 1 ? items.Count.ToString() : string.Empty;//cleans up stack method

            if(IsEmpty)
            {
                ChangeSprite(slotEmpty, slotHighLight);
                Inventory.EmptySlots++;
            }
        }
    }

    public void AddItems(Stack<Item> items)//allows stack allocation of items
    {
        this.items = new Stack<Item>(items);
         
        stackText.text = items.Count > 1 ? items.Count.ToString() : string.Empty;

        ChangeSprite(CurrentItem.spriteNeutral, CurrentItem.spriteHighLighted);
    }

    public void OnPointerClick(PointerEventData eventData)//this is how to use item when using mouse controls there is a touch input function as well
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            UseItem();
        }
    }

    public void ClearSlot()
    {
        items.Clear();
        ChangeSprite(slotEmpty, slotHighLight);
        stackText.text = string.Empty;
    }

}

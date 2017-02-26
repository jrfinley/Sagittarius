using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    #region propeties 
    private RectTransform inventoryRect;

    private float inventoryWidth;
    private float inventoryHeight;

    public int slots;
    public int rows;

    public float slotPaddingWidth;
    public float slotPaddingLength;

    public float slotSize;

    public GameObject slotPref;

    private Slot from;
    private Slot to;

    private List<GameObject> allSlots;

    private static int emptySlots;
    public static int EmptySlots
    {
        get { return emptySlots; }
        set { emptySlots = value; }
    }
    #endregion

    public GameObject toolTipObj;
    private static GameObject toolTip;


    public Text sizeTextObject;
    private static Text sizeText;
    public Text visualTextObject;
    private static Text visualText;



    void Start()
    {
        toolTip = toolTipObj;
        sizeText = sizeTextObject;
        visualText = visualTextObject;

        CreateLayout();
    }

    public void ShowToolTip(GameObject slot)
    {
        Slot tmpSlot = slot.GetComponent<Slot>();

        if (!tmpSlot.IsEmpty)
        {
            visualText.text = tmpSlot.CurrentItem.GetToolTip();
            sizeText.text = visualText.text;

            toolTip.SetActive(true);


            float xPos = slot.transform.position.x + slotPaddingWidth;
            float yPos = slot.transform.position.y - slot.GetComponent<RectTransform>().sizeDelta.y - 3;

            toolTip.transform.position = new Vector2(xPos, yPos);
        }

    }
    public void HideToolTip()
    {
        toolTip.SetActive(false);
    }


    //draws out the length and width of inventory through number of slots formulated, including the padding between each slot for visual reasons
    private void CreateLayout()
    {
        allSlots = new List<GameObject>();

        emptySlots = slots;

        //formulas to get width and height of inventory
        inventoryWidth = (slots / rows) * (slotSize + slotPaddingWidth) + slotPaddingWidth;
        inventoryHeight = rows * (slotSize + slotPaddingLength) + slotPaddingLength;


        inventoryRect = GetComponent<RectTransform>();

        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);

        int columns = slots / rows;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slotPref);

                RectTransform slotRect = newSlot.GetComponent<RectTransform>();

                newSlot.name = "Slot";

                newSlot.transform.SetParent(this.transform.parent);

                slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingWidth * (x + 1) +
                    (slotSize * x), -slotPaddingLength * (y + 1) - (slotSize * y));

                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);

                newSlot.transform.SetParent(this.transform);

                allSlots.Add(newSlot);
            }
        }
    }

    /* this function exists to add the object picked up into the appropriate 
    inventory slot placement.
    */
    public bool AddItem(Item item)
    {
        if(item.maxSize == 1)
        {
            PlaceEmpty(item);
            return true;
        }
        else
        {
            foreach (GameObject slot in allSlots)
            {
                Slot temp = slot.GetComponent<Slot>();

                if (!temp.IsEmpty)
                {
                    if(temp.CurrentItem.name == item.name && temp.IsAvaliable)//changed type to id here
                    {
                        temp.AddItem(item);
                        return true;
                    }
                }
            }
            if(emptySlots > 0)
            {
                PlaceEmpty(item);
            }
        }
        return false;
    }

    /* this function allows item placement into empty slots
    */
    private bool PlaceEmpty(Item item)
    {
        if(emptySlots > 0)
        {
            foreach (GameObject slot in allSlots)
            {
                Slot temp = slot.GetComponent<Slot>();

                if (temp.IsEmpty)
                {
                    temp.AddItem(item);
                    emptySlots--;
                    return true;
                }
            }
        }
        return false;
    }

    /*
    allows items to be moved, i utilize this function using unity's built in ontouch/ onclick component 
    */
    public void MoveItem(GameObject clicked)
    {
        if(from == null)
        {
            if (!clicked.GetComponent<Slot>().IsEmpty)
            {
                from = clicked.GetComponent<Slot>();
                from.GetComponent<Image>().color = Color.gray;
            }
        }
        else if(to == null)
        {
            to = clicked.GetComponent<Slot>();
        }
        if (to != null && from != null)
        {
            Stack<Item> tempTo = new Stack<Item>(to.Items);
            to.AddItems(from.Items);

            if(tempTo.Count == 0)
            {
                from.ClearSlot();
                Debug.Log("Slot Cleared");
            }
            else
            {
                from.AddItems(tempTo);
                Debug.Log("Slot item returned");

            }

            from.GetComponent<Image>().color = Color.white;

            to = null;
            from = null;
        }
    }
}

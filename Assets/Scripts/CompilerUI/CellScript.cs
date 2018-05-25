using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CellScript : MonoBehaviour, IDropHandler
{
    public bool unlimited = false;
    public bool swap = true;
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        if (swap)
        {
            if (item && DragScript.startParent.GetComponent<CellScript>().swap == true)
             {
                Instantiate(item, DragScript.startParent);
             
            }
                Destroy(item);
                DragScript.itemBeingDragged.transform.SetParent(transform);
                DragScript.itemBeingDragged.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
        }
        
        if (unlimited)
        {
            if (!item)
            {
                DragScript.itemBeingDragged.transform.SetParent(transform);
                DragScript.itemBeingDragged.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
            }
        }

    }
    #endregion
}
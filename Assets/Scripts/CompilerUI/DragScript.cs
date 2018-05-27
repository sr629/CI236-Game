using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class DragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;

    //itemBeingDragged 
    Vector3 startPosition;
    public static Transform startParent;
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        //GetComponentInParent<LayoutElement>().ignoreLayout = true;
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.SetParent(transform.root);
        if (startParent.GetComponent<CellScript>().unlimited == true)
        {
            Instantiate(transform.gameObject, startParent);
            startParent.GetChild(0).GetComponent<CanvasGroup>().blocksRaycasts = true;
            startParent.GetChild(0).localPosition = new Vector2(0, 0);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {

        if (transform.parent == startParent || (transform.parent == transform.root && !startParent.GetComponent<CellScript>().unlimited))
        {
            //GetComponent<LayoutElement>().ignoreLayout = false;
            transform.position = startPosition;
            transform.SetParent(startParent);

        }
        else if (transform.parent == transform.root) Destroy(transform.gameObject);
   
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
    }
}
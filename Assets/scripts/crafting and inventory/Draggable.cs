using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    private Vector3 pos;
    public Transform parentToReturnTo = null;
    GameObject placeholder = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        //pos = this.transform.position;

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        int newSiblingIndex = 7;

        for(int i = 0; i < parentToReturnTo.childCount; i++)
        {
            if(this.transform.position.x < parentToReturnTo.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex) newSiblingIndex--;
                placeholder.transform.SetSiblingIndex(i);
                break;
            }
        }
        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // this.transform.position = pos;
        this.transform.SetParent(parentToReturnTo);
        DropZone d = this.transform.parent.GetComponent<DropZone>();
        if (d != null)
        {
            this.transform.position = transform.parent.position;
        }
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeholder);
    }


}

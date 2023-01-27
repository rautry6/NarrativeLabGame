using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Resume : MonoBehaviour, IDropHandler
{

    [SerializeField] private DragDropHandler dragDropHandler;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && dragDropHandler.numRejected < 3)
        {
            GetComponentInChildren<TMP_Text>().color = eventData.pointerDrag.GetComponentInChildren<TMP_Text>().color;
            dragDropHandler.numRejected++;
        }
    }
}

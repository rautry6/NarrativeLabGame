using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionTray : MonoBehaviour, IDropHandler, IPointerDownHandler
{
    [Header("Trays")]
    [SerializeField] private GameObject AcceptTray;
    [SerializeField] private GameObject RejectTray;
    [SerializeField] private GameObject ViewingTray;

    [Header("Tray Type")]
    public TrayType type;
    public enum TrayType
    {
        Accept,
        Reject,
        Viewing
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
           if(type == TrayType.Accept)
            {
                eventData.pointerDrag.gameObject.transform.SetParent(AcceptTray.transform);
                eventData.pointerDrag.transform.localScale = new Vector3(1, 1, 1);
            }
           else if(type == TrayType.Reject)
            {
                eventData.pointerDrag.gameObject.transform.SetParent(RejectTray.transform);
                eventData.pointerDrag.transform.localScale = new Vector3(1, 1, 1);
            }
           else if(type == TrayType.Viewing)
            {
                eventData.pointerDrag.gameObject.transform.SetParent(ViewingTray.transform);
                eventData.pointerDrag.transform.localScale = new Vector3(1.96f, 1.4f, 1f);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        //selectedResume.SetActive(true);
        //selectedResume.GetComponent<SelectedResume>().ShowResume(resume);
    }
}

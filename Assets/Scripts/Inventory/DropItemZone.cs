using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItemZone : MonoBehaviour, IPointerClickHandler
{
    public event Action<DropItemZone> OnPointClickEvent;

    private void Awake()
    {
        OnPointClickEvent = HandleDropItemClick;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnPointClickEvent != null)
        {
            OnPointClickEvent(this);
        }
    }

    public void HandleDropItemClick(DropItemZone dropItemZone)
    {
        Manager.inventoryManager.PlayerDropItem();
    }
}

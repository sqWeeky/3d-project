using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerClickHandler
{
    private int _pointerId = -1;

    public event Action ClickCompleted;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == _pointerId)
        {
            ClickCompleted?.Invoke();
        }
    }
}
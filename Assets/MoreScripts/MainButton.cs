using HTC.UnityPlugin.ColliderEvent;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour, IColliderEventClickHandler, IColliderEventPressEnterHandler, IColliderEventPressExitHandler
{
    public CraneController crane;
    public MainMoveDirection direction;
    public ColliderButtonEventData.InputButton m_activeButton = ColliderButtonEventData.InputButton.Trigger;
    public HashSet<ColliderButtonEventData> pressingEvents = new HashSet<ColliderButtonEventData>();
    public ColliderButtonEventData.InputButton activeButton { get { return m_activeButton; } set { m_activeButton = value; } }

    public void OnColliderEventClick(ColliderButtonEventData eventData)
    {
        Debug.Log("Кнопка нажата");
    }

    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        if (eventData.button == m_activeButton && eventData.clickingHandlers.Contains(gameObject) && pressingEvents.Add(eventData) && pressingEvents.Count == 1)
        {
            if(crane != null)
                crane.SetDirection(direction);
        }
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        if (pressingEvents.Remove(eventData) && pressingEvents.Count == 0)
        {
            if (crane != null)
                crane.SetDirection(MainMoveDirection.None);
        }
    }
}

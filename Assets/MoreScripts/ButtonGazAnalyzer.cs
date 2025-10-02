using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;

public class ButtonGazAnalyzer : MonoBehaviour, IColliderEventPressEnterHandler, IColliderEventPressExitHandler
{   
    public ColliderButtonEventData.InputButton activeButton = ColliderButtonEventData.InputButton.Trigger;
    public GasAnalyzer analyzer;
    private bool isHolding = false;

    void Update()
    {
        if(isHolding && analyzer != null)
        {
            analyzer.UpdateHoldingButton(Time.deltaTime);
        }   
    }

    public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
    {
        if (eventData.button == activeButton && analyzer != null)
        {
            isHolding = true;
            analyzer.StartHoldingButton();
        }
    }

    public void OnColliderEventPressExit(ColliderButtonEventData eventData)
    {
        if (eventData.button == activeButton && analyzer != null)
        {
            isHolding = false;
            analyzer.StopHoldingPower();
        }
    }
}

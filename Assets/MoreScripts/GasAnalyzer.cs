using TMPro;
using UnityEngine;

public class GasAnalyzer : MonoBehaviour
{
    public bool isOn = false;                  // включен ли газоанализатор
    public bool isActionTrigger = false;       // триггер на включение газоанализатора
    public MeshRenderer displayRenderer;       // дисплей газоанализатора
    public TextMeshPro displayText;            // текст газоанализатора
    public Color offColor = Color.black;       // цвет экрана при выключении
    public Color onColor = Color.green;        // цвет при включении
    public float holdTimeRequired = 3f;        // значение дл€ включени€ газоанализатора
    public string dangerTag = "DangerZone";    // тэг опасной зоны
    private Transform dangerZone;              // позици€ опасной зоны
    private float holdTimer = 0f;              // таймер считающий удержание кнопки включени€

    void Start()
    {
        GameObject zone = GameObject.FindGameObjectWithTag(dangerTag);
        if (zone != null)
            dangerZone = zone.transform;

        UpdateDisplay();
    }
    
    void Update()
    {
        if (isOn && dangerZone != null) 
        {
            float distance = Vector3.Distance(transform.position, dangerZone.position);
            if(displayText != null) 
                displayText.text = $"Distance: {distance:F1}m";
        }
    }

    /// <summary>
    /// ћетод вызывающийс€ при включении
    /// </summary>
    public void StartHoldingButton()
    {
        holdTimer = 0f;
        isActionTrigger = false;
    }
    
    /// <summary>
    /// ћетод обновл€ющий состо€ние газоанализатора
    /// </summary>
    /// <param name="deltaTime"></param>
    public void UpdateHoldingButton(float deltaTime)
    {
        holdTimer += deltaTime;
        if(holdTimer >= holdTimeRequired && !isActionTrigger)
        {
            TogglePower();
            isActionTrigger = true;
        }
    }

    /// <summary>
    /// ћетод вызывающийс€ при нажатии выключении
    /// </summary>
    public void StopHoldingPower()
    {
        holdTimer = 0f;
        isActionTrigger = false;
    }

    /// <summary>
    /// ћетод включающий газоанализатор
    /// </summary>
    private void TogglePower()
    {
        isOn = !isOn;
        UpdateDisplay();
    }

    /// <summary>
    /// ћетод обновл€ющий дисплей
    /// </summary>
    private void UpdateDisplay()
    {
        if (displayRenderer != null)
         displayRenderer.material.color = isOn ? onColor : offColor;

        if (displayText != null)
            displayText.text = isOn ? "0.0 m" : "";
    }
}

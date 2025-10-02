using TMPro;
using UnityEngine;

public class GasAnalyzer : MonoBehaviour
{
    public bool isOn = false;                  // ������� �� ��������������
    public bool isActionTrigger = false;       // ������� �� ��������� ���������������
    public MeshRenderer displayRenderer;       // ������� ���������������
    public TextMeshPro displayText;            // ����� ���������������
    public Color offColor = Color.black;       // ���� ������ ��� ����������
    public Color onColor = Color.green;        // ���� ��� ���������
    public float holdTimeRequired = 3f;        // �������� ��� ��������� ���������������
    public string dangerTag = "DangerZone";    // ��� ������� ����
    private Transform dangerZone;              // ������� ������� ����
    private float holdTimer = 0f;              // ������ ��������� ��������� ������ ���������

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
    /// ����� ������������ ��� ���������
    /// </summary>
    public void StartHoldingButton()
    {
        holdTimer = 0f;
        isActionTrigger = false;
    }
    
    /// <summary>
    /// ����� ����������� ��������� ���������������
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
    /// ����� ������������ ��� ������� ����������
    /// </summary>
    public void StopHoldingPower()
    {
        holdTimer = 0f;
        isActionTrigger = false;
    }

    /// <summary>
    /// ����� ���������� ��������������
    /// </summary>
    private void TogglePower()
    {
        isOn = !isOn;
        UpdateDisplay();
    }

    /// <summary>
    /// ����� ����������� �������
    /// </summary>
    private void UpdateDisplay()
    {
        if (displayRenderer != null)
         displayRenderer.material.color = isOn ? onColor : offColor;

        if (displayText != null)
            displayText.text = isOn ? "0.0 m" : "";
    }
}

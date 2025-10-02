using UnityEngine;

public class Cabel : MonoBehaviour
{
    public Transform analyzer;  // позиция газоанализатора
    public Transform probe;     // позиция зонда
    private LineRenderer line;  // LineRenderer

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    void Update()
    {
        line.SetPosition(0, analyzer.position);
        line.SetPosition(1, probe.position);
    }
}

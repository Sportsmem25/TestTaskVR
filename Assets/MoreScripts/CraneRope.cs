using UnityEngine;

public class CraneRope : MonoBehaviour
{
    public Transform startPoint;    // ����� � �����
    public Transform endPoint;      // ����� � �����
    public LineRenderer line;       // LineRenderer

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    void Update()
    {
        line.SetPosition(0, startPoint.position);
        line.SetPosition(1, endPoint.position);
    }
}

using UnityEngine;

public class CraneController : MonoBehaviour
{
    [Header("�������� ����� �����")]
    public Transform beam;     // �����
    public Transform trolley;  // ����
    public Transform hook;     // ����

    [Header("�������� ��������")]
    public float speedBeam = 2f;    // �������� ����� (�����/�����)
    public float speedTrolley = 2f; // �������� ������� (�����/������)
    public float speedHook = 1f;    // �������� ����� (�����/����)

    private MainMoveDirection currentMove = MainMoveDirection.None;

    private void Update()
    {
        switch (currentMove)
        {
            case MainMoveDirection.North:
                beam.Translate(Vector3.forward * speedBeam * Time.deltaTime, Space.Self);
                break;
            case MainMoveDirection.South:
                beam.Translate(Vector3.back * speedBeam * Time.deltaTime, Space.Self);
                break;
            case MainMoveDirection.Right:
                trolley.Translate(Vector3.right * speedTrolley * Time.deltaTime, Space.Self);
                break;
            case MainMoveDirection.Left:
                trolley.Translate(Vector3.left * speedTrolley * Time.deltaTime, Space.Self);
                break;
            case MainMoveDirection.Up:
                hook.Translate(Vector3.up * speedHook * Time.deltaTime, Space.Self);
                break;
            case MainMoveDirection.Down:
                hook.Translate(Vector3.down * speedHook * Time.deltaTime, Space.Self);
                break;
            case MainMoveDirection.None: 
            default: 
                break;
        }
    }

    /// <summary>
    /// ����� ���������� ����������� ��������
    /// </summary>
    /// <param name="dir"></param>
    public void SetDirection(MainMoveDirection dir)
    {
        currentMove = dir;
    }
}

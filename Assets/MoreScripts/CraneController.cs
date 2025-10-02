using UnityEngine;

public class CraneController : MonoBehaviour
{
    [Header("Основные части крана")]
    public Transform beam;     // балка
    public Transform trolley;  // кран
    public Transform hook;     // крюк

    [Header("Скорости движения")]
    public float speedBeam = 2f;    // скорость балки (вперёд/назад)
    public float speedTrolley = 2f; // скорость тележки (влево/вправо)
    public float speedHook = 1f;    // скорость крюка (вверх/вниз)

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
    /// Метод получающий направление движения
    /// </summary>
    /// <param name="dir"></param>
    public void SetDirection(MainMoveDirection dir)
    {
        currentMove = dir;
    }
}

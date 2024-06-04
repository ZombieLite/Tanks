using UnityEngine;

public class PlayerGunCoord : MonoBehaviour
{
    /// <summary>
    /// Позиция координат для пушки
    ///  RET Vector3
    /// </summary>
    /// <returns></returns>
    public Vector3 PlayerGunPosition()
    {
        return this.transform.position;
    }

    /// <summary>
    /// Угол поворота у пушки
    ///  RET Quaternion
    /// </summary>
    /// <returns></returns>
    public Quaternion PlayerGunRotation()
    {
        return this.transform.rotation;
    }
}

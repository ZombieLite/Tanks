using UnityEngine;

public class PlayerGunCoord : MonoBehaviour
{
    /// <summary>
    /// ������� ��������� ��� �����
    ///  RET Vector3
    /// </summary>
    /// <returns></returns>
    public Vector3 PlayerGunPosition()
    {
        return this.transform.position;
    }

    /// <summary>
    /// ���� �������� � �����
    ///  RET Quaternion
    /// </summary>
    /// <returns></returns>
    public Quaternion PlayerGunRotation()
    {
        return this.transform.rotation;
    }
}

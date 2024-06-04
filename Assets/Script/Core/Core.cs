using UnityEngine;
using Cysharp.Threading.Tasks;

public static class Core
{
    static int _playerAlive;

    
    public static void SetPlayerAliveCount(int num)
    {
        _playerAlive = num;
    }

    public static int GetPlayerAliveCount()
    {
        return _playerAlive;
    }

    public static async UniTaskVoid SetTask(System.Action action, float delaySec = 0.0f)
    {
        float tm = Time.time + delaySec;
        while (tm > Time.time)
        {
            await UniTask.Yield();
        }

        try
        {
            action();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }

}

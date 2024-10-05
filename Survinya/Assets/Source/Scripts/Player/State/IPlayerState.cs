using UnityEngine;

public interface IPlayerState
{
    void EnterState();  // 當狀態被啟用時調用
    void ExitState();   // 當狀態結束時調用
    void UpdateState(); // 在每幀中更新行為
}

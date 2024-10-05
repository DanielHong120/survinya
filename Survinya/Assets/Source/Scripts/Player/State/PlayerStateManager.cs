using UnityEngine;
using Zenject;

public class PlayerStateManager : MonoBehaviour
{
    public IPlayerState CurrentState { get; private set; }
    public string CurrentStateName => CurrentState?.GetType().Name;

    [Inject]
    private void Start()
    {
        // 初始化進入角色的初始狀態，例如待機狀態
        SwitchState(new PlayerIdleState(this));
    }

    public void SwitchState(IPlayerState newState)
    {
        // 如果當前有狀態，先退出該狀態
        CurrentState?.ExitState();
        
        // 切換到新的狀態
        CurrentState = newState;
        CurrentState.EnterState();
    }

    private void Update()
    {
        // 當前狀態的邏輯更新
        CurrentState?.UpdateState();
    }
}
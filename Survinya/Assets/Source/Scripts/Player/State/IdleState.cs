using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    private readonly PlayerStateManager _stateManager;

    public PlayerIdleState(PlayerStateManager stateManager)
    {
        _stateManager = stateManager;
    }

    public void EnterState()
    {
        Debug.Log("Entered Idle State");
    }

    public void ExitState()
    {
        Debug.Log("Exited Idle State");
    }

    public void UpdateState()
    {
        // 在 Idle 狀態中檢查是否有輸入變化
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            _stateManager.SwitchState(new PlayerMoveState(_stateManager));
        }
    }
}

using UnityEngine;

public class PlayerMoveState : IPlayerState
{
    private readonly PlayerStateManager _stateManager;

    public PlayerMoveState(PlayerStateManager stateManager)
    {
        _stateManager = stateManager;
    }

    public void EnterState()
    {
        Debug.Log("Entered Move State");
    }

    public void ExitState()
    {
        Debug.Log("Exited Move State");
    }

    public void UpdateState()
    {
        // 在移動狀態中檢查是否停止移動
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            _stateManager.SwitchState(new PlayerIdleState(_stateManager));
        }
    }
}

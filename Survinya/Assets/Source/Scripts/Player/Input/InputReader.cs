using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private PlayerControls _controls;

    // 暴露移動輸入的狀態，讓外部腳本可以查詢
    public Vector2 MoveInput { get; private set; } = Vector2.zero;

    private void Awake()
    {
        _controls = new PlayerControls();

        // 當玩家按下或放開移動按鍵時更新 MoveInput
        _controls.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => MoveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}
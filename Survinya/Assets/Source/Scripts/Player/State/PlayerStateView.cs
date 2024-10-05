using UnityEngine;
using TMPro;
using Zenject;

public class PlayerStateView : MonoBehaviour
{
    private PlayerStateManager _stateManager;

    private TextMeshProUGUI _stateText; // 使用 TextMeshProUGUI 來顯示文字

    [Inject]
    public void Construct(PlayerStateManager stateManager)
    {
        _stateManager = stateManager;
    }

    private void Awake()
    {
        // 獲取 UI 元件
        _stateText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        // 更新 UI 顯示當前狀態
        _stateText.text = $"State: {_stateManager.CurrentStateName}";
    }
}

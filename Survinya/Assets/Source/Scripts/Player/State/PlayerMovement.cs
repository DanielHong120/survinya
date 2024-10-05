using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private InputReader _inputReader;
    private PlayerStateManager _stateManager;
    private Vector2 _moveDirection;

    private Transform _transform;  // 角色的 Transform 元件
    private float _originalScaleX;  // 儲存角色最初的 X 軸 scale

    [Inject]
    public void Construct(InputReader inputReader, PlayerStateManager stateManager)
    {
        _inputReader = inputReader;
        _stateManager = stateManager;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = transform;  // 獲取角色的 Transform 元件
        _originalScaleX = _transform.localScale.x;  // 儲存原始 X 軸的 scale
    }

    private void Update()
    {
        // 在 Update 中從 InputReader 查詢輸入狀態
        _moveDirection = _inputReader.MoveInput;
        // 更新角色的朝向
        FlipCharacter();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // 設定移動速度
        float speed = 5f;  // 調整速度
        _rb.MovePosition(_rb.position + _moveDirection * speed * Time.fixedDeltaTime);
    }

    private void FlipCharacter()
    {
        // 當移動方向為左（_moveDirection.x < 0）或右（_moveDirection.x > 0）時調整角色朝向
        if (_moveDirection.x > 0)
        {
            _transform.localScale = new Vector3(-_originalScaleX, _transform.localScale.y, _transform.localScale.z);
        }
        else if (_moveDirection.x < 0)
        {
            _transform.localScale = new Vector3(_originalScaleX, _transform.localScale.y, _transform.localScale.z);
        }
    }
}
using UnityEngine;
using UnityEngine.Events;

public class TopDownMovement : MonoBehaviour
{

    [SerializeField] InputReader _inputReader;
    [SerializeField] UnityEvent _OnMoving;
    [SerializeField] float speed; //This variable should be from a stats system (In this case is not need it)

    Rigidbody2D _rb;
    bool _allowMovement = true;
    Vector2 _movementVector;

    #region Accesors
    public bool AllowMovement { get => _allowMovement; set => _allowMovement = value; }

    public Vector2 MovementVector { get => _movementVector; }
    #endregion

    private void OnEnable()
    {
        _inputReader.MoveEvent += HandleMove;
    }

    private void OnDisable()
    {
        _inputReader.MoveEvent -= HandleMove;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_movementVector != Vector2.zero)
        {
            _OnMoving?.Invoke();
        }
    }

    void FixedUpdate()
    {
        //Do nothing if something is not allowing the movement
        if (!_allowMovement) return;

        // Move
        _rb.velocity = new Vector2(_movementVector.x * speed, _movementVector.y * speed);
    }

    private void HandleMove(Vector2 _dir)
    {
        _movementVector = _dir;
    }
}

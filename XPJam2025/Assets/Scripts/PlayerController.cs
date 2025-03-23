using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 2.5f;
    [SerializeField] private GameObject feet;
    [SerializeField] private PhysicsMaterial defaultMaterial;
    [SerializeField] private PhysicsMaterial stickyMaterial;
    [SerializeField] private KeyBindsSO keyBindsSo;
    [SerializeField] private Transform spawn;
    private Rigidbody2D _rb;
    private Collider _collider;
    private bool _onTheGround;
    private float _moveInput;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponentInChildren<Collider>();
    }

    private void Update()
    {

        _moveInput = 0;
        
        if (Enum.TryParse(keyBindsSo.keyBinds[0], out KeyCode keyCode1))
        {
            if (Input.GetKeyDown(keyCode1))
            {
                _rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        
        if (Enum.TryParse(keyBindsSo.keyBinds[1], out KeyCode keyCode2))
        {
            if (Input.GetKey(keyCode2))
            {
                
            }
        }

        if (Enum.TryParse(keyBindsSo.keyBinds[2], out KeyCode keyCode3))
        {
            if (Input.GetKey(keyCode3))
            {
                _moveInput = 1f;
            }
        }

        if (Enum.TryParse(keyBindsSo.keyBinds[3], out KeyCode keyCode4))
        {
            if (Input.GetKey(keyCode4))
            {
                _moveInput = -1f;
            }
        }

    }

    void FixedUpdate()
    {
        var colliders = Physics.OverlapSphere(feet.transform.position, 0.5f, LayerMask.GetMask("Ground"));
        
        _onTheGround = colliders.Length != 0;

        Vector3 movement = new Vector3(_moveInput, 0f, 0f);

        _rb.linearVelocity = new Vector3(movement.x * moveSpeed, _rb.linearVelocity.y);
    }

    public void ResetSpawn()
    {
        transform.position = spawn.position;
    }
}
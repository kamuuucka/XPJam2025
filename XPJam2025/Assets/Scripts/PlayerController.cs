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
    private Rigidbody _rb;
    private Collider _collider;
    private bool _onTheGround;
    private float _moveInput;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponentInChildren<Collider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyBindsSo.keyBinds[0].ToString()) && _onTheGround)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(keyBindsSo.keyBinds[1].ToString()))
        {
            _collider.material = stickyMaterial;
        }
        
        if (Input.GetKeyDown(keyBindsSo.keyBinds[2].ToString()))
        {
            _moveInput = -1f;
        }
        else if (Input.GetKeyDown(keyBindsSo.keyBinds[3].ToString()))
        {
            _moveInput = 1f;
        }
    }

    void FixedUpdate()
    {
        var colliders = Physics.OverlapSphere(feet.transform.position, 0.5f, LayerMask.GetMask("Ground"));
        
        _onTheGround = colliders.Length != 0;

        Vector3 movement = new Vector3(_moveInput, 0f, 0f);

        _rb.linearVelocity = new Vector3(movement.x * moveSpeed, _rb.linearVelocity.y, _rb.linearVelocity.z);
    }
}
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
    private Rigidbody _rb;
    private Collider _collider;
    private bool _onTheGround;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponentInChildren<Collider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _onTheGround)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _collider.material = stickyMaterial;
        }
    }

    void FixedUpdate()
    {
        var colliders = Physics.OverlapSphere(feet.transform.position, 0.5f, LayerMask.GetMask("Ground"));
        
        _onTheGround = colliders.Length != 0;
        
        float moveInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveInput, 0f, 0f);

        _rb.linearVelocity = new Vector3(movement.x * moveSpeed, _rb.linearVelocity.y, _rb.linearVelocity.z);
    }
}
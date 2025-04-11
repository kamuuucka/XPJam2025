using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject scrollViewContent;
    [SerializeField] private GameObject level2ui;
    [SerializeField] private GameObject level3ui;
    [SerializeField] private UnityEvent onCollision;

    public static int level;

    private int _level;

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        level++;
        onCollision?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        level++;
        onCollision?.Invoke();
    }
}

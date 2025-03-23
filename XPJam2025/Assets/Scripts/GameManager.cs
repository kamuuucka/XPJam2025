using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject scrollViewContent;
    [SerializeField] private GameObject level2ui;
    [SerializeField] private GameObject level3ui;
    [SerializeField] private UnityEvent onCollision;

    public int level;

    private int _level;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_level == 0)
            {
                var newItem = Instantiate(level2ui, scrollViewContent.transform);
                _level++;
            }
            else
            {
                var newItem = Instantiate(level3ui, scrollViewContent.transform);
            }
        }
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

using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject scrollViewContent;
    [SerializeField] private GameObject level2ui;
    [SerializeField] private GameObject level3ui;

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
}

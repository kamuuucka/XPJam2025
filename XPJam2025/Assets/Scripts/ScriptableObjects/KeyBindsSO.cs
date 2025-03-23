using UnityEngine;

[CreateAssetMenu(fileName = "KeyBinds", menuName = "ScriptableObjects/KeyBindSO", order = 1)]
public class KeyBindsSO : ScriptableObject
{
    public string[] keyBinds = new string[4];
}

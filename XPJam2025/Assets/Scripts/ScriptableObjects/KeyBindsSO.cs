using UnityEngine;

[CreateAssetMenu(fileName = "KeyBinds", menuName = "ScriptableObjects/KeyBindSO", order = 1)]
public class KeyBindsSO : ScriptableObject
{
    public char[] keyBinds = new char[4];
}

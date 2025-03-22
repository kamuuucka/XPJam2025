using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    private enum KeyBind
    {
        Up = 0, Down = 1, Left = 2, Right = 3
    }

    [SerializeField] private KeyBind keyBind;
    [SerializeField] private KeyBindsSO keyBindSO;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        var draggableItem = dropped.GetComponent<DraggableItem>();
        draggableItem.parentAfterDrag = transform;
        keyBindSO.keyBinds[(int)keyBind] = draggableItem.character;
    }
}

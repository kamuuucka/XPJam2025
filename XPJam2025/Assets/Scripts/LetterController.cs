using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LetterController : MonoBehaviour
{
    [SerializeField] private KeyBindsSO letters;
    [SerializeField] private List<Transform> letterPlaces;
    [SerializeField] private List<GameObject> platforms;
    [SerializeField] private Slider slider;
    [SerializeField] private Dropdown dropdown;

    public void CreateTheLetters()
    {
        foreach (var place in letterPlaces)
        {
            var prefab = Resources.Load($"Letters/{letters.keyBinds[letterPlaces.IndexOf(place)]}") as GameObject;
            var letter = Instantiate(prefab, place);
            letter.transform.position = place.position;
            letter.transform.localScale *= slider.value;
        }
    }
}

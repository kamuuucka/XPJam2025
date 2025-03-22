using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    [SerializeField] private KeyBindsSO letters;
    [SerializeField] private List<Transform> letterPlaces;

    public void CreateTheLetters()
    {
        foreach (var place in letterPlaces)
        {
            var prefab = Resources.Load($"Letters/{letters.keyBinds[letterPlaces.IndexOf(place)]}") as GameObject;
            var letter = Instantiate(prefab, place);
            letter.transform.position = place.position;
        }
    }
}

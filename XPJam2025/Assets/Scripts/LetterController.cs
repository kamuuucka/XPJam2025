using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LetterController : MonoBehaviour
{
    [SerializeField] private KeyBindsSO lettersToSave;
    [SerializeField] private List<GameObject> lettersPrefabsRed;
    [SerializeField] private List<GameObject> lettersPrefabsBlue;
    [SerializeField] private List<GameObject> lettersPrefabsGreen;
    [SerializeField] private List<GameObject> lettersPrefabsYellow;
    [SerializeField] private List<Transform> letterPlaces;
    [SerializeField] private List<GameObject> platforms;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private GameObject scrollViewContent;
    [SerializeField] private GameObject level2ui;
    [SerializeField] private GameObject level3ui;

    private int _level;

    public void CreateTheLetters()
    {

        for (int i = 0; i < letterPlaces.Count; i++)
        {
            GameObject letterPrefab = new GameObject();
            if (i == 0)
            {
                letterPrefab = lettersPrefabsRed.FirstOrDefault(
                    obj => obj.name == lettersToSave.keyBinds[i]);
                Debug.Log(letterPrefab);
            }
            
            if (i == 1)
            {
                letterPrefab = lettersPrefabsBlue.FirstOrDefault(
                    obj => obj.name == lettersToSave.keyBinds[i]);
            }
            
            if (i == 2)
            {
                letterPrefab = lettersPrefabsGreen.FirstOrDefault(
                    obj => obj.name == lettersToSave.keyBinds[i]);
            }
            
            if (i == 3)
            {
                letterPrefab = lettersPrefabsYellow.FirstOrDefault(
                    obj => obj.name == lettersToSave.keyBinds[i]);
            }

            var letter = Instantiate(letterPrefab, letterPlaces[i]);
            letter.transform.position = letterPlaces[i].position;
            if(_level != 0) letter.transform.localScale *= slider.value;
        }

        if (_level == 2)
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (i == dropdown.value * 2 || i == dropdown.value * 2 + 1)
                {
                    platforms[i].SetActive(true);
                    platforms[i].transform.localScale *= slider.value;
                }
                else
                {
                    platforms[i].SetActive(false);
                }
            }
        
            letterPlaces[dropdown.value].gameObject.SetActive(false);
        }

        _level++;
        
        if (_level == 1)
        {
            var level2uiobject = Instantiate(level2ui, scrollViewContent.transform);
            level2uiobject.SetActive(true);
            slider = level2uiobject.GetComponentInChildren<Slider>();
        }
        
        if (_level == 2)
        {
            var level3uiobject = Instantiate(level3ui, scrollViewContent.transform);
            level3uiobject.SetActive(true);
            dropdown = level3uiobject.GetComponentInChildren<TMP_Dropdown>();
        }
    }
}

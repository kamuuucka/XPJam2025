using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private Image fadeImage;
    [SerializeField] private GameManager gm;

    private int _level;
    private bool _level2spawned;
    private bool _level3spawned;
    private bool _gameDone;

    private void Update()
    {
        if (GameManager.level == 3 && !_gameDone)
        {
            fadeImage.gameObject.SetActive(true);
            _gameDone = true;
            StartCoroutine(FadeAndQuit());
            
        }
        

        if (GameManager.level == 1 && !_level2spawned)
        {
            _level3spawned = true;
            var level2uiobject = Instantiate(level2ui, scrollViewContent.transform);
            level2uiobject.SetActive(true);
            slider = level2uiobject.GetComponentInChildren<Slider>();
        }
        
        if (GameManager.level == 2 && !_level3spawned)
        {
            _level3spawned = true;
            var level3uiobject = Instantiate(level3ui, scrollViewContent.transform);
            level3uiobject.SetActive(true);
            dropdown = level3uiobject.GetComponentInChildren<TMP_Dropdown>();
        }
    }

    public void CreateTheLetters()
    {
        foreach (var place in letterPlaces)
        {
            // Iterate through all children of the current place
            foreach (Transform child in place.transform)
            {
                // Destroy the child GameObject
                Destroy(child.gameObject);
            }
        }

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

        if (GameManager.level == 2)
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

        
    }
    
    private System.Collections.IEnumerator FadeAndQuit()
    {
        float elapsedTime = 0f;
        Color startColor = fadeImage.color; // Transparent
        Color targetColor = new Color(1, 1, 1, 1); // Fully white

        // Gradually fade the image to white
        while (elapsedTime < 3.0f)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / 3.0f); // Normalized time (0 to 1)
            fadeImage.color = Color.Lerp(startColor, targetColor, t);
            yield return null; // Wait for the next frame
        }

        // Ensure the image is fully white
        fadeImage.color = targetColor;

        // Quit the application
        Debug.Log("Quitting application...");
        Application.Quit();

        // If running in the editor, stop play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script should be applied to all text boxes so they can serve the correct language to the player
public class LocalizedText : MonoBehaviour
{
    public Text text = GetComponent<Text>();
    public string key;

    // Use this for initialization
    void Start()
    {
        TextUpdate();

        //adds this text box to the language update deligate
        LocalizationManager.languageUpdate += TextUpdate;
    }

    private void TextUpdate()
    {
        string result = "#MISSING#";
        if (LocalizationManager.localizedText.TryGetValue(key, out result)
        {
            Debug.Warn(key + " doesn't exist in this language");
        }

        text.text = result;
    }

    private void OnDestroy()
    {
        //When a text box is destroyed, remove it from the language update deligate
        LocalizationManager.languageUpdate -= TextUpdate;
    }
}

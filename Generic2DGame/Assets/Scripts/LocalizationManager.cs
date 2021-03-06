using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
    public static Dictionary<string,string> localizedText = new Dictionary<string, string>();
    public static Dictionary<string, int> languageList = new Dictionary<string, int>();
    public static string currentLanguage = "FI";
    private TextAsset locaData;

    public delegate void LanguageUpdate();
    public static LanguageUpdate languageUpdate;



    public void Start()
    {
        BuildLanguageList();

        LoadLocaData(currentLanguage);
    }

    private void BuildLanguageList()
    {
        //Load and parse the loca data with the selected language
        locaData = Resources.Load<TextAsset>("Loca");

        //Build the list of languages
        int newline = locaData.text.IndexOf('\n');
        string firstRow = locaData.text.Substring(0, newline).Trim();
        string[] columns = firstRow.Split(new char[] { ',' });
        
        for (int i = 1; i < columns.Length; i++)
        {
            languageList.Add(columns[i], i);
            //Debug.Log(columns[i]);
        }
        
    }
    public void LoadLocaData(string languageCode)
    {
        //find the column number of the active language
        int languageNum = languageList[languageCode];
        //Debug.Log("langnum is" + languageNum);

        //Split locaData into an array of rows and build the localizedText dictionary with the current language
        string[] lData = locaData.text.Split(new char[] { '\n' });

        for (int i = 1; i < lData.Length -1 ; i++)
        {
            string[] row = lData[i].Split(new char[] { ',' });
            localizedText[row[0]] = row[languageNum];
            //Debug.Log(row[0] + ":" + row[languageNum]);
        }

        languageUpdate.Invoke();
    }

}
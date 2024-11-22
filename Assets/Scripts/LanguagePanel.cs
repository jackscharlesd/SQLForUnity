using System.Collections.Generic;
using CJacks.Language;
using Databrain;
using TMPro;
using UnityEngine;
using Databrain.Localization;
using UnityEngine.UI;

public class LanguagePanel : MonoBehaviour
{
    
    public DataLibrary data;
    private List<LanguageOD> LanguageODList;
    
    public TMP_Dropdown languageDropdown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        data.OnDataInitialized += Ready;
    }
    
    void Ready()
    {
        var manager = data.GetSingleton<LocalizationManager>(false);
        var lang = "German";
        manager.SetLanguage(lang);
        LanguageODList = data.GetAllInitialDataObjectsByType<LanguageOD>();
        List<string> options = new List<string>();
        foreach (var LanOD in LanguageODList)
        {
            var nm = manager.GetLocalizedText(LanOD.Name);
            options.Add(nm);
            Debug.Log("In " + lang +" the word "+ LanOD.Name +" is "+ nm);
        }
        languageDropdown.ClearOptions();
        languageDropdown.AddOptions(options);
        languageDropdown.value = 0;
        
        languageDropdown.onValueChanged.AddListener(SetLanguage);
        
    }
    public void SetLanguage(int languageIndex)
    {
        LanguageOD theLanguage = LanguageODList[languageIndex];
        Debug.Log("The new language should be: " + theLanguage.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

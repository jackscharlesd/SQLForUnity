
using System;
using Unity.VisualScripting;

using CJacks.Language;
using Databrain;
using Databrain.Attributes;
using Databrain.Localization;
using UnityEngine;
using UnityEngine.Video;

public class LanguageFunctions : MonoBehaviour
{
    public DataLibrary data;
    private LanguageOD persistedValues;
    
    [DataObjectDropdown("data")]
    public LanguageOD ObjectData;
    public LocalizationManager manager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //wait for datalibrary to be set up and then we can access the stored values
        data.OnDataInitialized += Ready;

        data.OnSaved += Saved;
        data.OnLoaded += Loaded;
    }

    void Saved()
    {
        Debug.Log("Data Saved");
    }
    void Loaded()
    {
        persistedValues = ObjectData.GetRuntimeDataObject() as LanguageOD;
        Debug.Log("Data Retrieved");
        Debug.Log((persistedValues.speakerID));
    }

    void ModifyData()
    {
        persistedValues.speakerID += 10;
    }

    void Ready()
    {
        //we can access the database values and set up runtime values
        //if we change the value of the database values, they are not presisted
        var language = ObjectData.Name;
        
        //if we set up the runtime value saving in the datalibrary editor
        // we can obtain a set of values that were saved in the user persistence system
        persistedValues = ObjectData.GetRuntimeDataObject() as LanguageOD;
        
        //Lets get a list of LanguageOD records and list them to the console
        var LanguageODList = data.GetAllInitialDataObjectsByType<LanguageOD>();
        foreach (var LanOD in LanguageODList)
        {
            Debug.Log("Found language: " +LanOD.Name);
        }
        var manager = data.GetSingleton<LocalizationManager>(false);
        manager.SetLanguage("German");
        var _localizedText = manager.GetLocalizedText("Hello");
        Debug.Log("localized Hello is: " + _localizedText);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Save"))
        {
            data.Save(System.IO.Path.Combine(Application.persistentDataPath, "test.json"));
        }
        if (GUILayout.Button("Load"))
        {
            data.Load(System.IO.Path.Combine(Application.persistentDataPath, "test.json"));
        }
        if (GUILayout.Button("Moodify Data"))
        {
            ModifyData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CloneToRuntime()
    {
        // Clone this specific data objects ObjectData and add it to the runtime library
        var _clonedData = data.CloneDataObjectToRuntime(persistedValues, this.gameObject);
        
        // We can now modify the runtime data
        (_clonedData as LanguageOD).speakerID = 15;
        
        // Get runtime clone associated to this game object
        //this would go into the Ready to get the objectdata for this specific object
        // var _clonedData = ObjectData.GetRuntimeDataObject(this.gameObject);
    }
    
}

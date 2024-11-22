using Databrain;
using Databrain.Attributes;
using UnityEngine;

namespace CJacks.Language
{
  [DataObjectAddToRuntimeLibrary] 
  public class LanguageOD : DataObject
  {
    //public DataLibrary data;
    
    [DataObjectDropdown()]
    public LanguageMD MetaData;
    
    [ExposeToInspector]
    [DatabrainSerialize]
    public string BaseLanguage;
    
    [ExposeToInspector]
    [DatabrainSerialize]
    public string Name;
    
    [ExposeToInspector]
    [DatabrainSerialize]
    public bool IsSpeakable;
    
    [ExposeToInspector]
    [DatabrainSerialize]
    public string TTSVoiceName; // overtone voice name
    
    [ExposeToInspector]
    [DatabrainSerialize]
    public int speakerID; // overtone voice ID

  }
}

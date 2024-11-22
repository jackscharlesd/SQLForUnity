using Databrain;
using UnityEngine;

namespace CJacks.Language
{


    public class LanguageMD : DataObject
    {
        public string WikipediaURL;
        public bool TTSLanguage;
        public string ISO2ID;
        public string ISO3ID;

        public string Name;

        /*
         Linguists classify language families primarily through two methods: genetic (or genealogical) classification and typological classification.

            Genetic Classification: This method groups languages into families based on their historical and evolutionary relationships.
            Languages within a family share a common ancestor. For example, the Indo-European family includes languages like
            English, German, and Hindi, which all evolved from a common proto-language1.
            Linguists compare vocabulary, phonetics, and grammar to establish these relationships.

            Typological Classification: This approach categorizes languages based on their structural features rather than their historical relationships.
            Languages are grouped according to similarities in syntax, morphology, and phonology.
            For instance, languages can be classified as isolating (e.g., Vietnamese), agglutinating (e.g., Turkish),
            or inflecting (e.g., Latin) based on how they form words and sentences1.
            */
        public string GeneticClass;
        public string TypologicalClass;
    }
}

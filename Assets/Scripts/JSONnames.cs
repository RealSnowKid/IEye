using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JSONnames : MonoBehaviour
{
    public Dropdown Drdown;
    [SerializeField] TextAsset jsonFile;
    //public List<Text> TextFields;
    private int language;

    // Parts class with all the parts
    [System.Serializable]
    public class Parts
    {
        public string sclera;
        public string choroid;
        public string retina;
        public string cornea;
        public string iris;
        public string lens;
        public string ciliary_body;
        public string vitreous_humor;
        public string optic_nerver;
        public string macula;
        public string anterior_pole;
        public string endotheel;
        public string descemets_layer;
        public string stroma;
        public string bowmans_layer;
        public string epitheel;
        public string anterior_segment;
        public string fovea_centralis;
        public string ora_seratta;
        public string veins;
        public string conjunctiva;
    }

    // A list of parts
    [System.Serializable]
    public class PartsList
    {
        public Parts[] parts;
    }

    public PartsList NewPartList = new PartsList();

    void Start()
    {
        // Set the list of parts from the json file
        NewPartList = JsonUtility.FromJson<PartsList>(jsonFile.text);
    }

    void Update()
    {
        language = Drdown.GetComponent<Dropdown>().value;
    }


    // Sets each text filed with the correct name
    public string SetPartsTexts(string partName)
    {
        switch (partName.ToLower().Replace(" ", "_"))
        {
            case "sclera":
                return NewPartList.parts[language].sclera;
            case "choroid":
                return NewPartList.parts[language].choroid;
            case "retina":
                return NewPartList.parts[language].retina;
            case "cornea":
                return NewPartList.parts[language].cornea;
            case "iris":
                return NewPartList.parts[language].iris;
            case "lens":
                return NewPartList.parts[language].lens;
            case "ciliary_body":
                return NewPartList.parts[language].ciliary_body;
            case "vitreous_humor":
                return NewPartList.parts[language].vitreous_humor;
            case "optic_nerver":
                return NewPartList.parts[language].optic_nerver;
            case "macula":
                return NewPartList.parts[language].macula;
            case "anterior_pole":
                return NewPartList.parts[language].anterior_pole;
            case "endotheel":
                return NewPartList.parts[language].endotheel;
            case "descemets_layer":
                return NewPartList.parts[language].descemets_layer;
            case "stroma":
                return NewPartList.parts[language].stroma;
            case "bowmans_layer":
                return NewPartList.parts[language].bowmans_layer;
            case "epitheel":
                return NewPartList.parts[language].epitheel;
            case "anterior_segment":
                return NewPartList.parts[language].anterior_segment;
            case "fovea_centralis":
                return NewPartList.parts[language].fovea_centralis;
            case "ora_serrata":
                return NewPartList.parts[language].ora_seratta;
            case "veins":
                return NewPartList.parts[language].veins;
            case "conjunctiva":
                return NewPartList.parts[language].conjunctiva;
            default:
                if (language != 0)
                {
                    return partName;
                }
                else
                {
                    return "";
                }
                
        }
        //TextFields[0].text = NewPartList.parts[lang].sclera;
        //TextFields[1].text = NewPartList.parts[lang].choroid;
        //TextFields[2].text = NewPartList.parts[lang].retina;
        //TextFields[3].text = NewPartList.parts[lang].cornea;
        //TextFields[4].text = NewPartList.parts[lang].aqueous_humor;
        //TextFields[5].text = NewPartList.parts[lang].pupil;
        //TextFields[6].text = NewPartList.parts[lang].iris;
        //TextFields[7].text = NewPartList.parts[lang].lens;
        //TextFields[8].text = NewPartList.parts[lang].suspensory_ligament;
        //TextFields[9].text = NewPartList.parts[lang].ciliary_body;
        //TextFields[10].text = NewPartList.parts[lang].vitreous_humour;
        //TextFields[11].text = NewPartList.parts[lang].optic_nerver;
        //TextFields[12].text = NewPartList.parts[lang].macula;
    }
}

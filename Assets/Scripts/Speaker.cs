using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "NewSpeaker", menuName = "New Speaker")]
public class Speaker : ScriptableObject
{
    public string speakerName;
    public Texture speakerIcon;
}

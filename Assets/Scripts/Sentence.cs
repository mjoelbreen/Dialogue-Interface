using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "Sentence 0", menuName = "Sentence")]
public class Sentence : ScriptableObject
{
    public Speaker speaker;
    [TextArea(3, 3)] public string sentence;
}
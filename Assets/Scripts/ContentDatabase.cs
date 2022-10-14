using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//База данных для интерфейса

[CreateAssetMenu(fileName = "Content Database", menuName = "Content Database")]
public class ContentDatabase : ScriptableObject
{
    public string nameOfThedatabase;

    [Space]
    [Header("Custom button")]
    public GameObject ui_button_for_database;

    [Space]
    [Header("Last pick that player did")]
    public int lastPick;

    [Space]
    [Header("All ot the content for database")]
    public ContentSettings[] content;
}

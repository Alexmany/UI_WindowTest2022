using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������� �������� ��� ����������

[CreateAssetMenu(fileName = "Content Settings", menuName = "Content Settings")]
public class ContentSettings : ScriptableObject
{
    public string nameOfTheContent;

    [Space]
    public Sprite icon;
    public GameObject obectsToShow;
}

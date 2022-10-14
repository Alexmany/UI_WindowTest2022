using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Кнопка для базыданных

public class ContentButton : MonoBehaviour
{
    public WindowContentManager wcm;

    [Space]
    public Image icon;
    public Image checkmark;
    public Image border;
    
    [Space]    
    public int contentIndex;

    public void _selectTheContent()
    {
        wcm.PreviewNewContent(contentIndex);
    }    
}

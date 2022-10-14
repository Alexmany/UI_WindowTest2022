using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowContentManager : MonoBehaviour
{
    [Space]
    [Header("Interface stuff")]
    public GameObject[] _currentModelToPreview;    
    public Transform[] _previewSpawnPoint;    

    [Space]
    [Header("Interface stuff")]
    public Transform contentHolder;
    public TMP_Text _nameofTheContent_ui;
    public TMP_Text _nameofTheDateBase_ui;
    public GameObject[] categoryButtons;

    [Space]
    [Header("Databases too for with")]
    public ContentDatabase[] Content_Databases;

    [Space]
    [Header("Current database")]
    public bool isContentLoaded;
    public int currentIndexOfDatabase;
    public int currentContentIndex;
    public ContentDatabase currentDatabase;
    public GameObject[] currentDataBasesPrefabs;    

    //Погнали c хака
    void Start()
    {
        LoadNewDatabase(0);
        HackyWacky();
    }

    //I FORGOT
    void HackyWacky()
    {
        var go = Instantiate(Content_Databases[1].content[Content_Databases[1].lastPick].obectsToShow, _previewSpawnPoint[1]);

        _currentModelToPreview[1] = go;
    }

    //Загружаем новую базуданных
    public void LoadNewDatabase(int id)
    {
        if (isContentLoaded)
        {
            ClearUi();
        }

        currentDatabase = Content_Databases[id];

        currentDataBasesPrefabs = new GameObject[currentDatabase.content.Length];
        _nameofTheDateBase_ui.text = currentDatabase.nameOfThedatabase;

        currentIndexOfDatabase = id;

        for (int i = 0; i < currentDataBasesPrefabs.Length; i++)
        {
            var go = Instantiate(currentDatabase.ui_button_for_database, contentHolder);

            go.GetComponent<ContentButton>().wcm = this;
            go.GetComponent<ContentButton>().icon.sprite = currentDatabase.content[i].icon;
            go.GetComponent<ContentButton>().contentIndex = i;
            go.GetComponent<ContentButton>().checkmark.enabled = false;

            if(i == currentDatabase.lastPick)
                go.GetComponent<ContentButton>().checkmark.enabled = true;

            currentDataBasesPrefabs[i] = go;            
        }

        currentContentIndex = currentDatabase.lastPick;

        PreviewNewContent(currentDatabase.lastPick);

        WorkOnCategoryBuutons(id);

        if (!isContentLoaded)
            isContentLoaded = true;
    }

    //Очищаем контент для нового
    void ClearUi()
    {
        for (int i = 0; i < currentDataBasesPrefabs.Length; i++)
        {
            Destroy(currentDataBasesPrefabs[i]);            
        }

        currentDatabase = null;
    }

    //Нажимаем и показываем контент игроку
    public void PreviewNewContent(int i)
    {
        _nameofTheContent_ui.text = currentDatabase.content[i].nameOfTheContent;

        if (currentContentIndex == i && isContentLoaded) return;

        if (_currentModelToPreview[currentIndexOfDatabase] != null)
        {
            Destroy(_currentModelToPreview[currentIndexOfDatabase]);
        }            

        var go = Instantiate(currentDatabase.content[i].obectsToShow, _previewSpawnPoint[currentIndexOfDatabase]);

        _currentModelToPreview[currentIndexOfDatabase] = go;                

        currentContentIndex = i;

        ResetBorder(i);
    }

    //Выбираем нужный нам контент
    public void _selectContent()
    {
        currentDatabase.lastPick = currentContentIndex;

        for (int i = 0; i < currentDataBasesPrefabs.Length; i++)
        {
            currentDataBasesPrefabs[i].GetComponent<ContentButton>().checkmark.enabled = false;
        }

        currentDataBasesPrefabs[currentContentIndex].GetComponent<ContentButton>().checkmark.enabled = true;
    }

    //Сбрасываем и ставим новую границу
    void ResetBorder(int b)
    {
        for (int i = 0; i < currentDataBasesPrefabs.Length; i++)
        {
            currentDataBasesPrefabs[i].GetComponent<ContentButton>().border.enabled = false;           
        }

        currentDataBasesPrefabs[b].GetComponent<ContentButton>().border.enabled = true;
    }

    void WorkOnCategoryBuutons(int n)
    {
        for (int i = 0; i < categoryButtons.Length; i++)
        {
            categoryButtons[i].transform.Find("checkMark").gameObject.SetActive(false);
        }

        categoryButtons[n].transform.Find("checkMark").gameObject.SetActive(true);
    }
}

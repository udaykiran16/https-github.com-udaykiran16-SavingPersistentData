using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;



public class Game : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();

    public Save save;
    [SerializeField]
    private Text hitsText;
    [SerializeField]
    private Text shotsText;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject[] targets;
    private bool isPaused = false;

    private void Awake()
    {
        Pause();
    }


    public string dataPath;
    
    void Start()
    {
        dataPath = Path.Combine(Application.dataPath, "items.txt");
        Cursor.lockState = CursorLockMode.Confined;
       // save.hits =LoadCharacter(dataPath);
        //  save.shots = Loadcharacter(dataPath);
       
        shotsText.text = save.shots.ToString();
        hitsText.text = save.hits.ToString();
     
     }

  

    public void Pause()
    {
        menu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause()
    {
        menu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        isPaused = false;
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
        SaveCharacter(save.hits, dataPath);
        SaveCharacter(save.shots, dataPath);
    }

    static void SaveCharacter(int a, string path)
    {
        string jsonString = JsonUtility.ToJson(a);

        using (StreamWriter streamWriter = File.CreateText(path))
        {
            streamWriter.Write(jsonString);
        }
    }

    static Save LoadCharacter(string path)
    {
        using (StreamReader streamReader = File.OpenText(path))
        {
            string jsonString = streamReader.ReadToEnd();
            return JsonUtility.FromJson<Save>(jsonString);
        }
    }
   




    public void AddShot()
    {
        save.shots++;
        shotsText.text = "Shots: " + save.shots;
    }

    public void AddHit()
    {
        save.hits++;
        hitsText.text = "Hits: " + save.hits;
    }


  
}







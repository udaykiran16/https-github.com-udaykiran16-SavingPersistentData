
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System.IO;


public class Game : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();
    public int shots;
    public int hits;

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

    void Save()
    {
        //creating json object
        JSONObject playerJson = new JSONObject();
        playerJson.Add(shots);
        playerJson.Add(hits);
        //save json to computer
        string path = Application.persistentDataPath + "/PlayerSave.json";
        File.WriteAllText(path,playerJson.ToString());
    }

    void Load()
    {
        //reading from the same path
        string path = Application.persistentDataPath + "/PlayerSave.json";
        string jsonString = File.ReadAllText(path);
        //set values
        JSONObject playerJson = (JSONObject)JSON.Parse(jsonString);
        hits = PlayerPrefs.GetInt("hits", 0);
        shots = PlayerPrefs.GetInt("shots", 0);
        shotsText.text = shots.ToString();
        hitsText.text = hits.ToString();


    }

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
            
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
    }



    public void AddShot()
    {

        shots = PlayerPrefs.GetInt("shots", 0);
        shots += 1;
        PlayerPrefs.SetInt("shots", shots);
        shotsText.text = shots.ToString();
    }

    public void AddHit()
    {
        hits = PlayerPrefs.GetInt("hits", 0);
        hits += 1;
        PlayerPrefs.SetInt("hits", hits);
        hitsText.text = hits.ToString();
    }

    public void DeleteScores()
    {
        PlayerPrefs.DeleteAll();
    }



}

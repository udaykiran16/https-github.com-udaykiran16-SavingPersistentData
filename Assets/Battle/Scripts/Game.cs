using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;



public class Game : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();

    [SerializeField]
    private int shots;

    [SerializeField]
    private int hits;

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

    
    void Start()
    {
 
        Cursor.lockState = CursorLockMode.Confined;
        if(PlayerPrefs.HasKey(GameSettings.PLAYER_STATS_PP) == false)
        {
            InitializePlayerStats();
        }
        else
        {        //Now lets get our player prefs saves. We know that it has been initialized so we can get it from the player prefs.
            JSONNode PlayerStats = JSON.Parse(PlayerPrefs.GetString(GameSettings.PLAYER_STATS_PP));
            // Get the shots saved
            shots = PlayerStats["PlayerStats"]["shots"].AsInt;
            // Get the hits saved
            hits = PlayerStats["PlayerStats"]["hits"].AsInt;
            // Display shots and hits text to UI
            shotsText.text = shots.ToString();
            hitsText.text = hits.ToString();

        }
     
     }

  public void InitializePlayerStats()
    {
        // create a new JSON
        JSONNode initializePlayerStatsDataJSON = JSON.Parse("{}");

        initializePlayerStatsDataJSON["PlayerStats"]["shots"].AsInt = 0;
        initializePlayerStatsDataJSON["PlayerStats"]["hits"].AsInt = 0;

        //Now lets save it
        PlayerPrefs.SetString(GameSettings.PLAYER_STATS_PP, initializePlayerStatsDataJSON.ToJSON(1));
        PlayerPrefs.Save();

        //Lets debug it to be sure
        Debug.Log("Initialized Player data: " + PlayerPrefs.GetString(GameSettings.PLAYER_STATS_PP));
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
        //Now lets get our player prefs saves. We know that it has been initialized so we can get it from the player prefs.
        JSONNode PlayerStats = JSON.Parse(PlayerPrefs.GetString(GameSettings.PLAYER_STATS_PP));

        // Get the shots saved

        shots = PlayerStats["PlayerStats"]["shots"].AsInt;
        // Additon of shots
        shots += 1;

        //Now lets save it
        PlayerStats["PlayerStats"]["shots"].AsInt = shots;
        PlayerPrefs.SetString(GameSettings.PLAYER_STATS_PP, PlayerStats.ToJSON(1));
        PlayerPrefs.Save();

        // Display shots text to UI
        shotsText.text = shots.ToString();
    }

    public void AddHit()
    {
        //Now lets get our player prefs saves. We know that it has been initialized so we can get it from the player prefs.
        JSONNode PlayerStats = JSON.Parse(PlayerPrefs.GetString(GameSettings.PLAYER_STATS_PP));

        // Get the hits saved

        hits = PlayerStats["PlayerStats"]["hits"].AsInt;
        // Additon of shots
        hits += 1;

        //Now lets save it
        PlayerStats["PlayerStats"]["hits"].AsInt = hits;
        PlayerPrefs.SetString(GameSettings.PLAYER_STATS_PP, PlayerStats.ToJSON(1));
        PlayerPrefs.Save();

        // Display shots text to UI
        hitsText.text = hits.ToString();
    }


  
}







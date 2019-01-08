using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class jsonfile : MonoBehaviour
{
    public class16 player = new class16();
    JsonData playerjson;
    // Start is called before the first frame update
    void Start()
    {
        playerjson = JsonMapper.ToJson(player);
        Debug.Log(playerjson);
        File.WriteAllText(Application.dataPath + "/Player.json",playerjson.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class class16
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

    public class16()
    {
        Cursor.lockState = CursorLockMode.Confined;
        hits = PlayerPrefs.GetInt("hits", 0);
        shots = PlayerPrefs.GetInt("shots", 0);
        shotsText.text = shots.ToString();
        hitsText.text = hits.ToString(); 
    }


}

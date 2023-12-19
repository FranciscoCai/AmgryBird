using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}
public class MissionDemolition : MonoBehaviour
{
    static public MissionDemolition S;
    public Text uitLevel;
    public Text uitShots;
    public Text uitButton;
    public Vector3 castlePos;
    public GameObject[] castles;

    public int level;
    public int levelmax;
    public int shotsTaken;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";

    void Start()
    {
        S = this;
        level =0;
        levelmax = castles.Length;
        StartLevel();
    }
    private void StartLevel()
    {
        if(castle != null)
        {
            Destroy(castle);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject pTemp in gos) 
        {
            Destroy(pTemp);
        }
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;
        SwitchView("Show Both");
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }
    private void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level +1) + "of "+ levelmax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();
        if((mode == GameMode.playing) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            SwitchView("Show Both");
            Invoke("NextLevel", 2f);
        }
    }
    private void NextLevel()
    {
        level++;
        if(level == levelmax)
        {
            level = 0;
        }
        StartLevel();
    }
    public void SwitchView(string eView = "")
    {
        if(eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;
        switch(showing)
        {
            case "Show Slingshot":
                Camara.POI = null;
                uitButton.text = "Show Castle";
                break;
            case "Show Castle":
                Camara.POI = S.castle;
                uitButton.text = "Show Both";
                break;
            case "Show Both":
                Camara.POI = GameObject.Find("viewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }
    public static void ShotFired()
    {
        S.shotsTaken++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets;
using TMPro;

public class Welcom : MonoBehaviour
{
    // public winMission mission;

    public GameObject panel_Menu;
    public GameObject Panel_seLecMap;

    public GameObject Panel_Level_Easy;
    public GameObject Panel_Level_Easy2;
    public GameObject Panel_Level_Normal;
    public GameObject Panel_Level_Normal2;

    public GameObject panel_Report;

    private AudioSource audioS;
    public AudioClip welcom, click;
    public AudioSource audioClik;

    public Image Sound;
    public Sprite on, off;

    public string Scencename;
    GameObject ggadmob;
   

    private int missionID = 40;
    private int n = 1;
    public bool check;

    void Awake()
    {
#if UNITY_ANDROID
        Application.targetFrameRate = 60;
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
       
        if (ggadmob == null)
        {
            ggadmob = GameObject.FindGameObjectWithTag("ggAdmob");
        }
        audioS = GetComponent<AudioSource>();

        audioS.clip = welcom;
        audioS.Play();


        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }


        PlayerPrefs.SetInt("SUMDIAMON", 999999);

        PlayerPrefs.SetInt("LastMission", missionID);

        if (PlayerPrefs.GetInt("SELECTED") == 0)
        {
            PlayerPrefs.SetInt("selectOption", n);

        }

        //if (j < 100)
        //{
        //    j += 1;
        //    cc.text = j.ToString();
        //}
        //else
        //{
        //    j += 0;
        //    cc.text = j.ToString();
        //}
    }

 
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (check)
            {
                SceneManager.LoadScene(Scencename);
                check = false;

            }
            else
            {
                Application.Quit();
            }
        }
    
    }
    public void Open(int ScenID)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(ScenID);

        audioClik.clip = click;
        audioClik.Play();

      
    }

    public void ChoosePlay()
    {

        // Panel_seLecMap.SetActive(true);
        panel_Menu.SetActive(true);
        check = true;

        audioClik.clip = click;
        audioClik.Play();

        audioS.volume = 0.3f;

      

     
    }
   

    public void Easy()
    {
        Panel_Level_Easy.SetActive(true);
        Panel_seLecMap.SetActive(false);

        audioClik.clip = click;
        audioClik.Play();
    }

    public void Normal()
    {
        //if (GameSetting.GetLastMission >= 20)
        //{
        //    Panel_Level_Normal.SetActive(true);
        //    Panel_seLecMap.SetActive(false);

        //}
        //else
        //{
        //    panel_Report.SetActive(true);
        //}
        Panel_Level_Normal.SetActive(true);
        Panel_Level_Normal2.SetActive(false);
        audioClik.clip = click;
        audioClik.Play();

    }
    public void Next()
    {
        Panel_Level_Easy2.SetActive(true);
        Panel_Level_Easy.SetActive(false);

        audioClik.clip = click;
        audioClik.Play();
    }

    public void Back()
    {
        Panel_Level_Easy2.SetActive(false);
        Panel_Level_Easy.SetActive(true);

        audioClik.clip = click;
        audioClik.Play();
    }

    public void Next2()
    {
        Panel_Level_Normal2.SetActive(true);
        Panel_Level_Easy2.SetActive(false);

        audioClik.clip = click;
        audioClik.Play();
    }

    public void Back2()
    {
        Panel_Level_Normal2.SetActive(false);
        Panel_Level_Easy2.SetActive(true);

        audioClik.clip = click;
        audioClik.Play();
    }

    public void Back3()
    {
        Panel_Level_Normal2.SetActive(true);
        Panel_Level_Normal.SetActive(false);

        audioClik.clip = click;
        audioClik.Play();
    }

    public bool muted = false;
    public void Music()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        // muted = !muted;
        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (muted == false )
        {
            Sound.sprite = on;
        }
        else
        {
            Sound.sprite = off;
        }

    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    public void Thoat()
    {
        // SceneManager.LoadScene(Scencename);
        panel_Menu.SetActive(false);
        audioClik.clip = click;
        audioClik.Play();
        audioS.volume = 1f;
    }
    public void Danh_Gia()
    {
        Application.OpenURL(Application.identifier);
    }

}


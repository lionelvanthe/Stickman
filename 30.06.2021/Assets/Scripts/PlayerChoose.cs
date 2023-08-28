using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets;
public class PlayerChoose : MonoBehaviour
{
    // public ggAdmos gg;                      //quangcao
    public MoveAni _player1, _player2;
    //  public ListCongTac check_1, check_2;

    public GameObject Panel_Win;

    public GameObject PausePanel;
    public winMission winmission;
    public FollowCamera flCam;

    public Color clRed, clBlue;
    public Image imBg, jumpBtn_Hight, jumpBtn_Low, leftBtn_high, leftBtn_low, rightBtn_hight, rightBtn_low, swap1, swap2;
    // private Color RGBColor;

    public string Map2;
    public string welcomHome;

    public int missionId;

    private AudioSource audioSource;
    //  public AudioSource audio_win;
    public AudioClip easy, normal;

    public bool choose_Player = false;



    // Start is called before the first frame update
    void Start()
    {
        imBg.color = clBlue;
        audioSource = GetComponent<AudioSource>();
        if (missionId <= 21)
        {
            audioSource.clip = easy;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = normal;
            audioSource.Play();
        }

        if (!PlayerPrefs.HasKey("choose_Player"))
        {
            PlayerPrefs.SetInt("choose_Player", 0);
            Load();

        }
        else
        {
            Load();
        }
        updateswap();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _player1.Opening = true;
            _player2.Opening = true;

        }
        SwapKey();
        HandPause();
        StartCoroutine(NexMapp2xx());
    }

    public void Load()
    {
        choose_Player = PlayerPrefs.GetInt("choose_Player") == 1;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("choose_Player", choose_Player ? 1 : 0);
    }

    public void ClickSwap()
    {
        if (_player1.die || _player2.die) return;
        if (choose_Player == false)
        {
            choose_Player = true;
            _player1.StopMoving();
        }
        else
        {
            choose_Player = false;
            _player2.StopMoving();
        }
        Save();
        updateswap();
     //  flCam.hyo = false;
        flCam.First_touch = false;
    }

    private void updateswap()
    {
        if (choose_Player == false)
        {
            _player1.choose = true;
            _player2.choose = false;
            // swap1.enabled = true;
            // swap2.enabled = false;
            imBg.color = clBlue;

            // _player2.StopMoving();
            flCam.Check = true;    //check camera
        }
        else
        {
            _player1.choose = false;
            _player2.choose = true;
            // swap2.enabled = true;
            // swap1.enabled = false;
            imBg.color = clRed;

            //_player1.StopMoving();
            flCam.Check = false;    //check camera
        }
    }

    private void SwapKey()      ////click key
    {
        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (choose_Player == false)
            {
                choose_Player = true;
                _player1.StopMoving();

                flCam.First_touch = false;
            }
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (choose_Player)
            {
                choose_Player = false;
                _player2.StopMoving();

                flCam.First_touch = false;
            }
        }
        Save();
        updateswap();
    }

    public void home()
    {
        SceneManager.LoadScene(welcomHome);
        Time.timeScale = 1;
        // AdsManager.Instance.traped = false;
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;

        flCam.hyo = false;
    }

    public void HandPause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resum()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    public void Reset(int sceneID)
    {
      //  Debug.LogWarning("Reset--------- " + (AdsManager.Instance == null ? "NULL" : "Eo NULL"));
        //AdsManager.Instance.ShowInters((b) =>
        //{
        //    if (b)
        //    {
        //        Debug.LogError("Reset");
        //        Time.timeScale = 1;
        //        SceneManager.LoadScene(sceneID);
        //    }
        //});
        AdsManager.Instance.ShowInters();

       // Debug.LogError("Reset");
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneID);
    }

    IEnumerator NexMapp2xx()
    {

        if (_player1.Opening && _player2.Opening)
        {
            _player1.win = true;
            _player2.win = true;

            _player1.PlayAninmation(_player1.Win);
            _player2.PlayAninmation(_player2.Win);
            flCam.hyo = false;

            yield return new WaitForSeconds(1.5f);

            Panel_Win.SetActive(true);
            // gg.GameOver();

            winmission.UnlockNextMission(missionId);        //UnlockMap

        }

    }

    public void Nextmap()
    {
        //AdsManager.Instance.ShowInters((b) =>
        //{
        //    if (b)
        //    {
        //        Debug.LogError("Nextmap");
        //        SceneManager.LoadScene(Map2);
        //    }
        //});
        AdsManager.Instance.ShowInters();
      //  Debug.LogError("Nextmap");
        SceneManager.LoadScene(Map2);
    }

    public void WatchVideo() /// ham goi quang cao 
    {
        AdsManager.Instance.ShowVideoReward((b) =>
        {
            if (b)
            {
                _player1.Revive();
                _player2.Revive();
              //  Debug.LogWarning("Revive");
            }


        });

    } 

    public void HightjumpBtn()
    {
        // RGBColor.a = 1;
        // RGBColor.r = 1;
        // RGBColor.g = 1;
        // RGBColor.b = 1;
        //jumpBtn.color = RGBColor;
        jumpBtn_Hight.enabled = true;
        jumpBtn_Low.enabled = false;

    }
    public void Low_JumpBtn()
    {
        //RGBColor.a = 0.3f;
        //RGBColor.r = 1;
        //RGBColor.g = 1;
        //RGBColor.b = 1;
        //jumpBtn.color = RGBColor;
        jumpBtn_Hight.enabled = false;
        jumpBtn_Low.enabled = true;
    }

    public void Hight_Leftbtn()
    {
        // RGBColor.a = 1;
        // RGBColor.r = 1;
        // RGBColor.g = 1;
        // RGBColor.b = 1;
        //leftBtn.color = RGBColor;
        leftBtn_high.enabled = true;
        leftBtn_low.enabled = false;
    }
    public void Low_LeftBtn()
    {
        //RGBColor.a = 0.3f;
        //RGBColor.r = 1;
        //RGBColor.g = 1;
        //RGBColor.b = 1;
        //leftBtn.color = RGBColor;
        leftBtn_high.enabled = false;
        leftBtn_low.enabled = true;
    }
    public void HightRightBtn()
    {
        // RGBColor.a = 1;
        // RGBColor.r = 1;
        // RGBColor.g = 1;
        // RGBColor.b = 1;
        //rightBtn.color = RGBColor;
        rightBtn_hight.enabled = true;
        rightBtn_low.enabled = false;
    }
    public void LowRightBtn()
    {
        // RGBColor.a = 0.3f;
        // RGBColor.r = 1;
        // RGBColor.g = 1;
        // RGBColor.b = 1;
        //rightBtn.color = RGBColor;
        rightBtn_hight.enabled = false;
        rightBtn_low.enabled = true;
    }
}








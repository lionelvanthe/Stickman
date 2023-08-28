using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Run_time : MonoBehaviour
{
    public float current_time;
    public Text Seconds, minutes;
    public int late;
    public GameObject player1, player2;
    public GameObject Panel_gameOver, Watch_overTime, gameover;
    public MoveAni pl1, pl2;
    public Vector2 V_pl1, V_pl2;
    private bool Over_Time = false;
    private void Start()
    {
        Seconds.text = current_time.ToString();
        minutes.text = "0" + late.ToString() + ":";

        V_pl1 = player1.transform.position;

        V_pl2 = player2.transform.position;

       
    }
    //private void OnDisable()
    //{

    //    if (AdsManager.Instance != null)
    //    {
    //        AdsManager.Instance.acVideo_timeUp -= TimeUp;
    //        Debug.Log("turn off TimeUp");
    //    }
    //}                              

    // Update is called once per frame
    void Update()
    {
        if (!Over_Time && (player1.GetComponent<Rigidbody2D>().position.x != V_pl1.x || player2.GetComponent<Rigidbody2D>().position.x != V_pl2.x))
        {
            current_time -= Time.deltaTime;
            if (current_time < 10)
            {


                Seconds.text = "0" + current_time.ToString();

            }
            else
            {
                Seconds.text = current_time.ToString();
            }


            if (current_time < 0.1f)
            {
                late--;
                minutes.text = "0" + late.ToString() + ":";
                current_time = 60;
            }
        }
        if (pl1.Opening && pl2.Opening)
        {
            Over_Time = true;
        }
        EndTime();
    }

    void EndTime()
    {
        if (late == 0f && current_time < 1 )
        {
            Over_Time = true;
          Panel_gameOver.SetActive(true);
         
        }
    }

    public void WatachVideo()
    {
        AdsManager.Instance.ShowVideoReward((b) =>
        {
            if (b)
            {
                TimeUp();
                Debug.LogWarning("TimeUp");
            }
        });
    }

    private void TimeUp()
    {
        Panel_gameOver.SetActive(false);      
        current_time = 20f;
        Over_Time = false;
       // OnDisable();
    }

    public void Close_Video()
    { 
            Watch_overTime.SetActive(false);
            gameover.SetActive(true);       
       // Watch_gameover.SetActive(true);
    }
}

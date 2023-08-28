using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using UnityEngine.UI;
using TMPro;
public class Huong_dan : MonoBehaviour
{
    public GameObject tutorial;
    public MoveAni player_1, player_2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSetting.GetLastMission < 2)
        {
            if (player_1.Opening || player_2.Opening)
            {
                tutorial.SetActive(true);
            }

            //  winmission.UnlockNextMission(missionId);
        }
    }

    public void Tutorial_off()
    {
        tutorial.GetComponentInChildren<Image>().enabled = false;
        tutorial.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
        Destroy(this);
    }
}

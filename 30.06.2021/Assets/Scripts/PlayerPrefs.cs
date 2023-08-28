using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerPrefst : MonoBehaviour
{
    public List<GameObject> MissionImage;
    public List<GameObject> MissionLockImage;
    public List<Button> MissionsButtons;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("LastMission", 0).ToString();

        for (int i = 0; i < MissionImage.Count; i++)
        {
            if (PlayerPrefs.GetInt("LastMission", 0) >= (i + 2))
            {
                MissionImage[i].SetActive(true);
                MissionLockImage[i].SetActive(false);
                MissionsButtons[i].interactable = true;
            }
            else
            {
                MissionImage[i].SetActive(false);
                MissionLockImage[i].SetActive(true);
                MissionsButtons[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Delde();
    }

    public static void SetLasMission(int value)
    {
        PlayerPrefs.SetInt("LastMission", value);
    }

    public void UnlockNextMission(int missionID)
    {
        if (missionID > PlayerPrefs.GetInt("LasttMission", 0))
        {
            SetLasMission(missionID);
        }
    }

    public void Delde()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}

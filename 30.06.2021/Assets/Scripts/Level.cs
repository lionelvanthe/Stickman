using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{ 

    public List<GameObject> MissionImage;
    public List<GameObject> MissionLockImage;
    public List<Button> MissionsButtons;
    // Start is called before the first frame update
    void Start()
    {
        int lastMission = GameSetting.GetLastMission;
        for (int i = 0; i < MissionImage.Count; i++)
        {
            if (lastMission >= (i + 2))
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
    private void Update()
    {
        Delde();
    }
    public void LoadMission(string missionName)
    {
        StartCoroutine(LoadMissionAsync(missionName));
        Time.timeScale = 1;
    }

    private IEnumerator LoadMissionAsync(string missionName)
    {
        var operation = SceneManager.LoadSceneAsync(missionName);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            yield return null;

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
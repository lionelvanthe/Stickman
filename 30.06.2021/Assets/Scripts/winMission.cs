using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winMission : MonoBehaviour
{
    public void UnlockNextMission(int missionId)
    {
        if (missionId > Assets.GameSetting.GetLastMission)
        {
            Assets.GameSetting.SetLastMission(missionId);
        }
    }
}

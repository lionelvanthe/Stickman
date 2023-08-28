using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
   public class GameSetting: MonoBehaviour
    {
    public static int GetLastMission{ get { return PlayerPrefs.GetInt("LastMission" ,0); } }

        public static void SetLastMission(int value)
        {
            PlayerPrefs.SetInt("LastMission", value);
        }
    }
}

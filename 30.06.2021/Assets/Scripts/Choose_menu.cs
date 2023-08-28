using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets;
using TMPro;
public class Choose_menu : MonoBehaviour
{
    public GameObject Panel_Skin;

    public GameObject Premium, Rescue;

    public Image Premium_high, Premium_low, Rescue_high, Rescue_low;

    public Change_character change_1, change_2;

    public Listspine list_1, list_2;

    public Button BuySkin, Tryskin, SelectSkin, SelectedSkin;

    public List<GameObject> change, G_Selected;

    public List<Button> image_btn;
    public List<GameObject> image_lock;

    private AudioSource audioS;

    public AudioClip click;

    public int n;
   
    public ListSkin[] list;
  

    public TextMeshProUGUI Diamon_Money;

    // Start is called before the first frame update
    void Start()
    {
        int lastMission = GameSetting.GetLastMission;
        int updateDiamon = PlayerPrefs.GetInt("SUMDIAMON", 0);

        j = updateDiamon;
        Diamon_Money.text = j.ToString();
        audioS = GetComponent<AudioSource>();


        n = PlayerPrefs.GetInt("Select", 0);

        s = n; 
        if (!PlayerPrefs.HasKey("SELECTED"))     // luu bien boo selected voi dieu kien s=n
        {
            PlayerPrefs.SetInt("SELECTED", 0);
            Load_selected();
        }
        else
        {
            ListSkin mod = list[n];
            change_1.List_skin = mod.index;
            change_2.List_skin = mod.index;
            Load_selected();
        }
        UpdateSelect();

        foreach (ListSkin l in list) 
        {
            if (l.Dimon == 0)
            {
                l.Bought = true;
            }
            else
            {
                l.Bought = PlayerPrefs.GetInt(l.name, 0) == 0 ? false : true;  // luu skin da mua
            }
        }

        for (int n = 0; n < image_lock.Count; n++) //// mo khoa tung skin
        {
            ListSkin l = list[n];
            if (l.Bought == true)
            {
                image_btn[n].image.enabled = true;
                image_lock[n].SetActive(false);
            }
        }
       
    }
    //private void OnDisable()
    //{
    //    if (AdsManager.Instance != null)
    //    {
    //        AdsManager.Instance.acVideo_Donate -= Donated;
    //        Debug.Log("turn off donate");
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < change.Count; i++) // doi mau` obj skin dc click vao`
        {
            if (n == i)
            {
                change[i].SetActive(true);

            }
            else
            {
                change[i].SetActive(false);

            }

        }
        if (!PlayerPrefs.HasKey("SELECTED"))     // luu bien boo selected voi dieu kien s=n
        {
            PlayerPrefs.SetInt("SELECTED", 0);
            Load_selected();
        }
        else
        {
            ListSkin mod = list[n];
            change_1.List_skin = mod.index;
            change_2.List_skin = mod.index;
            Load_selected();
        }
       
      
        //  UpdateSelect();

        UpdateUi();
      //  UpdateSelect();
        if (Input.GetKey(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }
        
    }
    public int j;
    private void FixedUpdate()
    {
        if (j < PlayerPrefs.GetInt("SUMDIAMON", 0))
        {
            j++;
            if (j >= 10)
            {
                Diamon_Money.text = j.ToString();

                //if (Diamon_Money.text.Length >= 4)
                //{
                //    Diamon_Money.fontSize = 50;
                //}
            }
            else
            {
                Diamon_Money.text = "0" + j.ToString();
            }
        }
        else if (j == PlayerPrefs.GetInt("SUMDIAMON", 0))
        {

            Diamon_Money.text = j.ToString();
            //if (Diamon_Money.text.Length >= 4)
            //{
            //    Diamon_Money.fontSize = 50;
            //}
        }

    }
    public void Skin()      
    {
        Panel_Skin.SetActive(true);
      //  n = 0;
    }

    public void Close_skin()
    {
        Panel_Skin.SetActive(false);

    }

    public void Unlock_Premium()
    {
      
        Premium.SetActive(true);
        Rescue.SetActive(false);
        Premium_high.enabled = true;
        Rescue_high.enabled = false;
        Rescue_low.enabled = true;
        change_1.List_skin = 2;
        change_2.List_skin = 2;
        n = 0;
        audioS.clip = click;
        audioS.Play();
        switch (n)
        {
            default:
                BuySkin.interactable = true;
                // Tryskin.interactable = true;
                break;
        }
    }

    public void Unlock_Resuce()
    {
      
        Premium.SetActive(false);
        Rescue.SetActive(true);

        Rescue_high.enabled = true;
        Premium_high.enabled = false;
        Premium_low.enabled = true;

        change_1.List_skin = 17;
        change_2.List_skin = 17;

        audioS.clip = click;
        audioS.Play();

        n = 14;
        switch (n)
        {
            case 14:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
                {
                    BuySkin.interactable = false;
                    // Tryskin.interactable = false;

                    break;
                }

        }
    }

    public void Enter_skin(int a) // so thu tu cac skin
    {
        n = a;
        audioS.clip = click;
        audioS.Play();
        ListSkin l = list[n];
        if (l.Bought )
        {
            if (s != n)
            {
                selected = false;

            }
            if (s == n)
            {
                selected = true;
            }
        }
        else
        {
            return;
        }
     
        UpdateSelect();
    }

    public void Buy_skin()
    {
        ListSkin l = list[n];
        PlayerPrefs.SetInt(l.name, 1);
        l.Bought = true;
        int updateDimon = (PlayerPrefs.GetInt("SUMDIAMON", 0) - l.Dimon);
        Diamon_Money.text = updateDimon.ToString();
        PlayerPrefs.SetInt("SUMDIAMON", updateDimon);
    }

   
    private void UpdateUi()     //update so luong skin da dc mua 
    {
        ListSkin l = list[n];
        if (l.Bought)
        {
            BuySkin.gameObject.SetActive(false);
            Tryskin.gameObject.SetActive(false);
            SelectSkin.gameObject.SetActive(true);

            image_btn[n].image.enabled = true;
            image_lock[n].SetActive(false);

        }
        else
        {
            BuySkin.gameObject.SetActive(true);
            if (BuySkin.GetComponentInChildren<Text>().text.Length < 5)
            {
                BuySkin.GetComponentInChildren<Text>().text = "  " + l.Dimon;
            }
            if (BuySkin.GetComponentInChildren<Text>().text.Length >= 5)
            {
                BuySkin.GetComponentInChildren<Text>().text = " " + l.Dimon;
            }

            Tryskin.gameObject.SetActive(true);
            SelectSkin.gameObject.SetActive(false);
            SelectedSkin.gameObject.SetActive(false);
            image_btn[n].image.enabled = false;
            image_lock[n].SetActive(true);

            if (l.Dimon <= PlayerPrefs.GetInt("SUMDIAMON", 0) )
            {
                BuySkin.interactable = true;

            }
            else
            {
                BuySkin.interactable = false;

            }
        }
       
    }

    public int mod;
    public void Modskin(int l)
    {
        mod = l;
       
    }

    public int s ;
    public void Select() //skin dc select voi bien S
    {
        s = n;
        PlayerPrefs.SetInt("Select", s);   
        if (selected == false)
        {
            selected = true;
        }     
        UpdateSelect();
        Save_selected();
    }
    private void UpdateSelect()
    {
        
            if (selected == false)
            {
                SelectSkin.gameObject.SetActive(true);
                SelectedSkin.gameObject.SetActive(false);         
            }
            else
            {
                SelectSkin.gameObject.SetActive(false);
                SelectedSkin.gameObject.SetActive(true);           
            }
        }
    

    public bool selected = false;

    private void Load_selected()
    {
        selected = PlayerPrefs.GetInt("SELECTED") == 1;
    }

    private void Save_selected()
    {
        PlayerPrefs.SetInt("SELECTED", selected ? 1 : 0);
    }

    public void Donate_Dianon()
    {
        AdsManager.Instance.ShowVideoReward((b) =>
        {
            if (b)
            {
                Donated();
                Debug.LogWarning("Donated");
            }
        });
    }

    private void Donated()
    {
        int donate = (PlayerPrefs.GetInt("SUMDIAMON",0) + 20);
       // Diamon_Money.text = donate.ToString();
        PlayerPrefs.SetInt("SUMDIAMON", donate);
        //OnDisable();
    }

}



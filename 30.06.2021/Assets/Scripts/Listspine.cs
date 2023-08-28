using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class Listspine : MonoBehaviour
{
    public SkeletonAnimation skanim;
    [SpineSkin] public string one, two, three, four, five, six, seven, eight, nine, ten,
     eleven, twelf, thirteen,fourteen, fifteen,sixteen,seventeen,eightteen,nineteen,twentie,twenty_first, twenty_second,twenty_third,twenty_four, twenty_five;

    public GameObject Buy_skin, Try_skin, Select_skin, Selected_skin;
    public int n ;
    public bool bought;

    public GameObject panel_menu;
   
    private AudioSource audioS;
    public AudioClip clik;


    public ListSkin[] list;
    // Start is called before the first frame update
    void Start()
    {       
        audioS = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("selectOption"))
        {
            PlayerPrefs.SetInt("selectOption", 1);
            Load();
        }
        else
        {
            Load();
        }
        Choose_skin();

        if (!PlayerPrefs.HasKey("SELECTED"))
        {
            PlayerPrefs.SetInt("SELECTED", 0);
            Load_selected();
        }
        else
        {
            Load_selected();
        }
        Update_select();

      
        Btn_Skin();

        foreach (ListSkin l in list)
        {
            if (l.Dimon == 0)
            {
                l.Bought = true;
            }
            else
            {
                l.Bought = PlayerPrefs.GetInt(l.name, 0) == 0 ? false : true;
            }
        }
      
        s = n;
        if (s == n)
        {
            Selected_skin.gameObject.SetActive(true);
            Select_skin.gameObject.SetActive(false);
        }

      
    }

    //private void OnDisable()
    //{

    //    if (AdsManager.Instance != null)
    //    {
    //        AdsManager.Instance.acTryVideo -= Tried;
    //        Debug.Log("turn off Trying");
           
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        foreach (ListSkin l in list)
        {
            if (l.Dimon == 0)
            {
                l.Bought = true;
            }
            else
            {
                l.Bought = PlayerPrefs.GetInt(l.name, 0) == 0 ? false : true;
            }
        }
        Choose_skin();
       Btn_Skin();
        if (n != 1 )
        {
            bought = false;
        }
        else
        {
            bought = true;
        }

        //ListSkin a = list[n-1];
        //Debug.Log(a.index);
        //if (s == n )
        //{
        //    Selected_skin.gameObject.SetActive(true);
        //    Select_skin.gameObject.SetActive(false);
        //}

  
    }


    public static void ChangeSkin(SkeletonAnimation skAnim, string ssSkinChange)
    {
        var skeleton = skAnim.Skeleton;
        var skeletonData = skeleton.Data;
        var newSkin = new Skin ("new-skin");

        newSkin.AddSkin(skeletonData.FindSkin(ssSkinChange));

        newSkin.AddSkin(skAnim.Skeleton.Skin);
        skeleton.SetSkin(newSkin);
        skeleton.SetSlotsToSetupPose();
        skAnim.AnimationState.Apply(skeleton);
    }

    public void Choose_skin()
    {
        switch (n)
        {
            case 1:
                ChangeSkin(skanim, one);             
                break;
            case 2:
                ChangeSkin(skanim, two);
                break;
            case 3:
                ChangeSkin(skanim, three);
                break;
            case 4:
                ChangeSkin(skanim, four);
                break;
            case 5:
                ChangeSkin(skanim, five);              
                break;
            case 6:
                ChangeSkin(skanim, six);
                break;
            case 7:
                ChangeSkin(skanim, seven);
                break;
            case 8:
                ChangeSkin(skanim, eight);
                break;
            case 9:
                ChangeSkin(skanim, nine);
                break;
            case 10:
                ChangeSkin(skanim, ten);
                break;
            case 11:
                ChangeSkin(skanim, eleven);
                break;
            case 12:
                ChangeSkin(skanim, twelf);
                break;
            case 13:
                ChangeSkin(skanim, thirteen);
                break;
            case 14:
                ChangeSkin(skanim, fourteen);
                break;
            case 15:
                ChangeSkin(skanim, fifteen);
                break;
            case 16:
                ChangeSkin(skanim, sixteen);
                break;
            case 17:
                ChangeSkin(skanim, seventeen);
                break;
            case 18:
                ChangeSkin(skanim, eightteen);
                break;
            case 19:
                ChangeSkin(skanim, nineteen);
                break;
            case 20:
                ChangeSkin(skanim, twentie);
                break;
            case 21:
                ChangeSkin(skanim, twenty_first);
                break;
            case 22:
                ChangeSkin(skanim, twenty_second);
                break;
            case 23:
                ChangeSkin(skanim, twenty_third);
                break;
            case 24:
                ChangeSkin(skanim, twenty_four);
                break;
            case 25:
                ChangeSkin(skanim, twenty_five);
                break;
          
        }

        ChangeSkin_key();
    }
    private void ChangeSkin_key()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            n += 1;
            if (n == 26)
            {
                n = 1;
            }
            audioS.clip = clik;
            audioS.Play();

            if ( s != n)
            {
                selected = false;
            }
            if ( s == n)
            {
                selected = true;
            }
            Update_select();
           // Save_selected();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (n == 1)
            {
                n = 26;

            }
            n -= 1;
            audioS.clip = clik;
            audioS.Play();

            if ( s != n)
            {
                selected = false;
            }
            if ( s == n)
            {
                selected = true;
            }
            Update_select();
           // Save_selected();
        }
    }

    public void next_Skin1()
    {

        n += 1;
        if (n == 26)
        {
            n = 1;
        }
        audioS.clip = clik;
        audioS.Play();
        //  Save();

        if (s != n)
        {
            selected = false;
        }
        if (s == n)
        {
            selected = true;
        }

        Update_select();   
    }


    public void Back_skin1()
    {
        if (n == 1)
        {
            n = 26;
          
        }
        n -= 1;
        audioS.clip = clik;
        audioS.Play();
        // Save();
        if (s != n)
        {
            selected = false;

        }
        if ( s == n)
        {
            selected = true;
        }
        Update_select();
     
    }

    private void Load()
    {
        n = PlayerPrefs.GetInt("selectOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectOption", n);
    }

    private void Btn_Skin() ///***********8888888
    {
        ListSkin l = list[n-1];
        if (!l.Bought)
        {
            Buy_skin.SetActive(true);
            Try_skin.SetActive(true);
            Select_skin.SetActive(false);
            Selected_skin.SetActive(false);
        }
        else
        {
            Buy_skin.SetActive(false);
            Try_skin.SetActive(false);
            Select_skin.SetActive(true);
        }
    }

    public void TrySkin()
    {
        audioS.clip = clik;
        audioS.Play();

        AdsManager.Instance.ShowVideoReward((b) =>
        {
            if (b)
            {
                Tried();
                Debug.LogWarning("Tried");
            }
        });


    }

    private void Tried()
    {
        s = n;
        Save();
        panel_menu.SetActive(true);
        selected = false;
        Save_selected();
       // OnDisable();
    }

    public void Buyskin()
    {
        audioS.clip = clik;
        audioS.Play();
    }

    public void Skin()
    {
        audioS.clip = clik;
        audioS.Play();
    }

    public void Shop()
    {
        audioS.clip = clik;
        audioS.Play();
    }

    public int s;

    public void seclect()
    {
        s = n;
        Save();

        if (selected == false)
        {
            selected = true;
        }
     
        Update_select();
        Save_selected();

        audioS.clip = clik;
        audioS.Play();
    }
    public void Update_select()
    {
      
        if (selected == false )
        {
            Select_skin.SetActive(true);
            Selected_skin.SetActive(false);
        }
        else
        {
            Selected_skin.SetActive(true);
            Select_skin.SetActive(false);
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
}

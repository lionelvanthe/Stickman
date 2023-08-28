using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
public class Change_character : MonoBehaviour
{
    public SkeletonGraphic Skin_anim;

    [SpineSkin]
    public string one, two, three, four, five, six, seven, eight, nine, ten,
        eleven, twelf, thirteen, fourteen, fifteen, sixteen, seventeen, eightteen, nineteen, twentie, twenty_first, twenty_second, twenty_third, twenty_four;

    public Listspine list_1, list_2;
    public bool selected;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("MODSKIN", 0);

    }

    public int List_skin;
    // Update is called once per frame
    void Update()
    {
        switch (List_skin)
        {
            case 2:
                ChangeSkin(Skin_anim, one);
              
                break;
            case 3:
                ChangeSkin(Skin_anim, two);
            
                break;
            case 4:
                ChangeSkin(Skin_anim, three);
            
                break;
            case 5:
                ChangeSkin(Skin_anim, twenty_four);

                break;
            case 6:
                ChangeSkin(Skin_anim, four);
               
                break;
            case 7:
                ChangeSkin(Skin_anim, five);
              
                break;
            case 8:
                ChangeSkin(Skin_anim, six);
               
                break;
            case 9:
                ChangeSkin(Skin_anim, seven);
             
                break;
            case 10:
                ChangeSkin(Skin_anim, eight);
              
                break;
            case 11:
                ChangeSkin(Skin_anim, nine);
               
                break;
            case 12:
                ChangeSkin(Skin_anim, ten);
              
                break;
            case 13:
                ChangeSkin(Skin_anim, eleven);
            
                break;
            case 14:
                ChangeSkin(Skin_anim, twelf);
              
                break;
            case 15:
                ChangeSkin(Skin_anim, thirteen);
               
                break;
            case 16:
                ChangeSkin(Skin_anim, fourteen);
              
                break;
            case 17:
                ChangeSkin(Skin_anim, fifteen);
              
                break;
            case 18:
                ChangeSkin(Skin_anim, sixteen);
           
                break;
            case 19:
                ChangeSkin(Skin_anim, seventeen);
            
                break;
            case 20:
                ChangeSkin(Skin_anim, eightteen);
               
                break;
            case 21:
                ChangeSkin(Skin_anim, nineteen);
               
                break;
            case 22:
                ChangeSkin(Skin_anim,twentie);
           
                break;
            case 23:
                ChangeSkin(Skin_anim, twenty_first);
               
                break;
            case 24:
                ChangeSkin(Skin_anim, twenty_second);
             
                break;
            case 25:
                ChangeSkin(Skin_anim, twenty_third);
             
                break;

        }
        Sosanh();
    }
    public static void ChangeSkin(SkeletonGraphic skAnim, string ssSkinChange)
    {
        var skeleton = skAnim.Skeleton;
        var skeletonData = skeleton.Data;
        var newSkin = new Skin("new-skin");

        newSkin.AddSkin(skeletonData.FindSkin(ssSkinChange));

        newSkin.AddSkin(skAnim.Skeleton.Skin);
        skeleton.SetSkin(newSkin);
        skeleton.SetSlotsToSetupPose();
        skAnim.AnimationState.Apply(skeleton);
    }
    public void Select_listSkin(int n)
    {
        List_skin = n;
     
    }

    public void Sosanh()
    {
        list_1.n = List_skin;
        list_2.n = List_skin;

        //list_1.selected = false;
        //list_2.selected = false;
    }

   

}


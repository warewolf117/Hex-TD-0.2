using System.Collections;
using UnityEngine;

public class DamagePopupController : MonoBehaviour
{
    private static DamagePopup popupText;
    public static GameObject[] canvases;
    

    public static void Initialize()
    {
       if (canvases == null)
       canvases = GameObject.FindGameObjectsWithTag("EnemyHP");
        if (!popupText)
        popupText = Resources.Load<DamagePopup>("Prefabs/FloatingTextParent");
    }
    
   public static void CreateFloatingText(string text, Transform location)
    {
        foreach (GameObject canvas in canvases)
        {
           // if ()
           // { 
                DamagePopup instance = Instantiate(popupText);
            instance.transform.SetParent(canvas.transform, false);
            instance.SetText(text);
           // }
        }
       
        
    }
}

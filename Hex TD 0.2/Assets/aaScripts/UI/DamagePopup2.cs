using UnityEngine;
using TMPro;

public class DamagePopup2 : MonoBehaviour
{
    public static bool gameOver;

    public static DamagePopup2 Create(Vector3 position, float damageAmount)
    {

        GameObject damagePopupTransform = DmgPopUpPooler.Instance.GetFromPool();
        damagePopupTransform.transform.position = position;
        damagePopupTransform.transform.rotation = Quaternion.identity;
        //Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopup2 damagePopup = damagePopupTransform.GetComponent<DamagePopup2>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }

    public static DamagePopup2 CreatePoison(Vector3 position, float damageAmount)
    {

        GameObject damagePopupTransform = DmgPopUpPooler.Instance.GetFromPool();
        damagePopupTransform.transform.position = position;
        damagePopupTransform.transform.rotation = Quaternion.identity;
        //Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopup2 damagePopup = damagePopupTransform.GetComponent<DamagePopup2>();
        damagePopup.SetupPoison(damageAmount);

        return damagePopup;
    }

    public static DamagePopup2 CreateLaser(Vector3 position, float damageAmount)
    {

        float f = damageAmount;
        f = Mathf.Round(f * 1.0f) * 1f;
        GameObject damagePopupTransform = DmgPopUpPooler.Instance.GetFromPool();
        damagePopupTransform.transform.position = position + Vector3.right * 1f;
        damagePopupTransform.transform.rotation = Quaternion.identity;

        //Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position + Vector3.up * 2 , Quaternion.identity);
        DamagePopup2 damagePopupL = damagePopupTransform.GetComponent<DamagePopup2>();


        damagePopupL.SetupL(f);
        return damagePopupL;


    }

    private static int sortingOrder;

    private const float DISAPPEAR_TIMER_MAX = 0.8f;

    private static int CurrentPos;

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor = new Color(1, 1, 1, 1);
    private Vector3 moveVector;
    private Vector3 Originalscale;
    private Vector3 scale;
    private float moveValue;
    float disappearSpeed;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        Originalscale = transform.localScale;
    }


    public void SetupL(float damageAmount)
    {
        Color Lasercolor = Color.magenta;
        textMesh.SetText(damageAmount.ToString());
        textMesh.faceColor = Lasercolor;
        textMesh.color = Lasercolor;
        textMesh.outlineColor = Color.red;
        disappearTimer = 0.2f;
        disappearSpeed = 8f;

        moveValue = 15f;
        moveVector = new Vector3(-0.7f, 1) * 5f;

        scale = Originalscale;
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
        textColor.a = 1;
    }

    public void Setup(float damageAmount)
    {
        Color turretcolor = Color.red;
        textMesh.SetText(damageAmount.ToString());
        textMesh.faceColor = turretcolor;
        textMesh.color = turretcolor;
        textMesh.outlineColor = Color.yellow;
        disappearTimer = DISAPPEAR_TIMER_MAX;
        disappearSpeed = 2;

        moveValue = 5f;
        float xvar = Random.Range(-0.5f, 0.5f);
        moveVector = new Vector3(xvar, 1) * 10f;

        scale = Originalscale;
        transform.localScale = Originalscale / 1.4f;
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
        textColor.a = 1;
    }
    public void SetupPoison(float damageAmount)
    {
        Color poisoncolor = new Color(0.37f, 1, 0, 1);
        textMesh.SetText(damageAmount.ToString());
        textMesh.color = poisoncolor;
        textMesh.faceColor = poisoncolor;
        textMesh.outlineColor = Color.green;
        disappearTimer = DISAPPEAR_TIMER_MAX;
        disappearSpeed = 2;

        moveValue = 5f;
        float xvar = Random.Range(-0.3f, 0.3f);
        moveVector = new Vector3(xvar, 1) * 10f;

        scale = Originalscale;
        transform.localScale = Originalscale / 3;
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
        textColor.a = 1;
    }


    private void Update()
    {
        CurrentPos = MobileCameraControlBackup.CurrentPosition;

       if (CurrentPos == 3)
        {
            textMesh.fontSize = 4f;
        }

       if (CurrentPos == 2)
        {
            textMesh.fontSize = 6f;
        }

       if (CurrentPos == 1)
        {
            textMesh.fontSize = 8f;
        }



        transform.position += (moveVector * Time.deltaTime);
        
        moveVector -= moveVector * moveValue * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f) //first half of the popup lifetime
        {
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else //second half of the popup lifetime
        {
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            transform.position += Vector3.up * 0.05f;
            
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.faceColor = new Color(textMesh.faceColor.r, textMesh.faceColor.g, textMesh.faceColor.b, textColor.a);
            textMesh.outlineColor = new Color(textMesh.outlineColor.r, textMesh.outlineColor.g, textMesh.outlineColor.b, textColor.a);
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textColor.a);

            if (textColor.a <= 0)
            {
                // Destroy(gameObject);
                transform.localScale = scale;
                

                DmgPopUpPooler.Instance.AddToPool(gameObject);

            }
        }
    }
}
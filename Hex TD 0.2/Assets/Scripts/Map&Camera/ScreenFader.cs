using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
    public Image Image;
    public AnimationCurve curve;

    private void Start()
    {
       StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime * 1f;
            float a = curve.Evaluate(t); //controls the curve
            Image.color = new Color(0f, 0f, 0f, a); // this modifies the alpha value
            yield return 0; //skips to the next frame
        }
        WaveSpawner.EnemiesAlive = 0;
        WaveSpawner.EnemyCount = 0;
        //load a scene
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 0.5f;
            float a = curve.Evaluate(t); //controls the curve
            Image.color = new Color(0f, 0f, 0f, a); // this modifies the alpha value
            yield return 0; //skips to the next frame
        }
        //load a scene

        SceneManager.LoadScene(scene);
    }

}

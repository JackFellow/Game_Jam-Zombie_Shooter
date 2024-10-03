using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Image;
    CanvasGroup Damage;
    public static bool isDamage;
    void Start()
    {
        Image = GameObject.FindGameObjectWithTag("damage");
        Damage = Image.GetComponent<CanvasGroup>();
        Damage.alpha = 0f;
        isDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamage)
        {
            StartCoroutine(FadingImage());
        }
    }

    IEnumerator FadingImage()
    {


        //  Image.SetActive(true);
        Damage.alpha = 1f;
        yield return new WaitForSeconds(2f);
        float FadeTime = 1f;
        float time = 0f;

        while (time < FadeTime)
        {
            time += Time.deltaTime;
            Damage.alpha = Mathf.Lerp(1f, 0f, time / FadeTime);
            yield return null;

        }
        isDamage = false;
        Damage.alpha = 0f;


    }
}

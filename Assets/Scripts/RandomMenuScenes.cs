using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMenuScenes : MonoBehaviour
{

    public Sprite advertScene, businessScene, designScene, mediaManagementScene, marketingScene, PRScene;
    private List<Sprite> imgArray = new List<Sprite>();

    private float randTimer = 7f;
    private bool hasSwapped = false;
    // Start is called before the first frame update
    void Start()
    {
        imgArray.Add(advertScene);
        imgArray.Add(businessScene);
        imgArray.Add(designScene);
        imgArray.Add(mediaManagementScene);
        imgArray.Add(marketingScene);
        imgArray.Add(PRScene);

        randomize();
    }

    // Update is called once per frame
    void Update()
    {
        randTimer -= Time.deltaTime;
        if(randTimer <= 0)
        {
            hasSwapped = false;
            StartCoroutine("ImgFade");
            randTimer = 8f;
        }
    }

    void randomize()
    {
        int randImg = Mathf.FloorToInt(Random.Range(0, 6));
        while (randImg == imgArray.IndexOf(GetComponent<Image>().sprite)) {
            randImg = Mathf.FloorToInt(Random.Range(0, 6));
            
        }
        GetComponent<Image>().sprite = imgArray[randImg];

        switch (randImg)
        {
            case 0:
                GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Advertisement";
                break;
            case 1:
                GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Business Data Analytics";
                break;
            case 2:
                GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Design";
                break;
            case 3:
                GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Graphic Media Management";
                break;
            case 4:
                GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Marketing";
                break;
            case 5:
                GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Public Relations";
                break;
        }
    }

    IEnumerator ImgFade()
    {
        for(float a = 1; a > -1f; a -= .02f)
        {
            Color fade = GetComponent<Image>().color;
            fade.a = (a >= 0) ? a : -a;
            GetComponent<Image>().color = fade;
            GetComponentInChildren<TMPro.TextMeshProUGUI>().color = fade;
            if(a <= 0)
            {
                if(!hasSwapped)
                {
                    randomize();
                    hasSwapped = true;
                }
            }
            yield return new WaitForFixedUpdate();
        }
        
    }
}

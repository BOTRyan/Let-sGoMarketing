using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomMenuScenes : MonoBehaviour
{

    public Sprite advertScene, businessScene, designScene, mediaManagementScene, marketingScene, PRScene;
    private List<Sprite> imgArray = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        imgArray.Add(advertScene);
        imgArray.Add(businessScene);
        imgArray.Add(designScene);
        imgArray.Add(mediaManagementScene);
        imgArray.Add(marketingScene);
        imgArray.Add(PRScene);

        int randImg = Mathf.FloorToInt(Random.Range(0, 6));
        GetComponent<Image>().sprite = imgArray[randImg];

        switch(randImg)
        {
            case 0:
                GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Advertisement";
                break;
            case 1:
                GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Business Data Analytics";
                break;
            case 2:
                GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Graphic Design";
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

    // Update is called once per frame
    void Update()
    {
        
    }
}

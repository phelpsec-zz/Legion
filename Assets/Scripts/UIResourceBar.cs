using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIResourceBar : MonoBehaviour
{
    private GameObject resourceBar;

    private GameObject resourceDisplayText;
    private Text resourceDisplay;

    private GameObject player;
    private PlayerResource playerResource;

    void Awake()
    {
        resourceBar = GameObject.Find("Resource");

        player = GameObject.FindGameObjectWithTag("Player");
        playerResource = player.GetComponent<PlayerResource>();

        resourceDisplayText = GameObject.Find("Resource Display Text");
        resourceDisplay = resourceDisplayText.GetComponent<Text>();
    }

    void Start()
    {
        HideResourceText();
    }

    void Update()
    {
        resourceBar.transform.localScale = new Vector3(playerResource.ResourcePercentage, resourceBar.transform.localScale.y, resourceBar.transform.localScale.z);

        resourceDisplay.text = ((int)playerResource.CurrentResource + " / 100").ToString();
    }

    public void DisplayResourceText()
    {
        resourceDisplayText.SetActive(true);
    }

    public void HideResourceText()
    {
        resourceDisplayText.SetActive(false);
    }
}

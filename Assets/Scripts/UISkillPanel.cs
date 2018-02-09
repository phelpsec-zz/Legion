using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISkillPanel : MonoBehaviour
{
    //This class builds the buttons into the Skill Panel, which is accessed by clicking the Active Skill Button.
    //The number of buttons built is determined by the number of spells that character class has.

    private GameObject player;
    private PlayerCombat playerCombat;

    private GameObject skillPanel;
    private GameObject activeSkillButton;
    private GameObject skillPanelButtonPrefab;

    private Vector3 nextPosition = Vector3.zero;
    private int spacingBetweenButtons = 45;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCombat = player.GetComponent<PlayerCombat>();       

        skillPanel = GameObject.Find("Skill Panel");
        activeSkillButton = GameObject.Find("Active Skill Button");
        skillPanelButtonPrefab = Resources.Load("Prefabs/Skill Panel Button") as GameObject;
    }

    void Start()
    {
        HideSkillPanel();
        SetDefaultActiveSkillButton();

        for (int i = 0; i < playerCombat.spells.Count; i++)
        {
            GameObject skillPanelButton = Instantiate(skillPanelButtonPrefab, skillPanel.transform);

            skillPanelButton.name = playerCombat.spells[i].SpellName;
            skillPanelButton.GetComponent<Button>().onClick.AddListener(() => SetActiveSpell(skillPanelButton));
            skillPanelButton.transform.localPosition = nextPosition;

            nextPosition.x += spacingBetweenButtons;
        }
    }

    void SetDefaultActiveSkillButton()
    {
        for (int i = 0; i < playerCombat.spells.Count; i++)
        {

            //TODO: Once we get images, set this default image. 
            if (playerCombat.spells[i].IsActive)
            {
                Debug.Log("Active spell is currently " + playerCombat.spells[i].SpellName);
            }
        }
    }

    void SetActiveSpell(GameObject skillButton)
    {
        Debug.Log("You selected " + skillButton.name);
        activeSkillButton.GetComponent<Button>().image.color = skillButton.GetComponent<Button>().image.color;

        for (int j = 0; j < playerCombat.spells.Count; j++)
        {
            playerCombat.spells[j].IsActive = (playerCombat.spells[j].IsActive) ? false : playerCombat.spells[j].IsActive;
            playerCombat.spells[j].IsActive = (playerCombat.spells[j].SpellName == skillButton.name) ? true : playerCombat.spells[j].IsActive;
        }

        HideSkillPanel();
    }

    public void DisplaySkillPanel()
    {
        skillPanel.SetActive(true);
    }

    public void HideSkillPanel()
    {
        skillPanel.SetActive(false);
    }
}

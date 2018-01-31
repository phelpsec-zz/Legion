using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildSkillPanel : MonoBehaviour
{
    //This class builds the buttons into the Skill Panel, which is accessed by clicking the Active Skill Button.
    //The number of buttons built is determined by the number of spells that character class has.

    private GameObject player;
    private PlayerCombat playerCombat;

    private UIController uiController;

    private Canvas spellPanel;
    private GameObject activeSkillButton;
    private GameObject spellPanelButtonPrefab;

    private Vector3 nextPosition = Vector3.zero;
    private int spacingBetweenButtons = 45;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCombat = player.GetComponent<PlayerCombat>();

        uiController = GameObject.Find("UI").GetComponent<UIController>();

        spellPanel = GameObject.Find("Active Skill Panel").GetComponent<Canvas>();
        activeSkillButton = GameObject.Find("Active Skill Button");
        spellPanelButtonPrefab = Resources.Load("Prefabs/Spell Panel Button") as GameObject;
    }

    void Start()
    {   
        for (int i = 0; i < playerCombat.spells.Count; i++)
        {
            GameObject spellPanelButton = Instantiate(spellPanelButtonPrefab, spellPanel.transform);
            spellPanelButton.name = playerCombat.spells[i].SpellName;
            if (i == 0)
            {
                spellPanelButton.GetComponent<Button>().image.color = Color.red;
            } else
            {
                spellPanelButton.GetComponent<Button>().image.color = Color.blue;
            }

            spellPanelButton.GetComponent<Button>().onClick.AddListener(() => SetActiveSpell(spellPanelButton));

            spellPanelButton.transform.localPosition = nextPosition;
            nextPosition.x += spacingBetweenButtons;
        }
    }

    void SetActiveSpell(GameObject spellButton)
    {
        Debug.Log("You selected " + spellButton.name);
        activeSkillButton.GetComponent<Button>().image.color = spellButton.GetComponent<Button>().image.color;

        for (int j = 0; j < playerCombat.spells.Count; j++)
        {
            if (playerCombat.spells[j].IsActive)
            {
                playerCombat.spells[j].IsActive = false;
            }

            if (playerCombat.spells[j].SpellName == spellButton.name)
            {
                playerCombat.spells[j].IsActive = true;
            }
        }

        uiController.HideSkillPanel();
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryManager : MonoBehaviour
{
    [Header("UI References")]
    public Image backgroundImage;       // Background image UI
    public TMP_Text dialogueText;       // Text for story dialogue
    public Button[] choiceButtons;      // Buttons for player choices

    [Header("Story Start")]
    public StoryNodeSO startingNode;    // The first node of the story

    private StoryNodeSO currentNode;

    private void Start()
    {
        if (startingNode != null)
        {
            currentNode = startingNode;
            ShowNode(currentNode);
        }
        else
        {
            Debug.LogError("Starting Node is not assigned in StoryManager!");
        }
    }

    private void ShowNode(StoryNodeSO node)
    {
        currentNode = node;

        // Update background
        if (node.backgroundImage != null)
            backgroundImage.sprite = node.backgroundImage;

        // Update dialogue text
        dialogueText.text = node.dialogueText;

        // Update choice buttons
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < node.choices.Length)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].GetComponentInChildren<TMP_Text>().text = node.choices[i];

                int choiceIndex = i; // Capture index for closure
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(node.nextNodes[choiceIndex]));
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnChoiceSelected(StoryNodeSO nextNode)
    {
        if (nextNode != null)
        {
            ShowNode(nextNode);
        }
        else
        {
            Debug.Log("End of story branch reached.");
        }
    }
}

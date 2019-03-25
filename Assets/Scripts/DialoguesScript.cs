using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesScript : MonoBehaviour
{
    public Text GuiText;
    public GameObject DialogueScreen;
    public List<string> DialoguesList;

    private void Start()
    {
        
        DialoguesList.Add("*record scratches*");
        DialoguesList.Add("Yup, that's me");
        DialoguesList.Add("You might be wondering how I ended up here");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause/Menu Button") || Input.GetKeyDown(KeyCode.Return))
        {
            DialogueScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "DialoguePoint")
        {
            var dp = collision.GetComponent<DialoguePointScript>();

            if(dp.Visited == false)
            {
                DialogueScreen.SetActive(true);
                dp.Visited = true;
                GuiText.text = DialoguesList[dp.DialogueNumberTriggered - 1];
                Time.timeScale = 0;
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesScript : MonoBehaviour
{

    public string Dialogue1, Dialogue2, Dialogue3;
    public bool Dialogue1Done, Dialogue2Done, Dialogue3Done;
    public string[] Dialogues;
    public Text GuiText;
    public GameObject DialogueScreen;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "DialoguePoint")
        {
            var dp = collision.GetComponent<DialoguePointScript>();

            if(dp.Visited == false)
            {
                DialogueScreen.SetActive(true);
                dp.Visited = true;

                switch (dp.DialogueNumberTriggered)
                {
                    case 1:
                        GuiText.text = Dialogue1;
                        break;
                    case 2:
                        GuiText.text = Dialogue2;
                        break;
                    case 3:
                        GuiText.text = Dialogue3;
                        break;
                }
            }
        }

    }
}

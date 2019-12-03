using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// every time we use UI variables in Unity we need use this
using UnityEngine.UI;

public class UserInterface_VisualComponents_Example : MonoBehaviour
{
    public Text textComponent;
    public Image imageComponent;

    // both "Text" and "Image" components have several properties that can be changed through code as well
    // like the following examples
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            // we can change the actual text
            textComponent.text = "we can change text!";

            // we can change the actual sprite
            imageComponent.sprite = null;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            // we can change the alignment
            textComponent.alignment = TextAnchor.MiddleCenter;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            // we can change the color
            textComponent.color = Color.yellow;

            // in this case, since we can be using a sprite which can already have color, 
            // this "color" property will be multiplied by the sprite's color
            imageComponent.color = Color.yellow;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    

    public void DisableButton()
    {
        Button theButton = GetComponent<Button>();
        theButton.enabled = false;
    }
    public void EnableButton()
    {
        Button theButton = GetComponent<Button>();
        theButton.enabled = true;
    }
}

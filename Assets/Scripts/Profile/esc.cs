using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esc : MonoBehaviour
{
    public GameObject Box;
    public void OnEscButtonClick()
    {
        Box.SetActive(false);
    }
}

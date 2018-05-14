using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTab : MonoBehaviour {


    public GameObject tabBackground;
    public GameObject panel;

    private bool _open = false;

    public void StretchTab()
    {
        if(_open == false)
        {
            _open = true;
            tabBackground.transform.localScale = new Vector3(1, 15, 1);
            panel.transform.localPosition = new Vector3(-600, -100, 0);
        }
        else
        {
            _open = false;
            tabBackground.transform.localScale = new Vector3(1, 1, 1);
            panel.transform.localPosition = new Vector3(-600, -780, 0);

        }
    }

}

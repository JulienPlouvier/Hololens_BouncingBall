using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappedCommand : MonoBehaviour {

	void OnSelect()
    {
        if (this.gameObject.GetComponent<Renderer>().material.color != Color.red)
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        else
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
}

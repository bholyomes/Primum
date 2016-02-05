using UnityEngine;
using System.Collections;

public class BringToFront : MonoBehaviour {

	//makes this the last child in the heirarchy for its layer, therefor it will draw last (on top)
    void OnEnable()
    {
        transform.SetAsLastSibling();
    }
}

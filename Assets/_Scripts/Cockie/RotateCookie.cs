using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCookie : MonoBehaviour
{
    private void Update() {
         transform.Rotate(new Vector3(0, 0, 2) * Time.deltaTime);
    }
}

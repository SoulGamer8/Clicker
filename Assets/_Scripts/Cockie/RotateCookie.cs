using UnityEngine;

namespace NeverMindEver.Cookie{
    public class RotateCookie : MonoBehaviour
    {
        private void Update() {
            transform.Rotate(new Vector3(0, 0, 2) * Time.deltaTime);
        }
    }
}
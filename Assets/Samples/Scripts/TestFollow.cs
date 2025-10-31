/* Simple script to follow an object on XY plane. */

using UnityEngine;

public class TestFollow : MonoBehaviour {

    public Transform followTransform;

    private void FixedUpdate() {
        transform.position = new Vector3(followTransform.position.x, followTransform.position.y, transform.position.z);
    }

}

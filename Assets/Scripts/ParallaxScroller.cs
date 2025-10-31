/* To add the "parallax scrolling" to a game object, it needs:
    - to be the child of a game object containing the 'ParallaxScroller' component,
    - to have a 'ParallaxItem' component attached.
*/

using UnityEngine;

namespace ReplicaEngine {
    public class ParallaxScroller : MonoBehaviour {

        public Transform cameraTransform;
        public Transform horizonTransform;
        public Transform followTransform;

    }

}
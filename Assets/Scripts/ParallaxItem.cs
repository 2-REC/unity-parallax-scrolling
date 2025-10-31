/* The game object to which the 'ParallaxItem' component is attached must have
    a parent containing a 'ParallaxScroller' component.
*/

using UnityEngine;

namespace ReplicaEngine {

    public class ParallaxItem : MonoBehaviour {

        Transform cameraTransform;
        Transform horizonTransform;
        Transform followTransform;
        Vector2 startingPosition;

        Vector2 CamMoveSinceStart => (Vector2)cameraTransform.position - startingPosition;
        // TODO: the following 3 variables could be constant if don't want to handle moving objects on z axis
        float ZDistanceFromTarget => transform.position.z - followTransform.position.z;
        float Horizon => horizonTransform.position.z - followTransform.position.z;
        // if horizon & follow on same Z => no parallax
        float ParallaxFactor => (Horizon == 0f) ? 0f : ZDistanceFromTarget / Horizon;


        void Start() {
            ParallaxScroller parallaxScroller = GetComponentInParent<ParallaxScroller>();
            cameraTransform = parallaxScroller.cameraTransform;
            followTransform = parallaxScroller.followTransform;
            horizonTransform = parallaxScroller.horizonTransform;

            startingPosition = transform.position;
        }

        void FixedUpdate() {
            Vector2 newPosition = startingPosition + CamMoveSinceStart * ParallaxFactor;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }

    }

}
/* To add the "cycle scrolling" to a game object:
    - create another game object with a 'CycleScroller' component,
    - set the game object to receive the scrolling for the "item" property,
    - set the "camera" property.
*/

using UnityEngine;

namespace ReplicaEngine {

    public class CycleScroller : MonoBehaviour {

        public new Camera camera;
        public GameObject item;

        public bool horizontalScroll = true;
        public float horizontalDistance = 0;
        public bool verticalScroll = false;
        public float verticalDistance = 0;


        private void Start() {
            // get renderers bounds
            Bounds bounds = new();
            foreach (SpriteRenderer spriteRenderer in item.GetComponents<SpriteRenderer>()) {
                bounds.Encapsulate(spriteRenderer.bounds);
            }
            foreach (MeshRenderer meshRenderer in item.GetComponents<MeshRenderer>()) {
                bounds.Encapsulate(meshRenderer.bounds);
            }
            float width = bounds.size.x;
            float height = bounds.size.y;

            // avoid 0 distance (set to 1 per screen)
            if ((width == 0) && (horizontalDistance == 0)) {
                horizontalDistance = 1f;
            }
            if ((height == 0) && (verticalDistance == 0)) {
                verticalDistance = 1f;
            }

            float halfCamHeight = camera.orthographicSize;
            float halfCamWidth = halfCamHeight * camera.aspect;

            int widthCount = 1;
            float wOffset = 0f;
            if (horizontalScroll) {
                wOffset = (horizontalDistance == 0) ? width : (halfCamWidth * 2f) * horizontalDistance;
                widthCount = Mathf.CeilToInt((halfCamWidth * 2f + width + wOffset) / wOffset);
            }

            int heightCount = 1;
            float hOffset = 0f;
            if (verticalScroll) {
                hOffset = (verticalDistance == 0) ? height : (halfCamHeight * 2f) * verticalDistance;
                heightCount = Mathf.CeilToInt((halfCamHeight * 2f + height + hOffset) / hOffset);
            }


            for (var i = 0; i < widthCount; i++) {
                for (var j = 0; j < heightCount; j++) {
                    GameObject obj = Instantiate(
                        item,
                        new Vector3(
                            item.transform.position.x + i * wOffset,
                            item.transform.position.y + j * hOffset,
                            item.transform.position.z
                        ),
                        item.transform.rotation,
                        gameObject.transform
                    );

                    CycleItem cycleItem = obj.AddComponent<CycleItem>();
                    cycleItem.Init(
                        camera,
                        horizontalScroll,
                        verticalScroll,
                        width,
                        height,
                        wOffset,
                        hOffset,
                        widthCount,
                        heightCount
                    );
                }
            }

            item.SetActive(false);
        }


    }

}
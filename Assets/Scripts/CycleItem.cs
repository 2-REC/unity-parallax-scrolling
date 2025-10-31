/* The 'CycleItem' component is automatically added to
    instances of a game object receiving the "cycle scrolling".
*/

using UnityEngine;

namespace ReplicaEngine {

    public class CycleItem : MonoBehaviour {

        public new Camera camera;
        public bool horizontal = true;
        public bool vertical = false;
        public float width;
        public float height;
        public float wOffset;
        public float hOffset;
        public float widthCount;
        public float heightCount;

        float halfCamHeight;
        float halfCamWidth;


        public void Init(
            Camera camera,
            bool horizontal,
            bool vertical,
            float width,
            float height,
            float wOffset,
            float hOffset,
            float widthCount,
            float heightCount
        ) {
            this.horizontal = horizontal;
            this.vertical = vertical;
            this.camera = camera;
            this.wOffset = wOffset;
            this.width = width;
            this.hOffset = hOffset;
            this.height = height;
            this.widthCount = widthCount;
            this.heightCount = heightCount;
        }

        void Start() {
            halfCamHeight = camera.orthographicSize;
            halfCamWidth = halfCamHeight * camera.aspect;
        }

        void FixedUpdate() {
            Vector3 offset = camera.transform.position - transform.position;

            // TODO: optimise!
            if (horizontal) {
                if (offset.x > width / 2f + wOffset + halfCamWidth) {
                    transform.localPosition += new Vector3(wOffset * widthCount, 0f, 0f);
                } else if (offset.x < -(width / 2f + wOffset + halfCamWidth)) {
                    transform.localPosition += new Vector3(-wOffset * widthCount, 0f, 0f);
                }
            }

            if (vertical) {
                if (offset.y > height / 2f + hOffset + halfCamHeight) {
                    transform.localPosition += new Vector3(0f, hOffset * heightCount, 0f);
                } else if (offset.y < -(height / 2f + hOffset + halfCamHeight)) {
                    transform.localPosition += new Vector3(0f, -hOffset * heightCount, 0f);
                }
            }
        }

    }

}
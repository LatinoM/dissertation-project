using UnityEngine;
namespace Blocks
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BuildingBlock<T> : MonoBehaviour
    {

        public enum Type
        {
            BIT,
            BIT_NUM,
            COMP_NUM,
            BOOL_OUT,
            MATH
        }
        public Type type;
        public BuildingBlock<T> next;
        protected T val;

        public Type getType()
        {
            return type;
        }

        public BuildingBlock<T> getNext()
        {
            return next;
        }

        public T getVal()
        {
            return val;
        }

        protected abstract void initialise();

        // Click and drag variables
        private Vector3 offset;
        private bool isDragging = false;

        // Click and drag methods
        void OnMouseDown()
        {
            // Calculate offset from mouse position to object position
            offset = transform.position - GetMouseWorldPosition();
            isDragging = true;

            // Perform click action
            clicked();
        }

        void OnMouseDrag()
        {
            if (isDragging)
            {
                // Update object position based on mouse movement
                transform.position = GetMouseWorldPosition() + offset;

                // Perform drag action
                //Debug.Log("Object dragged!");
            }
        }

        void OnMouseUp()
        {
            // Reset dragging state
            isDragging = false;
        }

        Vector3 GetMouseWorldPosition()
        {
            // Convert mouse position to world space
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        public abstract void clicked();



    }
}

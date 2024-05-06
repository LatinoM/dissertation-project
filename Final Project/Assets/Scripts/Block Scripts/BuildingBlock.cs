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
            MATH,
            MATH_OUT,
            NUM_OUT,
            VAR,
            ARR,
            NOT,
            IFELSE
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
        void OnMouseDown()
        {
            // Perform click action
            clicked();
        }

        public abstract void clicked();



    }
}

using UnityEngine;
namespace Blocks
{
    public class BuildingBlock<T> : MonoBehaviour
    {
        protected string type;
        protected BuildingBlock<T> next;
        protected T val;

        public string getType()
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



    }
}

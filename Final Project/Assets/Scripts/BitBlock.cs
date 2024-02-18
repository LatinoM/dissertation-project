namespace Blocks
{
    public class BitBlock : BuildingBlock<int>
    {

        public BitBlock(int val)
        {
            if (val == 0 || val == 1)
                this.val = val;
            else
                this.val = 0;

            this.type = "bit";
        }

    }
}
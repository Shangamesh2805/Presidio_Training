using System;
using System.Threading.Tasks;

namespace day14_leetcode
{
    public class treenode
    {
        public int val;
        public treenode left;
        public treenode right;
        public treenode(int x) { val = x; }
    }

    public class solution
    {
        public async Task<int> mindepthAsync(treenode root)
        {
            if (root == null)
                return 0;

            if (root.left == null && root.right == null)
                return 1;

            if (root.left == null)
                return 1 + await mindepthAsync(root.right);

            if (root.right == null)
                return 1 + await mindepthAsync(root.left);

            return 1 + Math.Min(await mindepthAsync(root.left), await mindepthAsync(root.right));
        }
    }

    public class minimum_depth
    {
        static async Task Main(string[] args)
        {
            solution sol = new solution();

            treenode root1 = new treenode(3);
            root1.left = new treenode(9);
            root1.right = new treenode(20);
            root1.left.left = new treenode(10);
            root1.right.left = new treenode(15);
            root1.right.right = new treenode(7);

            int minDepth = await sol.mindepthAsync(root1);
            Console.WriteLine("Minimum depth of the tree: " + minDepth);
        }
    }
}

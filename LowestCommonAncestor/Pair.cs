namespace LowestCommonAncestor
{
    public class Pair
    {
        public Vertice Vertice1 { get; }

        public Vertice Vertice2 { get; }

        public Vertice Ancestor { get; set; }

        public Pair(Vertice vertice1, Vertice vertice2)
        {
            Vertice1 = vertice1;
            Vertice2 = vertice2;
            Ancestor = new Vertice(-1);
        }
    }
}

namespace LowestCommonAncestor
{
    using System.Collections.Generic;

    public class TarjanAlgorithm
    {
        private Vertice _root;
        public List<Pair> Pairs { get; }

        public TarjanAlgorithm(Vertice root, List<Pair> pairs)
        {
            _root = root;
            Pairs = pairs;
        }

        public void FindAncestors(Vertice vertice)
        {
            MakeSet(vertice);
            vertice.Ancestor = vertice;

            foreach (var child in vertice.Children)
            {
                FindAncestors(child);
                Union(vertice, child);
                Find(vertice).Ancestor = vertice;
            }

            vertice.StateColor = StateColor.Black;

            Vertice secondFromPair = null;

            foreach (var pair in Pairs)
            {
                if (pair.Vertice1.Index == vertice.Index)
                {
                    secondFromPair = pair.Vertice2;
                }
                else if (pair.Vertice2.Index == vertice.Index)
                {
                    secondFromPair = pair.Vertice1;
                }

                if (secondFromPair != null && secondFromPair.StateColor == StateColor.Black)
                {
                    pair.Ancestor = Find(secondFromPair).Ancestor;
                }

                secondFromPair = null;
            }
        }

        private void MakeSet(Vertice vertice)
        {
            vertice.Parent = vertice;
            vertice.Rank = 0;
        }

        private void Union(Vertice vertice1, Vertice vertice2)
        {
            var parent1 = Find(vertice1);
            var parent2 = Find(vertice2);

            if (parent1.Rank > parent2.Rank)
            {
                parent2.Parent = parent1;
            }
            else if (parent1.Rank < parent2.Rank)
            {
                parent1.Parent = parent2;
            }
            else if (parent1.Index != parent2.Index)
            {
                parent2.Parent = parent1;
                parent1.Rank++;
            }
        }

        private Vertice Find(Vertice vertice)
        {
            if (vertice.Parent == vertice)
            {
                return vertice;
            }

            vertice.Parent = Find(vertice.Parent);

            return vertice.Parent;
        }

        public override string ToString()
        {
            var output = "";

            foreach (var pair in Pairs)
            {
                output += $"Pair: [{pair.Vertice1.Index}, {pair.Vertice2.Index}] - Ancestor: {pair.Ancestor.Index}\n";
            }

            return output;
        }
    }
}

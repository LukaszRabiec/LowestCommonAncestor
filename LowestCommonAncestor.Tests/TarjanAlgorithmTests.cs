namespace LowestCommonAncestor.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    public class TarjanAlgorithmTests
    {
        private ITestOutputHelper _output;

        public TarjanAlgorithmTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TarjanFindCorrectAncestors()
        {
            var tree = CreateTree1();
            var pairs = CreatePairs1(tree);
            var tarjan = new TarjanAlgorithm(tree[0], pairs);

            tarjan.FindAncestors(tree[0]);

            tarjan.Pairs[0].Ancestor.Index.ShouldBeEquivalentTo(1);
            tarjan.Pairs[1].Ancestor.Index.ShouldBeEquivalentTo(0);
            tarjan.Pairs[2].Ancestor.Index.ShouldBeEquivalentTo(2);
            tarjan.Pairs[3].Ancestor.Index.ShouldBeEquivalentTo(0);

            _output.WriteLine(tarjan.ToString());
        }


        private List<Vertice> CreateTree1()
        {
            var tree = new List<Vertice>();

            tree.Add(new Vertice(0));
            tree.Add(new Vertice(1, tree[0]));
            tree.Add(new Vertice(2, tree[0]));
            tree.Add(new Vertice(3, tree[1]));
            tree.Add(new Vertice(4, tree[1]));
            tree.Add(new Vertice(5, tree[2]));
            tree.Add(new Vertice(6, tree[2]));
            tree.Add(new Vertice(7, tree[5]));
            tree.Add(new Vertice(8, tree[5]));

            return tree;
        }

        private List<Pair> CreatePairs1(List<Vertice> tree)
        {
            var pairs = new List<Pair>();

            pairs.Add(new Pair(tree[3], tree[4]));
            pairs.Add(new Pair(tree[8], tree[3]));
            pairs.Add(new Pair(tree[8], tree[6]));
            pairs.Add(new Pair(tree[6], tree[1]));

            return pairs;
        }
    }
}

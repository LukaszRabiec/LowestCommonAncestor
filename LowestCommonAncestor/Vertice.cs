namespace LowestCommonAncestor
{
    using System.Collections.Generic;

    public class Vertice
    {
        public int Index { get; set; }
        public int Rank { get; set; }
        public StateColor StateColor { get; set; }
        public Vertice Parent { get; set; }
        public Vertice Ancestor { get; set; }
        public List<Vertice> Children { get; set; }

        public Vertice(int index)
        {
            Index = index;
            Rank = 0;
            StateColor = StateColor.White;
            Parent = this;
            Ancestor = this;
            Children = new List<Vertice>();
        }

        public Vertice(int index, Vertice parent)
        {
            Index = index;
            Rank = 0;
            StateColor = StateColor.White;
            Parent = parent;
            Ancestor = this;
            Children = new List<Vertice>();
            Parent.Children.Add(this);
        }

    }

    public enum StateColor
    {
        White,
        Black
    }
}

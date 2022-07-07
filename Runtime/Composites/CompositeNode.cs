using System;
using System.Collections.Generic;

namespace BTree.Runtime.Composites
{
  public abstract class CompositeNode : Node
  {
    public List<Node> Children { get; } = new();

    protected override void OnAddChild(Node child)
    {
      if (!Children.Contains(child)) 
        Children.Add(child);
    } 

    protected override void OnRemoveChild(Node child) => Children.Remove(child);

    public override void Traverse(Action<Node> visitor)
    {
      base.Traverse(visitor);
      foreach (var child in Children)
      {
        child.Traverse(visitor);
      }
    }
  }
}
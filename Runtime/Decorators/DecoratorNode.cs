using System;

namespace BTree.Runtime.Decorators
{
  public abstract class DecoratorNode : Node
  {
    public Node Child { get; private set; }

    protected override void OnAddChild(Node node) => Child = node;

    protected override void OnRemoveChild(Node node)
    {
      if (node != Child)
      {
        Child = null;
      }
    }

    public override void Traverse(Action<Node> visitor)
    {
      base.Traverse(visitor);
      Child?.Traverse(visitor);
    }
  }
}
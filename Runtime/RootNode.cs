using System;

namespace BTree.Runtime
{
  [Serializable]
  public class RootNode : Node
  {
    public Node Child { get; private set; }

    protected override void OnAddChild(Node newChild) => Child = newChild;

    protected override void OnRemoveChild(Node _) => Child = null;

    protected override State OnEvaluate<T>(T context) => Child?.Evaluate(context) ?? State.Failure;

    public override void Traverse(Action<Node> visitor)
    {
      base.Traverse(visitor);
      Child?.Traverse(visitor);
    }
  }
}
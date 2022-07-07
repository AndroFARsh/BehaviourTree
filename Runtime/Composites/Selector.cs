using System;

namespace BTree.Runtime.Composites
{
  [Serializable]
  public class Selector : CompositeNode
  {
    protected override State OnEvaluate<T>(T context)
    {
      foreach (var child in Children)
      {
        switch (child.Evaluate(context))
        {
          case State.Running:
            return State.Running;
          case State.Success:
            return State.Success;
          case State.Failure:
            continue;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }

      return State.Failure;
    }
  }
}
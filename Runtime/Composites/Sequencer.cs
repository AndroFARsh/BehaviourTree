using System;

namespace BTree.Runtime.Composites
{
  [Serializable]
  public class Sequencer : CompositeNode
  {
    protected override State OnEvaluate<T>(T context)
    {
      foreach (var child in Children)
      {
        switch (child.Evaluate(context))
        {
          case State.Running:
            return State.Running;
          case State.Failure:
            return State.Failure;
          case State.Success:
            continue;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }

      return State.Success;
    }
  }
}
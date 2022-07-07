using System;

namespace BTree.Runtime.Composites
{
  [Serializable]
  public class Parallel : CompositeNode
  {
    protected override State OnEvaluate<T>(T context)
    {
      var stillRunning = false;
      foreach (var child in Children)
      {
        switch (child.Evaluate(context))
        {
          case State.Running:
            stillRunning = true;
            break;
          case State.Success:
            break;
          case State.Failure:
            return State.Failure;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }

      return stillRunning ? State.Running : State.Success;
    }
  }
}
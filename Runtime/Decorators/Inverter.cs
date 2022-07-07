using System;

namespace BTree.Runtime.Decorators
{
  [Serializable]
  public class Inverter : DecoratorNode
  {
    protected override State OnEvaluate<T>(T context)
    {
      switch (Child.Evaluate(context))
      {
        case State.Running:
          return State.Running;
        case State.Failure:
          return State.Success;
        case State.Success:
          return State.Failure;
      }

      return State.Failure;
    }
  }
}
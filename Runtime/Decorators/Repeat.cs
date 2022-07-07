using System;

namespace BTree.Runtime.Decorators
{
  [Serializable]
  public class Repeat : DecoratorNode
  {
    public bool restartOnSuccess = true;
    public bool restartOnFailure = false;

    protected override State OnEvaluate<T>(T context)
    {
      switch (Child.Evaluate(context))
      {
        case State.Running:
          break;
        case State.Failure:
          return restartOnFailure ? State.Running : State.Failure;
        case State.Success:
          return restartOnSuccess ? State.Running : State.Success;
      }

      return State.Running;
    }
  }
}
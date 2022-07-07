using System;

namespace BTree.Runtime.Decorators
{
  [Serializable]
  public class Failure : DecoratorNode
  {
    protected override State OnEvaluate<T>(T context)
    {
      var state = Child.Evaluate(context);
      return state == State.Success ? State.Failure : state;
    }
  }
}
using System;

namespace BTree.Runtime.Decorators
{
  [Serializable]
  public class Succeed : DecoratorNode
  {
    protected override State OnEvaluate<T>(T context)
    {
      var state = Child.Evaluate(context);
      return state == State.Failure ? State.Success : state;
    }
  }
}
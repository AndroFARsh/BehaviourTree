using System;
using UnityEngine;

namespace BTree.Runtime.Decorators
{
  [Serializable]
  public class Timeout : DecoratorNode
  {
    public float duration = 1.0f;

    private float startTime = -1;

    protected override State OnEvaluate<T>(T context)
    {
      if (startTime < 0)
      {
        startTime = Time.time;
      }
      else if (Time.time - startTime > duration)
      {
        startTime = -1;
        return State.Failure;
      }

      return Child.Evaluate(context);
    }
  }
}
using System;
using UnityEngine;

namespace BTree.Runtime.Actions
{
  [Serializable]
  public class Breakpoint : ActionNode
  {
    public string message;

    protected override State OnEvaluate<T>(T context)
    {
      Debug.Log($"Triggering Breakpoint {message}");
      Debug.Break();
      return State.Success;
    }
  }
}
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BTree.Runtime.Actions
{
  [Serializable]
  public class RandomFailure : ActionNode
  {
    [Range(0, 1)] public float chanceOfFailure = 0.5f;

    protected override State OnEvaluate<T>(T context) => Random.value > chanceOfFailure
      ? State.Failure
      : State.Success;
  }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TakeableDamage<T>
{
    void StartTakeDamage(T damageTaken);
    void TakeDamage(T damageTaken);
    void StopTakeDamage();
    void TakeGameOver();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState
{
    void Start();

    void Update();

    void End();

    void Perform(string type);

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicStatus
{
    public int HitPoint;
    public int Energy;
    public int Speed;
    public int Limit;

    public MechanicStatus(Define.Mechanic mechanic)
    {
        switch (mechanic)
        {
            case Define.Mechanic.Gundam1:
                HitPoint = 70;
                Energy = 30;
                Speed = 2;
                Limit = 80;
                break;
            case Define.Mechanic.Gundam2:
                HitPoint = 70;
                Energy = 30;
                Speed = 4;
                Limit = 80;
                break;
            case Define.Mechanic.Zaku2:
                HitPoint = 10;
                Energy = 20;
                Speed = 1;
                Limit = 60;
                break;
        }
    }
}

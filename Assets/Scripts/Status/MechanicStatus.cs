using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicStatus
{
    public int HitPoint;
    public int Energy;
    public int Speed;
    public int Limit;
    public int CloseDamage;
    public int RangeDamage;
    public int RangeDistance;


    public MechanicStatus(Define.Mechanic mechanic)
    {
        switch (mechanic)
        {
            case Define.Mechanic.Gundam1:
                HitPoint = 70;
                Energy = 30;
                Speed = 2;
                Limit = 80;
                CloseDamage = 10;
                RangeDamage = 3;
                RangeDistance = 4;
                break;
            case Define.Mechanic.Gundam2:
                HitPoint = 70;
                Energy = 30;
                Speed = 2;
                Limit = 80;
                CloseDamage = 10;
                RangeDamage = 3;
                RangeDistance = 4;
                break;
            case Define.Mechanic.Zaku2:
                HitPoint = 10;
                Energy = 20;
                Speed = 1;
                Limit = 60;
                CloseDamage = 3;
                RangeDamage = 1;
                RangeDistance = 3;
                break;
        }
    }
}

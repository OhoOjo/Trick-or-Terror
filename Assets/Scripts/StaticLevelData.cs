using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticLevelData
{
    public static int lvl1 = 0;
    public static int lvl2 = 0;
    public static int lvl3 = 0;

    public static int LVL1(int one)
    {
        lvl1 = one;
        return (lvl1);
    }

    public static int LVL2(int one)
    {
        lvl2 = one;
        return (lvl2);
    }

    public static int LVL3(int one)
    {
        lvl3 = one;
        return (lvl3);
    }

    public static int LVL4 { get; set; }
    public static int LVL5 { get; set; }
    public static int LVL6 { get; set; }
    public static int LVL7 { get; set; }
    public static int LVL8 { get; set; }
    public static int LVL9 { get; set; }

   /* public static void Unlock()
    {

    }*/

}

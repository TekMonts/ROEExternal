
using System;
using System.Collections.Generic;

namespace TekMonts
{
    internal class Helper
    {
        public static Dictionary<int, string> Items = new Dictionary<int, string>
                    {
                        { 0, "Nothing"},
                        { 10102, "MosinNagant"},
                        { 10104, "G28"},
                        { 10201, "M4A1"},
                        { 10202, "AK47"},
                        { 10204, "LVOAC"},
                        { 10205, "Groza"},
                        { 10207, "AUG"},
                        { 10301, "MP5"},
                        { 10303, "Vector"},
                        { 10401, "Remington870"},
                        { 10402, "Citori"},
                        { 10403, "Origin12"},
                        { 20001, "USP45"},
                        { 20002, "Glock17"},
                        { 20003, "DesertEagle"},
                        { 30001, "Ammo556mm"},
                        { 30002, "Ammo762mm"},
                        { 30003, "Ammo9mm"},
                        { 30004, "Ammo12Gauge"},
                        { 30005, "Ammo45ACP"},
                        { 30006, "Ammo50ACP"},
                        { 40101, "SilencerSniper"},
                        { 40103, "SilencerAssaultRifle"},
                        { 40104, "FlashHiderAssaultRifleOrigin12"},
                        { 40105, "SilencerSubmachineGun"},
                        { 40106, "CompensatorSubmachinegun"},
                        { 40107, "ChokeShotgun"},
                        { 40108, "FlashHiderSubmachinegun"},
                        { 40109, "FlashHiderSniper"},
                        { 40110, "CompensatorAssaultRifleOrigin12"},
                        { 40111, "CompensatorSniperRifle"},
                        { 40201, "TriangularForegrip"},
                        { 40202, "VerticalForegrip"},
                        { 40302, "Scope8x"},
                        { 40303, "Scope4x"},
                        { 40304, "Scope2x"},
                        { 40305, "Reddot"},
                        { 40306, "Holographic"},
                        { 40401, "ExtendedMagazineSniper"},
                        { 40403, "ExtendedMagazineAssaultRifleOrigin12"},
                        { 40405, "ExtendedMagazineSubmachineGun"},
                        { 40502, "TacticalStockM4A1"},
                        { 50001, "Grenade"},
                        { 50002, "SmokeGrenade"},
                        { 70001, "Bandage"},
                        { 70002, "FirstaidKit"},
                        { 70003, "Medkit"},
                        { 200101, "HelmetLv1"},
                        { 200102, "HelmetLv2"},
                        { 200103, "HelmetLv3"},
                        { 200901, "BackpackLv1"},
                        { 200902, "BackpackLv2"},
                        { 200903, "BackpackLv3"},
                        { 201001, "BulletproofVestLv1"},
                        { 201002, "BulletproofVestLv2"},
                        { 201001, "Flash BulletproofVestLv3"}
                    };

        public static int GetDistance(Vector3 v1, Vector3 v2, int Divide)
        {
            Vector3 vector3 = new Vector3();
            vector3.X = v1.X - v2.X;
            vector3.Y = v1.Y - v2.Y;
            vector3.Z = v1.Z - v2.Z;
            return (int)Math.Sqrt(Math.Pow((double)vector3.X, 2.0) + Math.Pow((double)vector3.Y, 2.0) + Math.Pow((double)vector3.Z, 2.0)) / Divide;
        }
    }
}

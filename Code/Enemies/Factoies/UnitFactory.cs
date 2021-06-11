using System.IO;
using UnityEngine;

namespace Asteroids
{
    internal sealed class UnitFactory
    { 
        public Enemy[] UnitsFromFile(string path)
        {
            string file = File.ReadAllText(path);
            UnitsArray unitsarray = JsonUtility.FromJson<UnitsArray>(file);
            MagFactory magFactory = new MagFactory();
            InfantryFactory infantryFactory = new InfantryFactory();
            Unit[] units = unitsarray.units;
            Enemy[] enemies = new Enemy[units.Length];
            for(int i = 0; i< units.Length; i++)
            {
                Unit unit = units[i];
                switch (unit.type)
                {
                    case "mag" : enemies[i] = magFactory.Create(new Health(unit.health)); break;
                    case "infantry": enemies[i] = infantryFactory.Create(new Health(unit.health)); break;
                    default : Debug.Log("Несуществующий тип в массиве юнитов"); break;
                }                
            }
            return enemies;
        }
    }
}
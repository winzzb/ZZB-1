using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Siample
{
    class Program
    {
        static void Main(string[] args)
        {
            Vegetable vge = new RootVegetable();
            vge.PlantVegetable();
            Console.ReadLine();

            Vegetable vge1 = (Vegetable)SimpleVegetableFactory.GetVegetableInstance("茎菜类蔬菜");
            vge1.PlantVegetable();
            Vegetable vge2 = (Vegetable)SimpleVegetableFactory.GetVegetableInstance("根菜类蔬菜");
            vge2.PlantVegetable();
            Console.ReadLine();


            // 初始化工厂
            VegetableFactory Factory = new RootVegetableFactory();
            //种植根菜类蔬菜
            Vegetable vge3 = Factory.GetVegetableInstance();
            vge3.PlantVegetable();
            Console.ReadLine();


            string factoryName = ConfigurationManager.AppSettings["factoryName"];
            VegetableFactory vf = (VegetableFactory)Assembly.Load("Factory_Siample").CreateInstance(factoryName);
            Vegetable vge4 = vf.GetVegetableInstance();
            vge4.PlantVegetable();
            Console.ReadLine();


        }
    }
}

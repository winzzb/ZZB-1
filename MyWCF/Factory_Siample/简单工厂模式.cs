using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Siample
{
    ///// <summary>
    ///// 根菜类
    ///// </summary>
    //public class RootVegetable
    //{
    //    public void PlantVegetable()
    //    {
    //        Console.WriteLine("亲！我在种植大豆，胡萝卜，还有大头菜哦！");
    //    }
    //}

    ///// <summary>
    ///// 茎菜类
    ///// </summary>
    //public class StemVegetable
    //{
    //    public void PlantVegetable()
    //    {
    //        Console.WriteLine("亲啊！我在种植竹笋，莲藕，还有马铃薯哦！");
    //    }
    //}
    

    /// <summary>
    /// 蔬菜接口
    /// </summary>
    public abstract class Vegetable
    {
        public abstract void PlantVegetable();
    }
    

    public class RootVegetable : Vegetable
    {
        public override void PlantVegetable()
        {
            Console.WriteLine("亲！我在种植大豆，胡萝卜，还有大头菜哦！");
        }
    }

    public class StemVegetable : Vegetable
    {
        public override void PlantVegetable()
        {
            Console.WriteLine("亲啊！我在种植竹笋，莲藕，还有马铃薯哦！");
        }
    }

    public class SimpleVegetableFactory
    {
        public static Vegetable GetVegetableInstance(string vegetable)
        {
            Vegetable vge = null;
            if (vegetable.Equals("根菜类蔬菜"))
            {
                vge = new RootVegetable();
            }
            else if (vegetable.Equals("茎菜类蔬菜"))
            {
                vge = new StemVegetable();
            }

            return vge;
        }
    }




}

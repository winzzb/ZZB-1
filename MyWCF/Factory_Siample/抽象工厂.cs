using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Siample
{
    interface IVegetable
    {
        
 
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class abstractRootVegetable : IVegetable
    {
        public abstract void PlantRootVegetable();
    }

    public abstract class abstractStemVegetable : IVegetable
    {
        public abstract void PlantStemVegetable();
    }

    /// <summary>
    ///  转基因根菜
    /// </summary>
    public class GMFRootVegetable : abstractRootVegetable
    {
        public override void PlantRootVegetable()
        {
            Console.WriteLine("亲！我在种植转基因类型的大豆，胡萝卜，还有大头菜哦！");
        }
    }

    /// <summary>
    ///  非转基因根菜
    /// </summary>
    public class NonGMFRootVegetable : abstractRootVegetable
    {
        public override void PlantRootVegetable()
        {
            Console.WriteLine("亲！我在种植非转基因类型的大豆，胡萝卜，还有大头菜哦！");
        }
    }

    /// <summary>
    /// 转基因茎菜
    /// </summary>
    public class GMFStemVegetable : abstractStemVegetable
    {
        public override void PlantStemVegetable()
        {
            Console.WriteLine("亲啊！我在种植转基因类型的芹菜，莲藕，还有马铃薯哦！");
        }
    }

    /// <summary>
    /// 非转基因茎菜
    /// </summary>
    public class NonGMFStemVegetable : abstractStemVegetable
    {
        public override void PlantStemVegetable()
        {
            Console.WriteLine("亲啊！我在种植非转基因类型的芹菜，莲藕，还有马铃薯哦！");
        }
    }


    /// <summary>
    /// 转基因工厂
    /// </summary>
    public class abstractVegetableFactory
    {
        /// <summary>
        /// 转基因根菜
        /// </summary>
        /// <returns></returns>
        public abstractRootVegetable GetRootVegetableInstantce()
        {
            return new GMFRootVegetable();
        }

        /// <summary>
        /// 转基因茎菜
        /// </summary>
        /// <returns></returns>
        public abstractStemVegetable GetRootVegetableInstant()
        {
            return new GMFStemVegetable();
        }
    }














}

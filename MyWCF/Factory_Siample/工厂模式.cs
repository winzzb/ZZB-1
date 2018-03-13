using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Siample
{
    //public class RootVegetableFactory
    //{
    //    public Vegetable GetVegetableInstance()
    //    {
    //        return new RootVegetable();
    //    }
    //}

    //public class StemVegetableFactory
    //{
    //    public Vegetable GetVegetableInstance()
    //    {
    //        return new StemVegetable();
    //    }
    //}

    public abstract class VegetableFactory
    {
        public abstract Vegetable GetVegetableInstance() ;
    }

    public class RootVegetableFactory : VegetableFactory
    {
        public override Vegetable GetVegetableInstance()
        {
            return new RootVegetable();
        }
    }

    public class StemVegetableFactory : VegetableFactory
    {
        public override Vegetable GetVegetableInstance()
        {
            return new StemVegetable();
        }
    }
}

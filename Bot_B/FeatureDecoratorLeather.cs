namespace Bot_B
{
     class FeatureDecoratorLeather : ItemDecorator
    {
         private Iitem _original_item;

        public FeatureDecoratorLeather(Iitem original_item)
        {
            _original_item = original_item; 
        }

        public override string GetDesc()
        {
            string seperator = " ";
            if (!_original_item.GetDesc().EndsWith(" "))
            {
                seperator = " and ";
            }
            return _original_item.GetDesc() +seperator+ "covered in high quality leather"; 
        }

        public override string GetName()
        {
            return _original_item.GetName(); 
        }

        public override double GetPrice()
        {
            return _original_item.GetPrice() + 5.5; 
        }
    }
}
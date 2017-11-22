namespace Bot_B
{

    class FeatureDecoratorTigerPrint : ItemDecorator
    {
        private Iitem _original_item;

        public FeatureDecoratorTigerPrint(Iitem original_item)
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
            return _original_item.GetDesc() +seperator+ "covered in beautiful tiger print"; 
        }

        public override string GetName()
        {
            return _original_item.GetName(); 
        }

        public override double GetPrice()
        {
            return _original_item.GetPrice() + 3.2; 
        }
    }
}
namespace Bot_B
{
    class FeatureDecoratorGold : ItemDecorator
    {
        private Iitem _original_item;

        public FeatureDecoratorGold(Iitem orginal_item)
        {
            _original_item = orginal_item;
        }

        public override string GetDesc()
        {
            string seperator = "";
            if (!_original_item.GetDesc().EndsWith(" "))
            {
                seperator = " and ";
            }
            return _original_item.GetDesc() +seperator+ "covered in 5-karat gold"; 
        }

        public override string GetName()
        {
            return _original_item.GetName(); 
        }

        public override double GetPrice()
        {
            return _original_item.GetPrice() + 7.4; 
        }
    }
}
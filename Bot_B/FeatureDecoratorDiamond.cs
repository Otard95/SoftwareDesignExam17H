namespace Bot_B
{
     class FeatureDecoratorDiamond : ItemDecorator
    {
        private Iitem _original_item;

        public FeatureDecoratorDiamond(Iitem original_item)
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
            return _original_item.GetDesc() + seperator + "with beautiful south-african diamonds";
        }

        public override string GetName()
        {
            return _original_item.GetName();
        }

        public override double GetPrice()
        {
            return _original_item.GetPrice() + 6.4;
        }

    }
    
}
  
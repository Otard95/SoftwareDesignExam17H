namespace Bot_B
{
    class FeatureDecoratorGold : ItemDecorator
    {
        private Iitem _orginal_item;

        public FeatureDecoratorGold(Iitem orginal_item)
        {
            _orginal_item = orginal_item;
        }

        public override string GetDesc()
        {
            return _orginal_item.GetDesc() + "Gold coating"; 
        }

        public override string GetName()
        {
            return _orginal_item.GetName(); 
        }

        public override double GetPrice()
        {
            return _orginal_item.GetPrice() + 4.4; 
        }
    }
}
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
            return _original_item.GetDesc() + " Feature: With beautiful South-African Diamonds ";
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
  
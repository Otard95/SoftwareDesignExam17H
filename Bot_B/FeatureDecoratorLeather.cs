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
            return _original_item.GetDesc() + "Leather bullshit.. "; 
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
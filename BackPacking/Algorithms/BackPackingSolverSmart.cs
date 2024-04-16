


    public class BackPackingSolverSmart : BackPackingSolverBase
    {
        public BackPackingSolverSmart(List<BackPackItem> items, double capacity)
            : base(items, capacity)
        { 
        }

        public override void Solve(ItemVault theItemVault, BackPack theBackPack)
        {
            List<BackPackItem> sortedItems = theItemVault.Items.OrderByDescending(item => item.Value / item.Weight).ToList();

            foreach (var item in sortedItems)
            {
                if (theBackPack.WeightCapacityLeft >= item.Weight)
                {
                    theBackPack.AddItem(theItemVault.RemoveItem(item.Description));
                }
            }
        }
    }


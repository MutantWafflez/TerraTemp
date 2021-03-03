namespace TerraTemp.Custom.Structs {

    /// <summary>
    /// Struct that handles instances of Shop Items for TerraTemp NPCs to make the shop setup
    /// process a bit easier
    /// </summary>
    public struct ShopItem {

        /// <summary>
        /// The Item ID of this given shop item.
        /// </summary>
        public int shopItemID;

        /// <summary>
        /// The conditions that are tested to determine whether or not this given item will be sold.
        /// </summary>
        public SaleDelegate IsForSale {
            get;
        }

        public ShopItem(int itemID, SaleDelegate itemSaleConditions = null) {
            shopItemID = itemID;
            IsForSale = itemSaleConditions ?? (() => true);
        }

        public delegate bool SaleDelegate();
    }
}
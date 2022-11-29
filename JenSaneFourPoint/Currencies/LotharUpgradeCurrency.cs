using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Localization;

namespace JenSaneFourPoint.Currencies
{
    public class LotharUpgradeCurrency : CustomCurrencySingleCoin
    {
        public LotharUpgradeCurrency(int coinItemID, long currencyCap, string CurrencyTextKey) : base(coinItemID, currencyCap)
        {
            this.CurrencyTextKey = CurrencyTextKey;
            CurrencyTextColor = Color.BlueViolet;
        }
    }
}
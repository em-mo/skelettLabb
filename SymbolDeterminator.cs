using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.SkeletonBasics
{
    class SymbolDeterminator
    {
        private const int StableLimit = 15;

        private string currentStableSymbol;
        private string newSymbol;
        private int newSymbolCount;

        public SymbolDeterminator()
        {
            currentStableSymbol = "";
            newSymbol = "";
            newSymbolCount = 0;
        }

        public void DetermineStableSymbol(string latestSymbol)
        {
            if (currentStableSymbol.Equals(latestSymbol, StringComparison.Ordinal))
            {
                return;
            }
            else if (newSymbol.Equals(latestSymbol, StringComparison.Ordinal))
            {
                newSymbolCount++;
                if (newSymbolCount > StableLimit)
                {
                    currentStableSymbol = newSymbol;
                    newSymbol = "";
                    newSymbolCount = 0;
                }
            }
            else
            {
                newSymbol = latestSymbol;
                newSymbolCount = 0;
            }
        }

        public string GetSymbol()
        {
            return currentStableSymbol;
        }
    }
}

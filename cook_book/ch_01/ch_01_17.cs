using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//使类支持foreach
namespace cook_book.ch_01
{
    class ch_01_17
    {
        public static void Test()
        {
            StockPortfolio tech = new StockPortfolio()
            {
                {"OU81", -10.5},
                {"C#6VR", 2.0},
                {"PCKD", 12.3},
                {"BTML", 0.5},
                {"NOVB", -35.2},
                {"MGDCD", 15.7},
                {"GNRCS", 4.0},
                {"FNCTR", 9.16},
                {"LMBDA", 9.12},
                {"PCLS", 6.11}
            };

            foreach (var v in tech)
            {
                Console.WriteLine(v.Ticker);
            }
        }
    }

    public class StockPortfolio : IEnumerable<Stock>
    {
        private List<Stock> _stocks;

        public StockPortfolio()
        {
            _stocks = new List<Stock>();
        }

        public void Add(string ticker, double gainLoss)
        {
            _stocks.Add(new Stock() {Ticker = ticker, GainLoss = gainLoss});
        }

        public IEnumerable<Stock> GetWorstPerformers(int topNumber) =>
            _stocks.OrderBy((Stock stock) => stock.GainLoss).Take(topNumber);

        public void SellStocks(IEnumerable<Stock> stocks)
        {
            foreach (var s in stocks)
            {
                _stocks.Remove(s);
            }
        }

        public void PrintPortfolio(string title)
        {
            Console.WriteLine(title);
        }

        public IEnumerator<Stock> GetEnumerator() => _stocks.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

    public class Stock
    {
        public double GainLoss { get; set; }
        public string Ticker { get; set; }
    }
}
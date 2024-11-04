using StockMate.Domain.Exceptions;
using StockMate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StockMate.Domain.Services.TransactionService
{
    public class BuyStockService : IBuyStockService
    {

        private readonly ICryptoAssetService _cryptoAssetService;
        private readonly IDataService<Account> _accountService;

        public BuyStockService(ICryptoAssetService cryptoAssetService, IDataService<Account> accountService)
        {
            _cryptoAssetService = cryptoAssetService;
            _accountService = accountService;
        }



        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            CryptoAsset cryptoAsset = await _cryptoAssetService.GetCryptoAsset(symbol);
            double stockPrice = (double)cryptoAsset.Price;
            double transactionPrice = stockPrice* shares;

            if (transactionPrice > buyer.Balance)
            {
                throw new InsufficientFundsException(buyer.Balance, transactionPrice);


            }



            AssetTransaction transaction = new AssetTransaction()
            {
                Account = buyer,
                Stock = new Stock()
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                Shares = shares,
                isPurchase = true

            };
            buyer.AssetTransactions.Add(transaction);

            buyer.Balance -= transactionPrice;

            await _accountService.Update(buyer.Id, buyer);
            return buyer;

        }
    }
}

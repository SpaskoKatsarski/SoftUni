using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWalletManagementSystem
{
    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, Wallet> wallets = new Dictionary<string, Wallet>();

        private Dictionary<string, List<Wallet>> userWallets = new Dictionary<string, List<Wallet>>();
        private Dictionary<User, List<Transaction>> userTransactions = new Dictionary<User, List<Transaction>>();
        private Dictionary<string, List<Transaction>> userTransactionsById = new Dictionary<string, List<Transaction>>();

        public void CreateUser(User user)
        {
            this.users.Add(user.Id, user);

            this.userWallets.Add(user.Id, new List<Wallet>());
            this.userTransactions.Add(user, new List<Transaction>());
            this.userTransactionsById.Add(user.Id, new List<Transaction>());
        }

        public void CreateWallet(Wallet wallet)
        {
            this.wallets.Add(wallet.Id, wallet);

            wallet.User = this.users[wallet.UserId];

           this.userWallets[wallet.UserId].Add(wallet);
        }

        public bool ContainsUser(User user)
        {
            return this.users.ContainsKey(user.Id);
        }

        public bool ContainsWallet(Wallet wallet)
        {
            return this.wallets.ContainsKey(wallet.Id);
        }

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
        {
            return this.userWallets[userId];
        }

        public void PerformTransaction(Transaction transaction)
        {
            if (!this.wallets.ContainsKey(transaction.SenderWalletId) || !this.wallets.ContainsKey(transaction.ReceiverWalletId))
            {
                throw new ArgumentException();
            }

            long amount = transaction.Amount;

            Wallet senderWallet = this.wallets[transaction.SenderWalletId];
            Wallet receiverWallet = this.wallets[transaction.ReceiverWalletId];

            if (senderWallet.Balance < amount)
            {
                throw new ArgumentException();
            }

            senderWallet.Balance -= amount;
            receiverWallet.Balance += amount;

            this.userTransactions[senderWallet.User].Add(transaction);
            this.userTransactions[receiverWallet.User].Add(transaction);

            this.userTransactionsById[senderWallet.UserId].Add(transaction);
            this.userTransactionsById[receiverWallet.UserId].Add(transaction);
        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
        {
            return this.userTransactionsById[userId];
        }

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
        {
            return this.wallets.Values
                .OrderByDescending(w => w.Balance);
        }

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
        {
            List<string> userIds = this.userWallets
                .OrderByDescending(kvp => kvp.Value.Sum(w => w.Balance))
                .Select(kvp => kvp.Key)
                .ToList();

            List<User> users = new List<User>();

            foreach (var id in userIds)
            {
                users.Add(this.users[id]);
            }

            return users;
        }

        public IEnumerable<User> GetUsersByTransactionCount()
        {
            List<User> users = this.userTransactions
                .OrderByDescending(kvp => kvp.Value.Count)
                .Select(kvp => kvp.Key)
                .ToList();

            return users;
        }
    }
}
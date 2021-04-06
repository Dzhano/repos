using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> chainblock;

        public Chainblock()
        {
            chainblock = new Dictionary<int, ITransaction>();
        }

        public int Count => chainblock.Count;

        public void Add(ITransaction tx)
        {
            if (!Contains(tx.Id)) chainblock.Add(tx.Id, tx);
            else throw new InvalidOperationException();
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!Contains(id)) throw new ArgumentException();

            chainblock[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            ITransaction transaction = chainblock.FirstOrDefault(t => t.Key == tx.Id).Value;
            
            if (transaction == null) return false;

            return transaction.Id == tx.Id && transaction.Status == tx.Status
                && transaction.To == tx.To && transaction.From == tx.From
                && transaction.Amount == tx.Amount;
        }

        public bool Contains(int id)
        {
            return chainblock.Any(t => t.Key == id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            IEnumerable<ITransaction> transactions =
                chainblock.Values.Where(t => t.Amount >= lo && t.Amount <= hi);

            return transactions;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            IEnumerable<ITransaction> transactions = chainblock.Values
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            //if (transactions.Count() == 0) throw new InvalidOperationException();
            return transactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> receivers = chainblock.Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To);

            if (receivers.Count() == 0) throw new InvalidOperationException();
            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> senders = chainblock.Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From);

            if (senders.Count() == 0) throw new InvalidOperationException();
            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!Contains(id)) throw new InvalidOperationException();

            return chainblock.First(t => t.Key == id).Value;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            IEnumerable<ITransaction> transactions = chainblock.Values
                .Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (transactions.Count() == 0) throw new InvalidOperationException();
            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> transactions = chainblock.Values
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (transactions.Count() == 0) throw new InvalidOperationException();
            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> transactions = chainblock.Values
                .Where(t => t.From == sender)
                .Where(t => t.Amount > amount)
                .OrderByDescending(t => t.Amount);

            if (transactions.Count() == 0) throw new InvalidOperationException();
            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> transactions = chainblock.Values
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount);

            if (transactions.Count() == 0) throw new InvalidOperationException();
            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> transactions = chainblock.Values
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount);

            if (transactions.Count() == 0) throw new InvalidOperationException();
            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            IEnumerable<ITransaction> transactions = chainblock.Values
                .Where(t => t.Status == status)
                .Where(t => t.Amount <= amount)
                .OrderByDescending(t => t.Amount);

            return transactions;
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (ITransaction transaction in chainblock.Values)
                yield return transaction;
        }

        public void RemoveTransactionById(int id)
        {
            if (!Contains(id)) throw new InvalidOperationException();

            chainblock.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

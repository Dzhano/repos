using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void Setup()
        {
            chainblock = new Chainblock();
        }

        [Test]
        public void Add_ThrowsException_WhenTransactionAlreadyExist()
        {
            chainblock.Add(CreateTransaction(1, "Dzhano", "Peter", 100, TransactionStatus.Unauthorized));

            Assert.Throws<InvalidOperationException>(() => chainblock.Add(CreateTransaction(1, "Peter", "Dzhano", 100, TransactionStatus.Unauthorized)));
        }

        [Test]
        public void Add_Successfull_ShouldAddTransaction_WithValidId()
        {
            ITransaction transaction = CreateTransaction(1, "Dzhano", "Peter", 100, TransactionStatus.Successfull);
            chainblock.Add(transaction);

            Assert.That(chainblock.Count, Is.EqualTo(1));
            Assert.That(chainblock.Contains(transaction), Is.True);
            Assert.That(chainblock.Contains(transaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsTrue_WhenTransactionWithIdExist()
        {
            ITransaction transaction = CreateTransaction(1, "Dzhano", "Peter", 100, TransactionStatus.Failed);
            chainblock.Add(transaction);

            Assert.That(chainblock.Contains(transaction.Id), Is.True, "Cannot find existing transaction.");
        }

        [Test]
        public void ContainsId_ReturnsFalse_WhenTransactionWithIdDoesNotExist()
        {
            Assert.That(chainblock.Contains(1), Is.False, "Finds notexisting transaction.");
        }

        [Test]
        public void Contains_ReturnsTrue_WhenTransactionExist()
        {
            ITransaction transaction = CreateTransaction(1, "Dzhano", "Peter", 100, TransactionStatus.Aborted);
            chainblock.Add(transaction);

            Assert.That(chainblock.Contains(transaction), Is.True, "Cannot find existing transaction.");
        }

        [Test]
        [TestCase(0, "Dzhano", "Peter")]
        [TestCase(1, "Djano", "Peter")]
        [TestCase(1, "Dzhano", "Ivan")]
        public void Contains_ReturnsFalse_WhenTransactionDoesNotExist(int id, string from, string to)
        {
            ITransaction transaction = CreateTransaction(id, from, to, 100, TransactionStatus.Failed);
            chainblock.Add(transaction);

            Assert.That(chainblock.Contains(CreateTransaction(1, "Dzhano", "Peter", 100, TransactionStatus.Failed)),
                Is.False, "Finds notexisting transaction.");
        }

        [Test]
        public void Count()
        {
            Assert.That(chainblock.Count, Is.EqualTo(0));
        }

        [Test]
        public void ChangeTransactionStatus_Successfull()
        {
            ITransaction transaction = CreateTransaction(0, "Dzhano", "Peter", 100, TransactionStatus.Successfull);
            chainblock.Add(transaction);

            chainblock.ChangeTransactionStatus(0, TransactionStatus.Aborted);

            Assert.That(transaction.Status, Is.EqualTo(TransactionStatus.Aborted), "Doesn't change the transaction's status.");
        }

        [Test]
        public void ChangeTransactionStatus_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(1, TransactionStatus.Aborted),
                "Changes the status of unexisting transaction.");
        }

        [Test]
        public void RemoveTransactionById_Successfull()
        {
            ITransaction transaction = CreateTransaction(1, "Dzhano", "Ivam", 100, TransactionStatus.Unauthorized);

            chainblock.Add(transaction);
            chainblock.RemoveTransactionById(transaction.Id);

            Assert.That(chainblock.Count, Is.Zero, "Doesn't remove transaction by given id.");
            Assert.That(chainblock.Contains(transaction.Id), Is.False, "Doesn't remove transaction by given id.");
        }

        [Test]
        public void RemoveTransactionById_ThrowsInvalidOperationException_WhenIdDoesNotExist()
        {
            /*ITransaction transaction = CreateTransaction(17, "Dzhano", "Receiver", 100, TransactionStatus.Aborted);
            chainblock.Add(transaction);*/

            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(1), "Removes transaction that doesn't exist.");
        }

        [Test]
        public void GetById_Successfull()
        {
            ITransaction transaction = CreateTransaction(17, "Dzhano", "Receiver", 100, TransactionStatus.Aborted);
            chainblock.Add(transaction);

            ITransaction gottenTransaction = chainblock.GetById(transaction.Id);

            Assert.That(transaction, Is.EqualTo(gottenTransaction));
            Assert.That(transaction.Id, Is.EqualTo(gottenTransaction.Id));
            Assert.That(transaction.Amount, Is.EqualTo(gottenTransaction.Amount));
            Assert.That(transaction.From, Is.EqualTo(gottenTransaction.From));
            Assert.That(transaction.Status, Is.EqualTo(gottenTransaction.Status));
            Assert.That(transaction.To, Is.EqualTo(gottenTransaction.To));
        }

        [Test]
        public void GetById_ThrowsInvalidOperationException_WhenIdDoesNotExist()
        {
            /*ITransaction transaction = CreateTransaction(17, "Dzhano", "Receiver", 100, TransactionStatus.Aborted);
            chainblock.Add(transaction);*/

            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(1), "Gets transaction that doesn't exist.");
        }

        [Test]
        public void GetByTransactionStatus_Successfull()
        {
            AddBulkOfTransactions();

            TransactionStatus statusFilter = TransactionStatus.Successfull;
            List<ITransaction> expected = chainblock
                .Where(t => t.Status == statusFilter)
                .OrderByDescending(t => t.Amount)
                .ToList();
            List<ITransaction> actual = chainblock.GetByTransactionStatus(statusFilter).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetByTransactionStatus_ThrowsInvalidOperationException()
        {
            AddThreeTransactionsWithDifferentStatus_ExceptFailed();

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Failed)
            , "Gets unexisting transaction with different status.");
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_Successfull()
        {
            AddBulkOfTransactions();

            TransactionStatus statusFilter = TransactionStatus.Successfull;
            List<string> expected = chainblock
                .Where(t => t.Status == statusFilter)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();
            List<string> actual = chainblock.GetAllSendersWithTransactionStatus(statusFilter).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ThrowsInvalidOperationException_WhenTransactionDoesNotExistWithStatus()
        {
            AddThreeTransactionsWithDifferentStatus_ExceptFailed();

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed)
            , "Gets unexisting transaction's senders.");
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_Successfull()
        {
            AddBulkOfTransactions();

            TransactionStatus statusFilter = TransactionStatus.Successfull;
            List<string> expected = chainblock
                .Where(t => t.Status == statusFilter)
                .OrderBy(t => t.Amount)
                .Select(t => t.To)
                .ToList();
            List<string> actual = chainblock.GetAllReceiversWithTransactionStatus(statusFilter).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ThrowsInvalidOperationException_WhenTransactionDoesNotExistWithStatus()
        {
            AddThreeTransactionsWithDifferentStatus_ExceptFailed();

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed)
            , "Gets unexisting transaction's receivers.");
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_Successfull()
        {
            AddBulkOfTransactions();

            List<ITransaction> expected = chainblock
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();
            List<ITransaction> actual = chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }
        
        /*[Test]
        public void GetAllOrderedByAmountDescendingThenById_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllOrderedByAmountDescendingThenById());
        }*/

        [Test]
        public void GetBySenderOrderedByAmountDescending_Successfull()
        {
            AddBulkOfTransactions();
            
            string sender = "From";

            IEnumerable<ITransaction> expected = chainblock
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount);
            IEnumerable<ITransaction> actual = chainblock.GetBySenderOrderedByAmountDescending(sender);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ThrowsInvalidOperationException()
        {
            AddBulkOfTransactions();
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("Dzhano"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_Successfull()
        {
            AddBulkOfTransactions();

            string receiver = "Hristo";

            IEnumerable<ITransaction> expected = chainblock
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
            IEnumerable<ITransaction> actual = chainblock.GetByReceiverOrderedByAmountThenById(receiver);

            double prevAmount = double.PositiveInfinity;
            int id = 0;

            Assert.That(expected, Is.EquivalentTo(actual));
            foreach (ITransaction transaction in actual)
            {
                Assert.That(transaction.To, Is.EqualTo(receiver));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(prevAmount));

                if (transaction.Amount == prevAmount)
                    Assert.That(transaction.Id, Is.GreaterThan(id));

                id = transaction.Id;
                prevAmount = transaction.Amount;
            }
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ThrowsInvalidOperationException()
        {
            AddBulkOfTransactions();
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("Peter"));
        }

        [Test]
        [TestCase(100)]
        [TestCase(145)]
        [TestCase(200)]
        public void GetByTransactionStatusAndMaximumAmount_Successfull_ReturnsFilteredChainblock(double amountFilter)
        {
            AddBulkOfTransactions();

            TransactionStatus statusFilter = TransactionStatus.Failed;

            IEnumerable<ITransaction> expected = chainblock
                .Where(t => t.Status == statusFilter)
                .Where(t => t.Amount <= amountFilter)
                .OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> actual = chainblock.GetByTransactionStatusAndMaximumAmount(statusFilter, amountFilter);

            double prevAmount = double.PositiveInfinity;
            
            Assert.That(expected, Is.EquivalentTo(actual));
            foreach (ITransaction transaction in actual)
            {
                Assert.That(transaction.Status, Is.EqualTo(statusFilter));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(prevAmount));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(amountFilter));

                prevAmount = transaction.Amount;
            }
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_Successfull_ReturnsEmptyCollection_WhenStatusIsNotValid()
        {
            AddThreeTransactionsWithDifferentStatus_ExceptFailed();

            Assert.That(() => chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 100)
            , Is.EquivalentTo(new List<ITransaction>()));
        }
        
        [Test]
        public void GetByTransactionStatusAndMaximumAmount_Successfull_ReturnsEmptyCollection_WhenAmountIsNotValid()
        {
            AddBulkOfTransactions();

            Assert.That(() => chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 95)
            , Is.EquivalentTo(new List<ITransaction>()));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_Successfull_ReturnsFilteredChainblock()
        {
            AddBulkOfTransactions();

            string senderFilter = "From";
            double amountFilter = 0;

            IEnumerable<ITransaction> expected = chainblock
                .Where(t => t.From == senderFilter)
                .Where(t => t.Amount > amountFilter)
                .OrderByDescending(t => t.Amount);

            IEnumerable<ITransaction> actual = chainblock.GetBySenderAndMinimumAmountDescending(senderFilter, amountFilter);

            double prevAmount = double.PositiveInfinity;

            Assert.That(expected, Is.EquivalentTo(actual));
            foreach (ITransaction transaction in actual)
            {
                Assert.That(transaction.From, Is.EqualTo(senderFilter));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(prevAmount));
                Assert.That(transaction.Amount, Is.GreaterThan(amountFilter));

                prevAmount = transaction.Amount;
            }
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsException_WhenNoSuchSenderExist()
        {
            AddBulkOfTransactions();

            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("Dzhano", 120));
        }
        
        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsException_WhenAmountIsNotValid()
        {
            AddBulkOfTransactions();

            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("From", 201));
        }

        [Test]
        public void GetByReceiverAndAmountRange_Successfull()
        {
            AddBulkOfTransactions();

            string receiver = "Gosho";
            int lo = 120;
            int hi = 190;

            IEnumerable<ITransaction> expected = chainblock
                .Where(t => t.To == receiver)
                .Where(t => t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
            IEnumerable<ITransaction> actual = chainblock.GetByReceiverAndAmountRange(receiver, lo, hi);

            double prevAmount = double.PositiveInfinity;
            int id = 0;

            Assert.That(expected, Is.EquivalentTo(actual));
            foreach (ITransaction transaction in actual)
            {
                Assert.That(transaction.To, Is.EqualTo(receiver));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(prevAmount));
                Assert.That(transaction.Amount, Is.LessThan(hi));
                Assert.That(transaction.Amount, Is.GreaterThanOrEqualTo(lo));

                if (transaction.Amount == prevAmount)
                    Assert.That(transaction.Id, Is.GreaterThan(id));

                id = transaction.Id;
                prevAmount = transaction.Amount;
            }
        }

        [Test]
        public void GetByReceiverAndAmountRange_ThrowsInvalidOperationException_WhenNoSuchReceiverExist()
        {
            AddBulkOfTransactions();
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Peter", 100, 350));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ThrowsInvalidOperationException_WhenLoIsTooHigh()
        {
            AddBulkOfTransactions();
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Dzhano", 201, 200));
        }
        
        [Test]
        public void GetByReceiverAndAmountRange_ThrowsInvalidOperationException_WhenHiIsTooLow()
        {
            AddBulkOfTransactions();
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("Dzhano", 130, 60));
        }

        [Test]
        public void GetAllInAmountRange_Successfull()
        {
            AddBulkOfTransactions();

            int lo = 120;
            int hi = 190;

            IEnumerable<ITransaction> expected = chainblock.Where(t => t.Amount >= lo && t.Amount <= hi);
            IEnumerable<ITransaction> actual = chainblock.GetAllInAmountRange(lo, hi);

            double prevAmount = double.NegativeInfinity;

            Assert.That(expected, Is.EquivalentTo(actual));
            foreach (ITransaction transaction in actual)
            {
                Assert.That(transaction.Amount, Is.GreaterThan(prevAmount));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(hi));
                Assert.That(transaction.Amount, Is.GreaterThanOrEqualTo(lo));

                prevAmount = transaction.Amount;
            }
        }
        
        [Test]
        [TestCase(120, 30)]
        [TestCase(201, 200)]
        public void GetAllInAmountRange_ReturnsEmptyChainblockCollection__When_LoIsTooHigh_Or_HiIsTooLow(int lo, int hi)
        {
            AddBulkOfTransactions();
            IEnumerable<ITransaction> transactions = chainblock.GetAllInAmountRange(lo, hi);
            Assert.That(transactions.Count(), Is.Zero);
        }


        private void AddBulkOfTransactions()
        {
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                string to = "Dzhano";

                TransactionStatus transactionStatus = TransactionStatus.Successfull;
                if (i % 2 == 0)
                {
                    transactionStatus = TransactionStatus.Unauthorized;
                    to = "Hristo";
                }
                else if (i % 3 == 0)
                {
                    transactionStatus = TransactionStatus.Aborted;
                    to = "Gosho";
                }
                else if (i % 5 == 0)
                {
                    transactionStatus = TransactionStatus.Failed;
                    to = "Ivan";
                }

                string sender = i % 3 == 0 ? $"Sender{i}" : "From";
                int amount = i % 2 == 0 ? 100 : 100 + i;

                ITransaction transaction = CreateTransaction(n - i, sender, to, amount, transactionStatus);

                chainblock.Add(transaction);
            }
        }

        private void AddThreeTransactionsWithDifferentStatus_ExceptFailed()
        {
            chainblock.Add(CreateTransaction(1, "From", "To", 20, TransactionStatus.Aborted));
            chainblock.Add(CreateTransaction(2, "Sender", "Receiver", 20, TransactionStatus.Successfull));
            chainblock.Add(CreateTransaction(3, "Dzhano", "Gosho", 20, TransactionStatus.Unauthorized));
        }

        private Transaction CreateTransaction(int id, string from, string to, int amount, TransactionStatus status)
        {
            return new Transaction()
            {
                Id = id,
                From = from,
                To = to,
                Amount = amount,
                Status = status
            };
        }
    }
}

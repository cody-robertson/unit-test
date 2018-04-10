﻿/**
 * File: UnitTest1.cs
 * Description: A suite of unit tests for testing the BankAccount class in Class1.cs
 * Author: Cody Robertson
 * Date: 4/10/2018
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {
        // unit test code  
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        //unit test method  
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

 
            try
            {
                // act
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        //unit test method  
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                // act
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
        
        //unit test method
        [TestMethod]
        public void CreditWhenAccountIsFrozen_ShouldThrowException()
        {
            //arange
            double beginningBalance = 11.99;
            double creditAmount = 10.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            account.FreezeAccount();

            try
            {
                //act
                account.Credit(creditAmount);
            }
            catch (Exception e)
            {
                // assert
                StringAssert.Contains(e.Message, "Account frozen");
                return;
            }
            Assert.Fail("No exception was thrown.");
        }

        // unit test method
        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            //arrange
            double beginningBalance = 11.99;
            double creditAmount = -10.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                //act
                account.Credit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return;
            }

            Assert.Fail("No exception was thrown.");
        }
        
        // unit test method
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            //arrange
            double beginningBalance = 11.99;
            double creditAmount = 12.01;
            double expected = 24.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Credit(creditAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }
    }
}

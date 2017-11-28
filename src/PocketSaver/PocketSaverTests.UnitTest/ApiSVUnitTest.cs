using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocketSaver.Services;
using System.Collections.ObjectModel;
using PocketSaver.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PocketSaverTests.UnitTest
{
    /// <summary>
    /// Class for testing the ApiSV using UnitTests
    /// </summary>
    [TestClass]
    public class ApiSVUnitTest
    {
        public static ObservableCollection<TransactionModel> transactionDatum = new ObservableCollection<TransactionModel>(); //Setting a global observable collection

        [TestMethod]
        public async System.Threading.Tasks.Task TestGetAsync()
        {
            //Arrange
            ApiSV sv = new ApiSV();
            transactionDatum.Clear();
            sv.url = sv.UrlBuilder(sv.QueryBuilder("{}", "&sort=Date&dir=-1"));
            TransactionModel obj = new TransactionModel();
            obj.Category = "Food";
            obj.Comment = "Sandwhich";
            obj.Date = Convert.ToDateTime("11-19-2017");
            obj.PurchaseAmount = Decimal.Parse("5.99");

            //Act
            try
            {
                List<TransactionModel> allData = await sv.Get<List<TransactionModel>>();

                foreach (var x in allData) { transactionDatum.Add(x); }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(Convert.ToString(ex.Message));

            }

            //Assert
            Assert.IsTrue(transactionDatum.Count != 0); //Means that there is data from the Api Get call.
            Assert.IsTrue(sv.Get<List<TransactionModel>>().IsCompleted);
            //Assert.IsTrue(obj.Category.Equals(transactionDatum[3].Category)); //Makes sure that we are receiving same Objects from database in that order
            //Assert.IsTrue(obj.Comment.Equals(transactionDatum[3].Comment));
            //Assert.IsTrue(obj.Date.Equals(transactionDatum[3].Date));
            //Assert.IsTrue(obj.PurchaseAmount.Equals(transactionDatum[3].PurchaseAmount));
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestPostAsync()
        {
            //Arrange
            ApiSV sv = new ApiSV();
            sv.url = sv.UrlBuilder(sv.QueryBuilder("{}", "&sort=Date&dir=-1"));
            TransactionModel obj = new TransactionModel();
            obj.Category = "Test";
            obj.Comment = "Sometest";
            obj.Date = Convert.ToDateTime("01-22-1997");
            obj.PurchaseAmount = Decimal.Parse("50.00");
            sv.HttpBodyBuilder<TransactionModel>(obj);

            //Act
            try
            {
                await sv.Post<TransactionModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(Convert.ToString(ex.Message));

            }

            //Assert
            Assert.IsTrue(transactionDatum.Count != 0); //Means that there is data from the Api Get call.
            Assert.IsTrue(sv.Post<TransactionModel>().IsCompleted); //Means that Post method was completed
            
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestPutAsync()
        {
            //Arrange
            ApiSV sv = new ApiSV();
            string id = transactionDatum[0]._id;
            sv.url = sv.UrlBuilder("/" + id);
            TransactionModel obj = new TransactionModel();
            obj.Category = "Testing put";
            obj.Comment = transactionDatum[0].Comment;
            obj.Date = transactionDatum[0].Date;
            obj.PurchaseAmount = transactionDatum[0].PurchaseAmount;
            sv.HttpBodyBuilder<TransactionModel>(obj);

            //Act
            try
            {
                await sv.Post<TransactionModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(Convert.ToString(ex.Message));

            }

            //Assert
            Assert.IsTrue(transactionDatum.Count != 0); //Means that there is data from the Api Get call.
            Assert.IsTrue(sv.Put<TransactionModel>().IsCompleted); //Means that Post method was completed
            //Assert.IsTrue(transactionDatum[0].Category.Equals("Testing put"));

        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestDeleteAsync()
        {
            //Arrange
            ApiSV sv = new ApiSV();
            string id = transactionDatum.Last()._id;
            sv.url = sv.UrlBuilder("/" + id);

            //Act
            try
            {
                await sv.Delete<TransactionModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(Convert.ToString(ex.Message));

            }

            //Assert
            Assert.IsTrue(transactionDatum.Count != 0); //Means that there is data from the Api Get call.
            Assert.IsTrue(sv.Delete<TransactionModel>().IsCompleted); //Means that Post method was completed
            //Assert.IsTrue(transactionDatum[0].Category.Equals("Testing put"));

        }
    }
}

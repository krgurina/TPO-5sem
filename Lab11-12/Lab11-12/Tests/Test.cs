using Lab11_12.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_12.Tests
{
    public class Test
    {
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        //1
        [Test]
        public void FindClassics()
        {
            steps.GoToBooksPage();
            steps.SelectLiterature();
            steps.SelectClassics();
        }


        //2
        [Test]
        public void AddItemToBasket()
        {
            steps.OpenClassics();
            steps.AddToBacket();
        }

        //3
        [Test]
        public void AddItemToBasketWithAuthFail()
        {
            steps.OpenClassics();
            steps.AddToBacket();
            steps.OpenLogin();
            steps.LogIn();
        }

        //4
        [Test]
        public void ChangeCountBasket()
        {
            steps.OpenLogin();
            steps.LogInSucsess();
            steps.OpenBacket();
            steps.ChangeCount();
        }

        //5
        [Test]
        public void SelectBasketItems()
        {
            steps.OpenLogin();
            steps.LogInSucsess();
            steps.OpenBacket();
            steps.SelectBasketItems();
            steps.InputCode();
        }


        //6 
        [Test]
        public void FindItem()
        {
            steps.OpenHome();
            steps.Search();
        }

        //7
        [Test]
        public void FindItemWithPriceFilter()
        {
            steps.OpenHome();
            steps.Search();
            steps.PriceFilter();
        }

        //8
        [Test]
        public void FindItemWithSortResults()
        {
            steps.OpenHome();
            steps.Search();
            steps.SortResults();
        }

        //9
        [Test]
        public void FindBonusProgram()
        {
            steps.OpenHome();
            steps.AcceptCookies();
            steps.FindBonus();
            steps.GetBonusInfo();
        }

        [Test]
        public void ChooseOrderDetails()
        {
            steps.OpenLogin();
            steps.LogInSucsess();
            steps.OpenBacket();
            steps.ChooseOrderDetails();

        }



    }
}

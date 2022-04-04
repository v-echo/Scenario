using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Implementation2.SqlTests
{
    [TestClass()]
    public class DivideFunctionUnitTest : SqlDatabaseTestClass
    {

        public DivideFunctionUnitTest()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_DivideTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DivideFunctionUnitTest));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition testForMultipleOf3And5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition testForMultipleOf5;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition testForMultipleOf3;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition testForOther;
            this.dbo_DivideTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_DivideTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            testForMultipleOf3And5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            testForMultipleOf5 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            testForMultipleOf3 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            testForOther = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // dbo_DivideTest_TestAction
            // 
            dbo_DivideTest_TestAction.Conditions.Add(testForMultipleOf3And5);
            dbo_DivideTest_TestAction.Conditions.Add(testForMultipleOf5);
            dbo_DivideTest_TestAction.Conditions.Add(testForMultipleOf3);
            dbo_DivideTest_TestAction.Conditions.Add(testForOther);
            resources.ApplyResources(dbo_DivideTest_TestAction, "dbo_DivideTest_TestAction");
            // 
            // testForMultipleOf3And5
            // 
            testForMultipleOf3And5.ColumnNumber = 1;
            testForMultipleOf3And5.Enabled = true;
            testForMultipleOf3And5.ExpectedValue = "first last";
            testForMultipleOf3And5.Name = "testForMultipleOf3And5";
            testForMultipleOf3And5.NullExpected = false;
            testForMultipleOf3And5.ResultSet = 1;
            testForMultipleOf3And5.RowNumber = 1;
            // 
            // dbo_DivideTestData
            // 
            this.dbo_DivideTestData.PosttestAction = null;
            this.dbo_DivideTestData.PretestAction = null;
            this.dbo_DivideTestData.TestAction = dbo_DivideTest_TestAction;
            // 
            // testForMultipleOf5
            // 
            testForMultipleOf5.ColumnNumber = 1;
            testForMultipleOf5.Enabled = true;
            testForMultipleOf5.ExpectedValue = "last";
            testForMultipleOf5.Name = "testForMultipleOf5";
            testForMultipleOf5.NullExpected = false;
            testForMultipleOf5.ResultSet = 2;
            testForMultipleOf5.RowNumber = 1;
            // 
            // testForMultipleOf3
            // 
            testForMultipleOf3.ColumnNumber = 1;
            testForMultipleOf3.Enabled = true;
            testForMultipleOf3.ExpectedValue = "first";
            testForMultipleOf3.Name = "testForMultipleOf3";
            testForMultipleOf3.NullExpected = false;
            testForMultipleOf3.ResultSet = 3;
            testForMultipleOf3.RowNumber = 1;
            // 
            // testForOther
            // 
            testForOther.ColumnNumber = 1;
            testForOther.Enabled = true;
            testForOther.ExpectedValue = "17";
            testForOther.Name = "testForOther";
            testForOther.NullExpected = false;
            testForOther.ResultSet = 4;
            testForOther.RowNumber = 1;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        [TestMethod()]
        public void dbo_DivideTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_DivideTestData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            try
            {
                // Execute the test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
                SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            }
            finally
            {
                // Execute the post-test script
                // 
                System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
                SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
            }
        }
        private SqlDatabaseTestActions dbo_DivideTestData;
    }
}

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
    public class IterateFunctionUnitTest : SqlDatabaseTestClass
    {

        public IterateFunctionUnitTest()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_IterateTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IterateFunctionUnitTest));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition mustMatchDataChecksum;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition mustMatchCustomChecksum;
            this.dbo_IterateTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_IterateTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            mustMatchDataChecksum = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition();
            mustMatchCustomChecksum = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // dbo_IterateTestData
            // 
            this.dbo_IterateTestData.PosttestAction = null;
            this.dbo_IterateTestData.PretestAction = null;
            this.dbo_IterateTestData.TestAction = dbo_IterateTest_TestAction;
            // 
            // dbo_IterateTest_TestAction
            // 
            dbo_IterateTest_TestAction.Conditions.Add(mustMatchDataChecksum);
            dbo_IterateTest_TestAction.Conditions.Add(mustMatchCustomChecksum);
            resources.ApplyResources(dbo_IterateTest_TestAction, "dbo_IterateTest_TestAction");
            // 
            // mustMatchDataChecksum
            // 
            mustMatchDataChecksum.Checksum = "157379733";
            mustMatchDataChecksum.Enabled = false;
            mustMatchDataChecksum.Name = "mustMatchDataChecksum";
            // 
            // mustMatchCustomChecksum
            // 
            mustMatchCustomChecksum.ColumnNumber = 1;
            mustMatchCustomChecksum.Enabled = true;
            mustMatchCustomChecksum.ExpectedValue = "9364786759";
            mustMatchCustomChecksum.Name = "mustMatchCustomChecksum";
            mustMatchCustomChecksum.NullExpected = false;
            mustMatchCustomChecksum.ResultSet = 2;
            mustMatchCustomChecksum.RowNumber = 1;
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
        public void dbo_IterateTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_IterateTestData;
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
        private SqlDatabaseTestActions dbo_IterateTestData;
    }
}

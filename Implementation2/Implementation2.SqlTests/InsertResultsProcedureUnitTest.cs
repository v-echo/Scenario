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
    public class InsertResultsProcedureUnitTest : SqlDatabaseTestClass
    {

        public InsertResultsProcedureUnitTest()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_InsertResultsTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertResultsProcedureUnitTest));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition resultsRowCountMustBe100;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition mustMatchDataChecksum;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition mustMatchCustomChecksum;
            this.dbo_InsertResultsTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_InsertResultsTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            resultsRowCountMustBe100 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            mustMatchDataChecksum = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition();
            mustMatchCustomChecksum = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // dbo_InsertResultsTestData
            // 
            this.dbo_InsertResultsTestData.PosttestAction = null;
            this.dbo_InsertResultsTestData.PretestAction = null;
            this.dbo_InsertResultsTestData.TestAction = dbo_InsertResultsTest_TestAction;
            // 
            // dbo_InsertResultsTest_TestAction
            // 
            dbo_InsertResultsTest_TestAction.Conditions.Add(resultsRowCountMustBe100);
            dbo_InsertResultsTest_TestAction.Conditions.Add(mustMatchDataChecksum);
            dbo_InsertResultsTest_TestAction.Conditions.Add(mustMatchCustomChecksum);
            resources.ApplyResources(dbo_InsertResultsTest_TestAction, "dbo_InsertResultsTest_TestAction");
            // 
            // resultsRowCountMustBe100
            // 
            resultsRowCountMustBe100.Enabled = true;
            resultsRowCountMustBe100.Name = "resultsRowCountMustBe100";
            resultsRowCountMustBe100.ResultSet = 1;
            resultsRowCountMustBe100.RowCount = 100;
            // 
            // mustMatchDataChecksum
            // 
            mustMatchDataChecksum.Checksum = "-1197816306";
            mustMatchDataChecksum.Enabled = false;
            mustMatchDataChecksum.Name = "mustMatchDataChecksum";
            // 
            // mustMatchCustomChecksum
            // 
            mustMatchCustomChecksum.ColumnNumber = 1;
            mustMatchCustomChecksum.Enabled = true;
            mustMatchCustomChecksum.ExpectedValue = "23366112477";
            mustMatchCustomChecksum.Name = "mustMatchCustomChecksum";
            mustMatchCustomChecksum.NullExpected = false;
            mustMatchCustomChecksum.ResultSet = 3;
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
        public void dbo_InsertResultsTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_InsertResultsTestData;
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
        private SqlDatabaseTestActions dbo_InsertResultsTestData;
    }
}

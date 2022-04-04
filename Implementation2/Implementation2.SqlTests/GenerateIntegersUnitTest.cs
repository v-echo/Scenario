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
    public class GenerateIntegersUnitTest : SqlDatabaseTestClass
    {

        public GenerateIntegersUnitTest()
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
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction dbo_GenerateIntegersTest_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateIntegersUnitTest));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition mustReturn100Rows;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition mustMatchDataChecksum;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition sumMustEqualScalar;
            this.dbo_GenerateIntegersTestData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            dbo_GenerateIntegersTest_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            mustReturn100Rows = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.RowCountCondition();
            mustMatchDataChecksum = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ChecksumCondition();
            sumMustEqualScalar = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // dbo_GenerateIntegersTest_TestAction
            // 
            dbo_GenerateIntegersTest_TestAction.Conditions.Add(mustReturn100Rows);
            dbo_GenerateIntegersTest_TestAction.Conditions.Add(mustMatchDataChecksum);
            dbo_GenerateIntegersTest_TestAction.Conditions.Add(sumMustEqualScalar);
            resources.ApplyResources(dbo_GenerateIntegersTest_TestAction, "dbo_GenerateIntegersTest_TestAction");
            // 
            // mustReturn100Rows
            // 
            mustReturn100Rows.Enabled = true;
            mustReturn100Rows.Name = "mustReturn100Rows";
            mustReturn100Rows.ResultSet = 1;
            mustReturn100Rows.RowCount = 100;
            // 
            // mustMatchDataChecksum
            // 
            mustMatchDataChecksum.Checksum = "-539136787";
            mustMatchDataChecksum.Enabled = false;
            mustMatchDataChecksum.Name = "mustMatchDataChecksum";
            // 
            // dbo_GenerateIntegersTestData
            // 
            this.dbo_GenerateIntegersTestData.PosttestAction = null;
            this.dbo_GenerateIntegersTestData.PretestAction = null;
            this.dbo_GenerateIntegersTestData.TestAction = dbo_GenerateIntegersTest_TestAction;
            // 
            // sumMustEqualScalar
            // 
            sumMustEqualScalar.ColumnNumber = 1;
            sumMustEqualScalar.Enabled = true;
            sumMustEqualScalar.ExpectedValue = "5050";
            sumMustEqualScalar.Name = "sumMustEqualScalar";
            sumMustEqualScalar.NullExpected = false;
            sumMustEqualScalar.ResultSet = 2;
            sumMustEqualScalar.RowNumber = 1;
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
        public void dbo_GenerateIntegersTest()
        {
            SqlDatabaseTestActions testActions = this.dbo_GenerateIntegersTestData;
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
        private SqlDatabaseTestActions dbo_GenerateIntegersTestData;
    }
}

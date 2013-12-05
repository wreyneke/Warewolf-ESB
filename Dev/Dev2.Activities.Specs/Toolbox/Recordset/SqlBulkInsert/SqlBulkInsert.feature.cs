﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18052
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.Toolbox.Recordset.SqlBulkInsert
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SqlBulkInsertFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SqlBulkInsert.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SqlBulkInsert", "In order to quickly insert large amounts of data in a sql server database\r\nAs a W" +
                    "arewolf user\r\nI want a tool that performs this action", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "SqlBulkInsert")))
            {
                Dev2.Activities.Specs.Toolbox.Recordset.SqlBulkInsert.SqlBulkInsertFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Import data into table with check contraint disabled")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlBulkInsert")]
        public virtual void ImportDataIntoTableWithCheckContraintDisabled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Import data into table with check contraint disabled", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table1.AddRow(new string[] {
                        "1",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table1.AddRow(new string[] {
                        "1",
                        "TestData",
                        "b89416b9-5b24-4f95-bd11-25d9db8160a2"});
#line 7
 testRunner.Given("I have this data", ((string)(null)), table1, "Given ");
#line 11
 testRunner.And("Check constraints is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("the tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table2.AddRow(new string[] {
                        "1",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table2.AddRow(new string[] {
                        "2",
                        "TestData",
                        "b89416b9-5b24-4f95-bd11-25d9db8160a2"});
#line 13
 testRunner.Then("the new table will have", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Import data into Table with check contraint enabled")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlBulkInsert")]
        public virtual void ImportDataIntoTableWithCheckContraintEnabled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Import data into Table with check contraint enabled", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table3.AddRow(new string[] {
                        "1",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table3.AddRow(new string[] {
                        "1",
                        "TestData",
                        "b89416b9-5b24-4f95-bd11-25d9db8160a2"});
#line 19
 testRunner.Given("I have this data", ((string)(null)), table3, "Given ");
#line 23
 testRunner.And("Check constraints is enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.When("the tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("the new table will will have 0 of rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Import data into Table with keep identity disabled")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlBulkInsert")]
        public virtual void ImportDataIntoTableWithKeepIdentityDisabled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Import data into Table with keep identity disabled", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table4.AddRow(new string[] {
                        "4",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table4.AddRow(new string[] {
                        "6",
                        "TestData",
                        "bc7a9611-102e-4899-82b8-97ff1517d268"});
            table4.AddRow(new string[] {
                        "8",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
#line 28
 testRunner.Given("I have this data", ((string)(null)), table4, "Given ");
#line 33
 testRunner.And("Keep identity is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.When("the tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table5.AddRow(new string[] {
                        "1",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table5.AddRow(new string[] {
                        "2",
                        "TestData",
                        "bc7a9611-102e-4899-82b8-97ff1517d268"});
            table5.AddRow(new string[] {
                        "3",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
#line 35
 testRunner.Then("the new table will have", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Import data into Table with keep identity enabled")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlBulkInsert")]
        public virtual void ImportDataIntoTableWithKeepIdentityEnabled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Import data into Table with keep identity enabled", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table6.AddRow(new string[] {
                        "4",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table6.AddRow(new string[] {
                        "6",
                        "TestData",
                        "bc7a9611-102e-4899-82b8-97ff1517d268"});
            table6.AddRow(new string[] {
                        "8",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
#line 42
 testRunner.Given("I have this data", ((string)(null)), table6, "Given ");
#line 47
 testRunner.And("Keep identity is enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.When("the tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table7.AddRow(new string[] {
                        "4",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table7.AddRow(new string[] {
                        "6",
                        "TestData",
                        "bc7a9611-102e-4899-82b8-97ff1517d268"});
            table7.AddRow(new string[] {
                        "8",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
#line 49
 testRunner.Then("the new table will have", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Import data into Table with skip blank rows disabled")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlBulkInsert")]
        public virtual void ImportDataIntoTableWithSkipBlankRowsDisabled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Import data into Table with skip blank rows disabled", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table8.AddRow(new string[] {
                        "1",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table8.AddRow(new string[] {
                        "",
                        "",
                        ""});
            table8.AddRow(new string[] {
                        "2",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table8.AddRow(new string[] {
                        "3",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
#line 57
testRunner.Given("I have this data", ((string)(null)), table8, "Given ");
#line 63
 testRunner.And("Skip rows is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("the tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.Then("the new table will will have 0 of rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Import data into Table with skip blank rows enabled")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlBulkInsert")]
        public virtual void ImportDataIntoTableWithSkipBlankRowsEnabled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Import data into Table with skip blank rows enabled", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table9.AddRow(new string[] {
                        "1",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table9.AddRow(new string[] {
                        "",
                        "",
                        ""});
            table9.AddRow(new string[] {
                        "2",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table9.AddRow(new string[] {
                        "3",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
#line 69
testRunner.Given("I have this data", ((string)(null)), table9, "Given ");
#line 75
 testRunner.And("Skip rows is enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.When("the tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
 testRunner.Then("the new table will will have 3 of rows", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Import data into Table with fire triggers disabled")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlBulkInsert")]
        public virtual void ImportDataIntoTableWithFireTriggersDisabled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Import data into Table with fire triggers disabled", ((string[])(null)));
#line 79
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table10.AddRow(new string[] {
                        "1",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table10.AddRow(new string[] {
                        "2",
                        "",
                        "b89416b9-5b24-4f95-bd11-25d9db8160a2"});
            table10.AddRow(new string[] {
                        "3",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
#line 81
testRunner.Given("I have this data", ((string)(null)), table10, "Given ");
#line 86
 testRunner.And("Fire triggers is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.When("the tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table11.AddRow(new string[] {
                        "1",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table11.AddRow(new string[] {
                        "2",
                        "",
                        "b89416b9-5b24-4f95-bd11-25d9db8160a2"});
            table11.AddRow(new string[] {
                        "3",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
#line 88
 testRunner.Then("the new table will have", ((string)(null)), table11, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Import data into Table with fire triggers enabled")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlBulkInsert")]
        public virtual void ImportDataIntoTableWithFireTriggersEnabled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Import data into Table with fire triggers enabled", ((string[])(null)));
#line 94
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table12.AddRow(new string[] {
                        "1",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table12.AddRow(new string[] {
                        "2",
                        "",
                        "b89416b9-5b24-4f95-bd11-25d9db8160a2"});
            table12.AddRow(new string[] {
                        "3",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
#line 96
testRunner.Given("I have this data", ((string)(null)), table12, "Given ");
#line 101
 testRunner.And("Fire triggers is enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.When("the tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Col1",
                        "Col2",
                        "Col3"});
            table13.AddRow(new string[] {
                        "1",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
            table13.AddRow(new string[] {
                        "2",
                        "XXXXXXXX",
                        "b89416b9-5b24-4f95-bd11-25d9db8160a2"});
            table13.AddRow(new string[] {
                        "3",
                        "TestData",
                        "279c690e-3304-47a0-8bde-5d3ca2520a34"});
#line 103
 testRunner.Then("the new table will have", ((string)(null)), table13, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

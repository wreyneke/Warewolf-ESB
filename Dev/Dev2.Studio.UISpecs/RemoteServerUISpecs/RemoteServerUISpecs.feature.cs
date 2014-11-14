﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Studio.UI.Specs.RemoteServerUISpecs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class RemoteServerUISpecsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RemoteServerUISpecs.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RemoteServerUISpecs", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "RemoteServerUISpecs")))
            {
                Dev2.Studio.UI.Specs.RemoteServerUISpecs.RemoteServerUISpecsFeature.FeatureSetup(null);
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
        
        public virtual void FeatureBackground()
        {
#line 7
#line 8
      testRunner.Given("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
   testRunner.And("I click \"EXPLORER,UI_localhost_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
   testRunner.When("I click \"RIBBONSETTINGS\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
   testRunner.And("I clear table \"ACTIVETAB,UI_SettingsView_AutoID,SecurityViewContent,ServerPermiss" +
                    "ionsDataGrid\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
   testRunner.And("I clear table \"ACTIVETAB,UI_SettingsView_AutoID,SecurityViewContent,ResourcePermi" +
                    "ssionsDataGrid\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
   testRunner.And("\"SECURITYPUBLICADMINISTRATOR\" is unchecked", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
   testRunner.And("I click \"SECURITYPUBLICADMINISTRATOR\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
      testRunner.And("I click \"SECURITYSAVE\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
   testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Testing Remote Server Connection Creating Remote Workflow and Executing")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RemoteServerUISpecs")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RemtoeServer")]
        public virtual void TestingRemoteServerConnectionCreatingRemoteWorkflowAndExecuting()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Testing Remote Server Connection Creating Remote Workflow and Executing", new string[] {
                        "RemtoeServer"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 21
    testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
    testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
    testRunner.Given("I click \"EXPLORER,UI_localhost_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Address",
                        "AuthType",
                        "UserName",
                        "Password"});
            table1.AddRow(new string[] {
                        "http://localhost:3142",
                        "Public",
                        "",
                        ""});
#line 24
       testRunner.Given("I create a new remote connection \"Test\" as", ((string)(null)), table1, "Given ");
#line 28
       testRunner.Given("I click \"EXPLORER,UI_Test (http://localhost:3142/)_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
    testRunner.Given("I send \"Decision Testing\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
    testRunner.Given("I click \"EXPLORER,UI_Test (http://localhost:3142/)_AutoID,UI_Integration Test Res" +
                    "ources_AutoID,UI_Decision Testing_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
       testRunner.Then("\"EXPLORER,UI_Test (http://localhost:3142/)_AutoID,UI_Acceptance Testing Resources_A" +
                    "utoID,UI_Decision Testing_AutoID,UI_CanEdit_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
       testRunner.Then("\"EXPLORER,UI_Test (http://localhost:3142/)_AutoID,UI_Acceptance Testing Resources_A" +
                    "utoID,UI_Decision Testing_AutoID,UI_CanExecute_AutoID\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
    testRunner.Given("I double click \"EXPLORER,UI_Test (http://localhost:3142/)_AutoID,UI_Integration T" +
                    "est Resources_AutoID,UI_Decision Testing_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
    testRunner.Given("\"WORKFLOWDESIGNER,Decision Testing(FlowchartDesigner)\" is visible within \"5\" seco" +
                    "nds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
    testRunner.Given("I click \"EXPLORER,UI_localhost_AutoID,UI_Acceptance Testing Resources_AutoID,UI_Dec" +
                    "ision Testing_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
    testRunner.Given("I double click \"EXPLORER,UI_localhost_AutoID,UI_Acceptance Testing Resources_AutoID" +
                    ",UI_Decision Testing_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
    testRunner.Given("\"WORKFLOWDESIGNER,Decision Testing(FlowchartDesigner)\" is visible within \"5\" seco" +
                    "nds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
    testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
    testRunner.Given("I click \"EXPLORER,UI_Test (http://localhost:3142/)_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
    testRunner.And("I click \"RIBBONNEWENDPOINT\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
    testRunner.Given("I send \"Assign\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
    testRunner.And("I drag \"TOOLASSIGN\" onto \"WORKSURFACE,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
    testRunner.Given("I send \"rec().a\" to \"WORKSURFACE,Assign (1)(MultiAssignDesigner),SmallViewContent" +
                    ",SmallDataGrid,UI_ActivityGridRow_0_AutoID,UI_TextBox_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
    testRunner.And("I send \"{TAB}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
    testRunner.And("I send \"Warewolf\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
    testRunner.And("I send \"{TAB}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
    testRunner.And("I send \"rec().a{TAB}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
    testRunner.And("I send \"TestRemote{TAB}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
    testRunner.When("I double click point \"5,5\" on \"WORKSURFACE,Assign (2)(MultiAssignDesigner)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
    testRunner.When("I click \"WORKSURFACE,Assign (2)(MultiAssignDesigner),DoneButton\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
    testRunner.Then("\"WORKSURFACE,Assign (2)(MultiAssignDesigner),SmallViewContent\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
       testRunner.Given("I double click \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
       testRunner.Given("I send \"{Delete}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
    testRunner.Given("I send \"Data Merge\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
       testRunner.Given("I drag \"TOOLDATAMERGE\" onto \"WORKSURFACE,Assign (2)(MultiAssignDesigner)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
    testRunner.Given("I send \"[[rec(1).a]]\" to \"TOOLDATAMERGESMALLVIEWGRID,UI__Row1_InputVariable_AutoI" +
                    "D\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
    testRunner.And("I send \"{TAB}{TAB}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
    testRunner.And("I send \"8\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
    testRunner.And("I send \"{TAB}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
    testRunner.And("I send \"[[rec(2).a]]\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
    testRunner.And("I send \"{TAB}{TAB}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
    testRunner.And("I send \"10\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
    testRunner.And("I send \"[[result]]\" to \"WORKSURFACE,Data Merge (2)(DataMergeDesigner),SmallViewCo" +
                    "ntent,UI__Resulttxt_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
    testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
    testRunner.Given("I click \"RIBBONSAVE\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 76
    testRunner.And("I send \"{TAB}{TAB}{TAB}{TAB}{TAB}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
    testRunner.And("I send \"Remote1\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
    testRunner.And("I send \"{TAB}{TAB}{TAB}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
    testRunner.And("I send \"{Enter}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
       testRunner.Given("\"WORKFLOWDESIGNER,Remote1(FlowchartDesigner)\" is visible within \"12\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
       testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
    testRunner.Given("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
    testRunner.Given("I send \"Utility - Email\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 85
    testRunner.Given("I click \"EXPLORER,UI_localhost_AutoID,UI_Examples_AutoID,UI_Utility - Email_AutoI" +
                    "D\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 86
    testRunner.Given("I double click \"EXPLORER,UI_localhost_AutoID,UI_Examples_AutoID,UI_Utility - Emai" +
                    "l_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
    testRunner.Given("\"WORKFLOWDESIGNER,Utility - Email(FlowchartDesigner)\" is visible within \"5\" secon" +
                    "ds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 88
    testRunner.Given("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
    testRunner.Given("I send \"Remote1\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
    testRunner.Given("I click \"EXPLORER,UI_Test (http://localhost:3142/)_AutoID,UI_Remote1_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 91
    testRunner.Given("I drag \"EXPLORER,UI_Test (http://localhost:3142/)_AutoID,UI_Remote1_AutoID\" onto " +
                    "\"WORKFLOWDESIGNER,Utility - Email(FlowchartDesigner),Email(EmailDesigner)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
    testRunner.Given("\"WORKFLOWDESIGNER,Utility - Email(FlowchartDesigner),Remote1(ServiceDesigner)\" is" +
                    " visible within \"5\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
    testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
    testRunner.Given("\"DEBUGOUTPUT,DsfActivity\" is visible within \"20\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 96
    testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
    testRunner.And("I right click \"EXPLORER,UI_ExplorerTree_AutoID,UI_Test (http://localhost:3142/)_A" +
                    "utoID,UI_Remote1_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
    testRunner.And("I send \"{TAB}{TAB}{TAB}{TAB}{ENTER}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
    testRunner.And("I click \"UI_MessageBox_AutoID,UI_YesButton_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
    testRunner.Given("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 101
    testRunner.Given("I click \"EXPLORER,UI_localhost_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 102
    testRunner.Given("I click \"EXPLORER,UI_Test (http://localhost:3142/)_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 103
    testRunner.Given("I click \"EXPLORERCONNECTBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 104
    testRunner.Given("I click \"EXPLORER,UI_SourceServerRefreshbtn_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 105
       testRunner.Given("I send \"Test\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 106
    testRunner.And("I right click \"EXPLORERFOLDERS,UI_Test_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
    testRunner.And("I send \"{TAB}{TAB}{TAB}{TAB}{ENTER}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
    testRunner.And("I click \"UI_MessageBox_AutoID,UI_YesButton_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

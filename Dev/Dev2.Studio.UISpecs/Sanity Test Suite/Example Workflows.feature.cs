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
namespace Dev2.Studio.UI.Specs.SanityTestSuite
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class SpecFloUI_FileAndFolder_Delete_AutoIDeature1Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Example Workflows.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SpecFloUI_File and Folder - Delete_AutoIDeature1", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "SpecFloUI_File and Folder - Delete_AutoIDeature1")))
            {
                Dev2.Studio.UI.Specs.SanityTestSuite.SpecFloUI_FileAndFolder_Delete_AutoIDeature1Feature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Testing Example Workflows")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SpecFloUI_File and Folder - Delete_AutoIDeature1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Examples")]
        public virtual void TestingExampleWorkflows()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Testing Example Workflows", new string[] {
                        "Examples"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("I click \"EXPLORER,UI_localhost_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I send \"Utility - Comment\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
    testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Comment_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Comment_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - Comment(FlowchartDesigner)\" is visible within \"10\" se" +
                    "conds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I send \"Date and Time Difference\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Date and Time Difference" +
                    "_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Date and Time Dif" +
                    "ference_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - Date and Time Difference(FlowchartDesigner)\" is visib" +
                    "le within \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
    testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I send \"Utility - Date and Time\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Date and Time_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Date and Time_Aut" +
                    "oID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - Date and Time(FlowchartDesigner)\" is visible within \"" +
                    "10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I send \"Utility - Calculate\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Calculate_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Calculate_AutoID\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - Calculate(FlowchartDesigner)\" is visible within \"10\" " +
                    "seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I send \"Utility - Format Number\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Format Number_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Format Number_Aut" +
                    "oID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - Format Number(FlowchartDesigner)\" is visible within \"" +
                    "10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("I send \"Utility - Random\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Random_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Random_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - Random(FlowchartDesigner)\" is visible within \"10\" sec" +
                    "onds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("I send \"Utility - System Information\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
    testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - System Information_AutoI" +
                    "D\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Utility - System Information_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - System Information(FlowchartDesigner)\" is visible wit" +
                    "hin \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("I send \"Utility - Web Request\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Web Request_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Web Request_AutoI" +
                    "D\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - Web Request(FlowchartDesigner)\" is visible within \"10" +
                    "\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("I send \"Utility - XPath\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - XPath_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - XPath_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - XPath(FlowchartDesigner)\" is visible within \"10\" seco" +
                    "nds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("I send \"Utility - Assign\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Assign_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Assign_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - Assign(FlowchartDesigner)\" is visible within \"10\" sec" +
                    "onds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("I send \"Control Flow\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Control Flow - Decision_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Control Flow - Decision_Aut" +
                    "oID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.Then("\"WORKFLOWDESIGNER,Control Flow: Decision(FlowchartDesigner)\" is visible within \"1" +
                    "0\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Control Flow - Sequence_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Control Flow - Sequence_Aut" +
                    "oID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.Then("\"WORKFLOWDESIGNER,Control Flow - Sequence(FlowchartDesigner)\" is visible within \"" +
                    "10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Control Flow - Switch_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Control Flow - Switch_AutoI" +
                    "D\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.Then("\"WORKFLOWDESIGNER,Control Flow - Switch(FlowchartDesigner)\" is visible within \"10" +
                    "\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.And("I send \"Loop Constructs\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Loop Constructs - For Each_AutoID\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Loop Constructs - For Each_" +
                    "AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.Then("\"WORKFLOWDESIGNER,Loop Constructs - For Each(FlowchartDesigner)\" is visible withi" +
                    "n \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And("I send \"Data - \" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Find Index_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Find Index_AutoID" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - Find Index(FlowchartDesigner)\" is visible within \"10\"" +
                    " seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
    testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Data - Case Conversion_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Data - Case Conversion_Auto" +
                    "ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
 testRunner.Then("\"WORKFLOWDESIGNER,Data - Case Conversion(FlowchartDesigner)\" is visible within \"1" +
                    "0\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 136
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Data - Data Split_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Data - Data Split_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
 testRunner.Then("\"WORKFLOWDESIGNER,Data - Data Split(FlowchartDesigner)\" is visible within \"10\" se" +
                    "conds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Data - Data Merge_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Data - Data Merge_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
 testRunner.Then("\"WORKFLOWDESIGNER,Data - Data Merge(FlowchartDesigner)\" is visible within \"10\" se" +
                    "conds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 148
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Replace_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Utility - Replace_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.Then("\"WORKFLOWDESIGNER,Utility - Replace(FlowchartDesigner)\" is visible within \"10\" se" +
                    "conds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 154
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.And("I send \"Recordset\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 160
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Unique Records_AutoID\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Unique Records_" +
                    "AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
    testRunner.Then("\"WORKFLOWDESIGNER,Recordset - Unique Records(FlowchartDesigner)\" is visible withi" +
                    "n \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 163
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 164
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Count Records_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Count Records_A" +
                    "utoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
 testRunner.Then("\"WORKFLOWDESIGNER,Recordset - Count Records(FlowchartDesigner)\" is visible within" +
                    " \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 169
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Records Length_AutoID\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Records Length_" +
                    "AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
 testRunner.Then("\"WORKFLOWDESIGNER,Recordset - Records Length(FlowchartDesigner)\" is visible withi" +
                    "n \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 175
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Delete Records_AutoID\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Delete Records_" +
                    "AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
 testRunner.Then("\"WORKFLOWDESIGNER,Recordset - Delete Records(FlowchartDesigner)\" is visible withi" +
                    "n \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 181
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 182
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 184
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Find Records_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 185
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Find Records_Au" +
                    "toID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 186
 testRunner.Then("\"WORKFLOWDESIGNER,Recordset - Find Records(FlowchartDesigner)\" is visible within " +
                    "\"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 187
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 188
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 190
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Sort Records_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - Sort Records_Au" +
                    "toID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
 testRunner.Then("\"WORKFLOWDESIGNER,Recordset - Sort Records(FlowchartDesigner)\" is visible within " +
                    "\"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 193
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 196
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - SQL Bulk Insert_AutoID" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 197
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Recordset - SQL Bulk Insert" +
                    "_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 198
 testRunner.Then("\"WORKFLOWDESIGNER,Recordset - SQL Bulk Insert(FlowchartDesigner),SQL Bulk Insert(" +
                    "SqlBulkInsertDesigner)\" is visible within \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 199
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 200
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
 testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 204
 testRunner.And("I send \"File and Folder\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 205
  testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Rename_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 206
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Rename_Au" +
                    "toID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 207
 testRunner.Then("\"WORKFLOWDESIGNER,File and Folder - Rename(FlowchartDesigner)\" is visible within " +
                    "\"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 208
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 209
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 211
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Unzip_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 212
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Unzip_Aut" +
                    "oID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 213
 testRunner.Then("\"WORKFLOWDESIGNER,File and Folder - Unzip(FlowchartDesigner)\" is visible within \"" +
                    "10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 214
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 215
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 217
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Write File_AutoI" +
                    "D\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 218
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Write Fil" +
                    "e_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 219
 testRunner.Then("\"WORKFLOWDESIGNER,File and Folder - Write File(FlowchartDesigner)\" is visible wit" +
                    "hin \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 220
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 221
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 223
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Delete_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 224
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Delete_Au" +
                    "toID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 225
 testRunner.Then("\"WORKFLOWDESIGNER,File and Folder - Delete(FlowchartDesigner),Delete(DeleteDesign" +
                    "er),SmallViewContent\" is visible within \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 226
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 227
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 229
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Zip_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 230
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Zip_AutoI" +
                    "D\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 231
 testRunner.Then("\"WORKFLOWDESIGNER,File and Folder - Zip(FlowchartDesigner)\" is visible within \"10" +
                    "\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 232
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 233
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 235
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Create_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 236
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Create_Au" +
                    "toID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 237
 testRunner.Then("\"WORKFLOWDESIGNER,File and Folder - Create(FlowchartDesigner),Create(CreateDesign" +
                    "er)\" is visible within \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 238
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 239
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 241
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Copy_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 242
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Copy_Auto" +
                    "ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 243
 testRunner.Then("\"WORKFLOWDESIGNER,File and Folder - Copy(FlowchartDesigner)\" is visible within \"1" +
                    "0\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 244
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 245
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 247
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Move_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 248
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Move_Auto" +
                    "ID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 249
 testRunner.Then("\"WORKFLOWDESIGNER,File and Folder - Move(FlowchartDesigner)\" is visible within \"1" +
                    "0\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 250
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 251
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 254
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Read File_AutoID" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 255
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Read File" +
                    "_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 256
 testRunner.Then("\"WORKFLOWDESIGNER,File and Folder - Read File(FlowchartDesigner)\" is visible with" +
                    "in \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 257
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 258
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 261
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Delete_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 262
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_File and Folder - Delete_Au" +
                    "toID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 263
 testRunner.Then("\"WORKFLOWDESIGNER,File and Folder - Delete(FlowchartDesigner),Delete(DeleteDesign" +
                    "er)\" is visible within \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 264
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 265
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 269
  testRunner.And("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 270
 testRunner.And("I send \"Scripting\" to \"EXPLORERFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 271
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Scripting - CMD Line_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 272
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Scripting - CMD Line_AutoID" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 273
 testRunner.Then("\"WORKFLOWDESIGNER,Scripting - CMD Line(FlowchartDesigner)\" is visible within \"10\"" +
                    " seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 274
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 275
    testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 277
 testRunner.And("I click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Scripting - Script_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 278
 testRunner.And("I double click \"EXPLORERFOLDERS,UI_Examples_AutoID,UI_Scripting - Script_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 279
 testRunner.Then("\"WORKFLOWDESIGNER,Scripting - Script(FlowchartDesigner)\" is visible within \"10\" s" +
                    "econds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 280
 testRunner.And("I send \"{F6}\" to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 281
 testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

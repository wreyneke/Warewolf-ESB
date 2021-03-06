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
namespace Dev2.Studio.UI.Specs.Tools
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class Resource_WorkflowFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Resource-Service.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Resource-Workflow", "In order to be able to use warewolf\r\nAs a warewolf user\r\nI want to be able to Dra" +
                    "g Workflow Tool onto design surface", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Resource-Workflow")))
            {
                Dev2.Studio.UI.Specs.Tools.Resource_WorkflowFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag Service to design surface and checking Workflows are not showing in Services" +
            " resource picker")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Resource-Workflow")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Services")]
        public virtual void DragServiceToDesignSurfaceAndCheckingWorkflowsAreNotShowingInServicesResourcePicker()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag Service to design surface and checking Workflows are not showing in Services" +
                    " resource picker", new string[] {
                        "Services"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.Given("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.Given("I click \"EXPLORERFILTERCLEARBUTTON\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.Given("I click \"EXPLORERCONNECTCONTROL\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.Given("I click \"U_UI_ExplorerServerCbx_AutoID_localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.Given("I click new \"Workflow\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("I send \"service\" to \"TOOLBOX,PART_SearchBox\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Given("I drag \"TOOLSERVICES\" onto \"ACTIVETAB,UI_WorkflowDesigner_AutoID,UserControl_1,sc" +
                    "rollViewer,ActivityTypeDesigner,WorkflowItemPresenter,StartSymbol\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 testRunner.And("I send \"Decision Testing\" to \"UI_SelectServiceWindow_AutoID,UI_NavigationViewUser" +
                    "Control_AutoID,UI_DatalistFilterTextBox_AutoID,UI_TextBox_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("\"RESOURCEPICKERFOLDERS,UI_Acceptance Testing Resources_AutoID\" is invisible withi" +
                    "n \"2\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
    testRunner.And("I click \"UI_SelectServiceWindow_AutoID,UI_NavigationViewUserControl_AutoID,UI_Dat" +
                    "alistFilterTextBox_AutoID,UI_FilterButton_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I send \"Control\" to \"UI_SelectServiceWindow_AutoID,UI_NavigationViewUserControl_A" +
                    "utoID,UI_DatalistFilterTextBox_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.Then("\"RESOURCEPICKERFOLDERS,UI_Examples_AutoID,UI_Control Flow - Decision_AutoID\" is i" +
                    "nvisible within \"2\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.Given("I click \"TOOLWORKFLOWRISOURCEPICKFILTER\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
    testRunner.And("I send \"DBServices\" to \"UI_SelectServiceWindow_AutoID,UI_NavigationViewUserContro" +
                    "l_AutoID,UI_DatalistFilterTextBox_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("\"RESOURCEPICKERFOLDERS,UI_Acceptance Testing Resources_AutoID,UI_bug9394DBService" +
                    "sCall_AutoID\" is visible within \"10\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I double click \"RESOURCEPICKERFOLDERS,UI_Acceptance Testing Resources_AutoID,UI_b" +
                    "ug9394DBServicesCall_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I click \"UI_SelectServiceWindow_AutoID,UI_SelectServiceOKButton_AutoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("\"WORKSURFACE,Acceptance Testing Resources\\bug9394DBServicesCall(ServiceDesigner)\"" +
                    " is visible within \"2\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

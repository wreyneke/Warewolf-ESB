﻿using System.Diagnostics.CodeAnalysis;
using Dev2.Data.Binary_Objects;
using Dev2.Data.Factories;
using Dev2.DataList.Contract;
using Dev2.DataList.Contract.Binary_Objects;
using Dev2.DataList.Contract.Builders;
using Dev2.DataList.Contract.TO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Dev2.Tests
{
    /// <summary>
    /// Summary description for DataListCompilerTest
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DataListCompilerTest
    {


        //private IDataListCompiler _compiler = DataListFactory.CreateDataListCompiler();
        private IBinaryDataList dl1;
        private IBinaryDataList dl2;
        private ErrorResultTO _errors = new ErrorResultTO();
        private string _error;
        private IBinaryDataListEntry entry;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            string error;

            var dataListCompiler = DataListFactory.CreateDataListCompiler();

            dl1 = Dev2BinaryDataListFactory.CreateDataList();
            dl1.TryCreateScalarTemplate(string.Empty, "myScalar", "A scalar", true, out error);
            dl1.TryCreateScalarValue("[[otherScalar]]", "myScalar", out error);

            dl1.TryCreateScalarTemplate(string.Empty, "otherScalar", "A scalar", true, out error);
            dl1.TryCreateScalarValue("testRegion", "otherScalar", out error);

            dl1.TryCreateScalarTemplate(string.Empty, "scalar1", "A scalar", true, out error);
            dl1.TryCreateScalarValue("foobar", "scalar1", out error);

            IList<Dev2Column> cols = new List<Dev2Column>();
            cols.Add(Dev2BinaryDataListFactory.CreateColumn("f1"));
            cols.Add(Dev2BinaryDataListFactory.CreateColumn("f2"));
            cols.Add(Dev2BinaryDataListFactory.CreateColumn("f3"));

            dl1.TryCreateRecordsetTemplate("recset", "a recordset", cols, true, out error);

            dl1.TryCreateRecordsetValue("r1.f1.value", "f1", "recset", 1, out error);
            dl1.TryCreateRecordsetValue("r1.f2.value", "f2", "recset", 1, out error);
            dl1.TryCreateRecordsetValue("r1.f3.value", "f3", "recset", 1, out error);

            dl1.TryCreateRecordsetValue("r2.f1.value", "f1", "recset", 2, out error);
            dl1.TryCreateRecordsetValue("r2.f2.value", "f2", "recset", 2, out error);
            dl1.TryCreateRecordsetValue("r2.f3.value", "f3", "recset", 2, out error);

            // skip 3 ;)

            dl1.TryCreateRecordsetValue("r4.f1.value", "f1", "recset", 4, out error);
            dl1.TryCreateRecordsetValue("r4.f2.value", "f2", "recset", 4, out error);
            dl1.TryCreateRecordsetValue("r4.f3.value", "f3", "recset", 4, out error);

            dataListCompiler.PushBinaryDataList(dl1.UID, dl1, out _errors);
            //_compiler.UpsertSystemTag(dl1.UID, enSystemTag.EvaluateIteration, "true", out errors);

            /*  list 2 */
            dl2 = Dev2BinaryDataListFactory.CreateDataList();
            dl2.TryCreateScalarTemplate(string.Empty, "idx", "A scalar", true, out error);
            dl2.TryCreateScalarValue("1", "idx", out error);

            dl2.TryCreateRecordsetTemplate("recset", "a recordset", cols, true, out error);

            dl2.TryCreateRecordsetValue("r1.f1.value", "f1", "recset", 1, out error);
            dl2.TryCreateRecordsetValue("r1.f2.value", "f2", "recset", 1, out error);
            dl2.TryCreateRecordsetValue("r1.f3.value", "f3", "recset", 1, out error);

            dl2.TryCreateRecordsetValue("r2.f1.value", "f1", "recset", 2, out error);
            dl2.TryCreateRecordsetValue("r2.f2.value", "f2", "recset", 2, out error);
            dl2.TryCreateRecordsetValue("r2.f3.value", "f3", "recset", 2, out error);

            dataListCompiler.PushBinaryDataList(dl2.UID, dl2, out _errors);
            //_compiler.UpsertSystemTag(dl2.UID, enSystemTag.EvaluateIteration, "true", out errors);
        }

        #endregion

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("DataListCompiler_Evaluate")]
        public void DataListCompiler_Evaluate_ForNonPresentRecordsetIndex_BlankRowReturned()
        {
            //------------Setup for test--------------------------
            var dlc = DataListFactory.CreateDataListCompiler();
            ErrorResultTO errors;
            string error; 

            //------------Execute Test---------------------------
            var result = dlc.Evaluate(dl1.UID, enActionType.User, "[[recset(3).f1]]", false, out errors);
            var res = result.TryFetchLastIndexedRecordsetUpsertPayload(out error);
            
            //------------Assert Results-------------------------
           
            var value = res.TheValue;

            Assert.AreEqual(string.Empty, value);

        }

        // Created by Michael for Bug 8597
        [TestMethod]
        public void HasErrors_Passed_Empty_GUID_Expected_No_NullReferenceException()
        {
            Guid id = Guid.Empty;

            var dataListCompiler = DataListFactory.CreateDataListCompiler();

            try
            {
                dataListCompiler.HasErrors(id);
            }
            catch (NullReferenceException)
            {
                Assert.Inconclusive("No NullReferenceException should be thrown.");
            }
        }

        [TestMethod]
        public void Iteration_Evaluation_Expect_Evaluation_For_1_Iteration()
        {
            // Iteration evaluation is tested via the shape method ;)
            var compiler = DataListFactory.CreateDataListCompiler();
            const string defs = @"<Inputs><Input Name=""scalar1"" Source=""[[myScalar]]"" /></Inputs>"; ;
            Guid id = compiler.Shape(dl1.UID, enDev2ArgumentType.Input, defs, out _errors);

            IBinaryDataList bdl = compiler.FetchBinaryDataList(id, out _errors);

            bdl.TryGetEntry("scalar1", out entry, out _error);

            var res = entry.FetchScalar().TheValue;

            Assert.AreEqual("[[otherScalar]]", res);

        }


        #region FixedWizardTest

        [TestMethod]
        public void FixedWizardScalar_Converter_Expected_FixedDataListPortion()
        {
            const string wizDL = @"<DataList>
       <TestVar IsEditable=""False"" Description=""""/>
       <Port IsEditable=""False"" Description=""""/>
       <From IsEditable=""False"" Description=""""/>
       <To IsEditable=""False"" Description=""""/>
       <Subject IsEditable=""False"" Description=""""/>
       <BodyType IsEditable=""False"" Description=""""/>
       <Body IsEditable=""False"" Description=""""/>
       <Attachment IsEditable=""False"" Description=""""/>
       <FailureMessage IsEditable=""False"" Description=""""/>
       <Message IsEditable=""False"" Description=""""/>
</DataList>
";
            const string serviceDL = @"<DataList>
       <Movember IsEditable=""False"" Description=""""/>
       <Port IsEditable=""False"" Description=""""/>
       <From IsEditable=""False"" Description=""""/>
       <To IsEditable=""False"" Description=""""/>
       <Subject IsEditable=""False"" Description=""""/>
       <BodyType IsEditable=""False"" Description=""""/>
       <Body IsEditable=""False"" Description=""""/>
       <Attachment IsEditable=""False"" Description=""""/>
       <FailureMessage IsEditable=""False"" Description=""""/>
       <Message IsEditable=""False"" Description=""""/>
</DataList>
";
            const string expected = @"<DataList><Movember IsEditable=""False"" ></Movember><Port IsEditable=""False"" ></Port><From IsEditable=""False"" ></From><To IsEditable=""False"" ></To><Subject IsEditable=""False"" ></Subject><BodyType IsEditable=""False"" ></BodyType><Body IsEditable=""False"" ></Body><Attachment IsEditable=""False"" ></Attachment><FailureMessage IsEditable=""False"" ></FailureMessage><Message IsEditable=""False"" ></Message></DataList>";

            var dataListCompiler = DataListFactory.CreateDataListCompiler();

            WizardDataListMergeTO result = dataListCompiler.MergeFixedWizardDataList(wizDL, serviceDL);

            var res1 = result.AddedRegions[0].FetchScalar().FieldName;
            var res2 = result.RemovedRegions[0].FetchScalar().FieldName;

            Assert.AreEqual(expected, result.IntersectedDataList);
            Assert.AreEqual("Movember", res1);
            Assert.AreEqual("TestVar", res2);
        }

        [TestMethod]
        public void FixedWizardRecordset_Converter_Expected_FixedDataListPortion()
        {
            const string wizDL = @"<DataList>
       <Port IsEditable=""False"" Description=""""/>
       <From IsEditable=""False"" Description=""""/>
       <To IsEditable=""False"" Description=""""/>
       <Subject IsEditable=""False"" Description=""""/>
       <BodyType IsEditable=""False"" Description=""""/>
       <Body IsEditable=""False"" Description=""""/>
       <Attachment IsEditable=""False"" Description=""""/>
       <FailureMessage IsEditable=""False"" Description=""""/>
       <Message IsEditable=""False"" Description=""""/>
</DataList>
";
            const string serviceDL = @"<DataList>
       <Movember IsEditable=""False"" Description=""""/>
       <Recordset IsEditable=""False"" Description="""">
            <FirstName/>
        </Recordset>
       <Port IsEditable=""False"" Description=""""/>
       <From IsEditable=""False"" Description=""""/>
       <To IsEditable=""False"" Description=""""/>
       <Subject IsEditable=""False"" Description=""""/>
       <BodyType IsEditable=""False"" Description=""""/>
       <Body IsEditable=""False"" Description=""""/>
       <Attachment IsEditable=""False"" Description=""""/>
       <FailureMessage IsEditable=""False"" Description=""""/>
       <Message IsEditable=""False"" Description=""""/>
</DataList>
";
            const string expected = @"<DataList><Movember IsEditable=""False"" ></Movember><Recordset IsEditable=""False"" ><FirstName IsEditable=""False"" ></FirstName></Recordset><Port IsEditable=""False"" ></Port><From IsEditable=""False"" ></From><To IsEditable=""False"" ></To><Subject IsEditable=""False"" ></Subject><BodyType IsEditable=""False"" ></BodyType><Body IsEditable=""False"" ></Body><Attachment IsEditable=""False"" ></Attachment><FailureMessage IsEditable=""False"" ></FailureMessage><Message IsEditable=""False"" ></Message></DataList>";
            string error;

            var dataListCompiler = DataListFactory.CreateDataListCompiler();

            WizardDataListMergeTO result = dataListCompiler.MergeFixedWizardDataList(wizDL, serviceDL);

            Assert.AreEqual(expected, result.IntersectedDataList);
            Assert.AreEqual("Movember", result.AddedRegions[0].FetchScalar().FieldName);
            Assert.AreEqual("Recordset", (result.AddedRegions[1].FetchRecordAt(1, out error))[0].Namespace);
            Assert.AreEqual(0, result.RemovedRegions.Count);
        }

        #endregion

        #region Generate Defintion Tests

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("DataListCompiler_GenerateSerializableDefsFromDataList")]
        public void DataListCompiler_GenerateSerializableDefsFromDataList_WhenOutputs_ValidOutputs()
        {
            //------------Setup for test--------------------------

            const string datalistFragment = @"<DataList>
    <result Description="""" IsEditable=""True"" ColumnIODirection=""Output"" />
    <recset1 Description="""" IsEditable=""True"" ColumnIODirection=""None"">
      <f1 Description="""" IsEditable=""True"" ColumnIODirection=""None"" />
    </recset1>
    <recset2 Description="""" IsEditable=""True"" ColumnIODirection=""None"">
      <f2 Description="""" IsEditable=""True"" ColumnIODirection=""None"" />
    </recset2>
  </DataList>";

            var dataListCompiler = DataListFactory.CreateDataListCompiler();
            
            //------------Execute Test---------------------------

            var result = dataListCompiler.GenerateSerializableDefsFromDataList(datalistFragment, enDev2ColumnArgumentDirection.Output);

            //------------Assert Results-------------------------

            Assert.AreEqual(@"<Outputs><Output Name=""result"" MapsTo="""" Value="""" /></Outputs>", result);
        }

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("DataListCompiler_GenerateSerializableDefsFromDataList")]
        public void DataListCompiler_GenerateSerializableDefsFromDataList_WhenInputs_ValidInputs()
        {
            //------------Setup for test--------------------------

            const string datalistFragment = @"<DataList>
    <result Description="""" IsEditable=""True"" ColumnIODirection=""Input"" />
    <recset1 Description="""" IsEditable=""True"" ColumnIODirection=""None"">
      <f1 Description="""" IsEditable=""True"" ColumnIODirection=""None"" />
    </recset1>
    <recset2 Description="""" IsEditable=""True"" ColumnIODirection=""None"">
      <f2 Description="""" IsEditable=""True"" ColumnIODirection=""None"" />
    </recset2>
  </DataList>";

            var dataListCompiler = DataListFactory.CreateDataListCompiler();

            //------------Execute Test---------------------------

            var result = dataListCompiler.GenerateSerializableDefsFromDataList(datalistFragment, enDev2ColumnArgumentDirection.Input);

            //------------Assert Results-------------------------

            Assert.AreEqual(@"<Inputs><Input Name=""result"" Source="""" /></Inputs>", result);
        }

        [TestMethod]
        public void GenerateDefsFromDataListWhereDataListExpectResultsToMatchIODirectionForInput()
        {
            //------------Setup for test--------------------------
            var dataListCompiler = DataListFactory.CreateDataListCompiler();

            var dataList = "<DataList><test ColumnIODirection=\"Both\" /><newvar ColumnIODirection=\"Input\" /><as ColumnIODirection=\"Output\" />" +
                                     "<sssdd ColumnIODirection=\"Both\" /><sss ColumnIODirection=\"Both\" />" +
                                     "<recset ColumnIODirection=\"Both\"><f1 ColumnIODirection=\"Both\" /><f2 ColumnIODirection=\"Output\" /></recset></DataList>";
            //------------Execute Test---------------------------
            var generateDefsFromDataList = dataListCompiler.GenerateDefsFromDataList(dataList, enDev2ColumnArgumentDirection.Input);
            //------------Assert Results-------------------------
            Assert.AreEqual(5,generateDefsFromDataList.Count);
        }

        [TestMethod]
        public void GenerateDefsFromDataListWhereDataListExpectResultsToMatchIODirectionForOutput()
        {
            //------------Setup for test--------------------------
            var dataListCompiler = DataListFactory.CreateDataListCompiler();
            var dataList = "<DataList><test ColumnIODirection=\"Both\" /><newvar ColumnIODirection=\"Input\" /><as ColumnIODirection=\"Output\" />" +
                                     "<sssdd ColumnIODirection=\"Both\" /><sss ColumnIODirection=\"Both\" />" +
                                     "<recset ColumnIODirection=\"Both\"><f1 ColumnIODirection=\"Both\" /><f2 ColumnIODirection=\"Output\" /></recset></DataList>";
            //------------Execute Test---------------------------
            var generateDefsFromDataList = dataListCompiler.GenerateDefsFromDataList(dataList, enDev2ColumnArgumentDirection.Output);
            //------------Assert Results-------------------------
            Assert.AreEqual(6,generateDefsFromDataList.Count);
        }

        [TestMethod]
        public void GenerateDefsFromDataListWhereDataListExpectResultsToMatchIODirectionForBoth()
        {
            //------------Setup for test--------------------------
            var dataListCompiler = DataListFactory.CreateDataListCompiler();
            var dataList = "<DataList><test ColumnIODirection=\"Both\" /><newvar ColumnIODirection=\"Input\" /><as ColumnIODirection=\"Output\" />" +
                                     "<sssdd ColumnIODirection=\"Both\" /><sss ColumnIODirection=\"Both\" />" +
                                     "<recset ColumnIODirection=\"Both\"><f1 ColumnIODirection=\"Both\" /><f2 ColumnIODirection=\"Output\" /></recset></DataList>";
            //------------Execute Test---------------------------
            var generateDefsFromDataList = dataListCompiler.GenerateDefsFromDataList(dataList, enDev2ColumnArgumentDirection.Both);
            //------------Assert Results-------------------------
            Assert.AreEqual(4,generateDefsFromDataList.Count);
        }

        [TestMethod]
        public void GenerateDefsFromDataListWhereDataListExpectResultsToMatchIODirectionForRecsetHasNone()
        {
            //------------Setup for test--------------------------
            var dataListCompiler = DataListFactory.CreateDataListCompiler();
            var dataList = "<DataList><test ColumnIODirection=\"Both\" /><newvar ColumnIODirection=\"Input\" /><as ColumnIODirection=\"Output\" />" +
                                     "<sssdd ColumnIODirection=\"Both\" /><sss ColumnIODirection=\"Both\" />" +
                                     "<recset ColumnIODirection=\"Both\"><f1 ColumnIODirection=\"Both\" /><f2 ColumnIODirection=\"None\" /></recset></DataList>";
            //------------Execute Test---------------------------
            var generateDefsFromDataList = dataListCompiler.GenerateDefsFromDataList(dataList, enDev2ColumnArgumentDirection.Output);
            //------------Assert Results-------------------------
            Assert.AreEqual(5,generateDefsFromDataList.Count);
        }

        #endregion Generate Defintion Tests

        #region Generate DataList From Defs Tests

        [TestMethod]
        public void GenerateWizardDataListFromDefs_Outputs_Expected_Correct_DataList()
        {
            var dataListCompiler = DataListFactory.CreateDataListCompiler();
            string defstring = ParserStrings.dlOutputMappingOutMapping;
            ErrorResultTO errors;
            string acctual = dataListCompiler.GenerateWizardDataListFromDefs(defstring, enDev2ArgumentType.Output, false, out errors, true);

            Assert.IsTrue(acctual.Contains(@"<ADL><required></required><validationClass></validationClass><cssClass>[[cssClass]]</cssClass><Dev2customStyle></Dev2customStyle>
</ADL>"));
        }

        [TestMethod]
        public void GenerateWizardDataListFromDefs_Inputs_Expected_Correct_DataList()
        {
            var dataListCompiler = DataListFactory.CreateDataListCompiler();
            string defstring = ParserStrings.dlInputMapping;
            ErrorResultTO errors;
            string acctual = dataListCompiler.GenerateWizardDataListFromDefs(defstring, enDev2ArgumentType.Input, false, out errors, true);

            Assert.IsTrue(acctual.Contains(@"<ADL><reg></reg><asdfsad>registration223</asdfsad><number></number>
</ADL>"));
        }

        [TestMethod]
        public void GenerateDataListFromDefs_Outputs_Expected_Correct_DataList()
        {
            var dataListCompiler = DataListFactory.CreateDataListCompiler();
            string defstring = ParserStrings.dlOutputMappingOutMapping;
            ErrorResultTO errors;
            string acctual = dataListCompiler.GenerateDataListFromDefs(defstring, enDev2ArgumentType.Output, false, out errors);

            Assert.IsTrue(acctual.Contains(@"<ADL><required/><validationClass/><cssClass/><Dev2customStyle/>
</ADL>"));
        }

        [TestMethod]
        public void GenerateDataListFromDefs_Inputs_Expected_Correct_DataList()
        {
            var dataListCompiler = DataListFactory.CreateDataListCompiler();
            string defstring = ParserStrings.dlInputMapping;
            ErrorResultTO errors;
            string acctual = dataListCompiler.GenerateDataListFromDefs(defstring, enDev2ArgumentType.Input, false, out errors);

            Assert.IsTrue(acctual.Contains(@"<ADL><reg/><asdfsad/><number/>
</ADL>"));
        }

        #endregion Generate DataList From Defs Tests

        #region Evaluation Test

        [TestMethod]
        public void UpsertWhereListStringExpectUpsertCorrectly()
        {
            //------------Setup for test--------------------------
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            IDev2DataListUpsertPayloadBuilder<List<string>> toUpsert = Dev2DataListBuilderFactory.CreateStringListDataListUpsertBuilder();
            toUpsert.Add("[[rec().f1]]", new List<string> { "test1", "test2" });
            IBinaryDataList dataList = Dev2BinaryDataListFactory.CreateDataList();
            string creationError;
            dataList.TryCreateRecordsetTemplate("rec", "recset", new List<Dev2Column>{DataListFactory.CreateDev2Column("f1","f1")}, true, out creationError);
            ErrorResultTO localErrors;
            compiler.PushBinaryDataList(dataList.UID, dataList, out localErrors);
            //------------Execute Test---------------------------
            compiler.Upsert(dataList.UID, toUpsert, out _errors);
            //------------Assert Results-------------------------
            IList<IBinaryDataListEntry> binaryDataListEntries = dataList.FetchRecordsetEntries();
            IBinaryDataListEntry binaryDataListEntry = binaryDataListEntries[0];
            string errString;
            IList<IBinaryDataListItem> binaryDataListItems = binaryDataListEntry.FetchRecordAt(1, out errString);
            IBinaryDataListItem binaryDataListItem = binaryDataListItems[0];
            string theValue = binaryDataListItem.TheValue;
            Assert.AreEqual("test1", theValue);

            binaryDataListItems = binaryDataListEntry.FetchRecordAt(2, out errString);
            binaryDataListItem = binaryDataListItems[0];
            theValue = binaryDataListItem.TheValue;


            Assert.AreEqual("test2", theValue);
        }

        [TestMethod]
        public void UpsertWhereListStringExpectUpsertCorrectlyMultipleRecordset()
        {
            //------------Setup for test--------------------------
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            IDev2DataListUpsertPayloadBuilder<List<string>> toUpsert = Dev2DataListBuilderFactory.CreateStringListDataListUpsertBuilder();
            toUpsert.Add("[[rec().f1]]", new List<string> { "test11", "test12" });
            toUpsert.Add("[[rec().f2]]", new List<string> { "test21", "test22" });
            IBinaryDataList dataList = Dev2BinaryDataListFactory.CreateDataList();
            string creationError;
            dataList.TryCreateRecordsetTemplate("rec", "recset", new List<Dev2Column> { DataListFactory.CreateDev2Column("f1", "f1"), DataListFactory.CreateDev2Column("f2", "f2") }, true, out creationError);
            ErrorResultTO localErrors;
            compiler.PushBinaryDataList(dataList.UID, dataList, out localErrors);
            //------------Execute Test---------------------------
            compiler.Upsert(dataList.UID, toUpsert, out _errors);
            //------------Assert Results-------------------------
            IList<IBinaryDataListEntry> binaryDataListEntries = dataList.FetchRecordsetEntries();
            IBinaryDataListEntry binaryDataListEntry = binaryDataListEntries[0];
            string errString;
            IList<IBinaryDataListItem> binaryDataListItems = binaryDataListEntry.FetchRecordAt(1, out errString);
            IBinaryDataListItem binaryDataListItem = binaryDataListItems[0];
            IBinaryDataListItem binaryDataListItem2 = binaryDataListItems[1];
            string theValue = binaryDataListItem.TheValue;
            Assert.AreEqual("test11",theValue);
            theValue = binaryDataListItem2.TheValue;
            Assert.AreEqual("test21", theValue);
            binaryDataListItems = binaryDataListEntry.FetchRecordAt(2, out errString);
            binaryDataListItem = binaryDataListItems[0];
            binaryDataListItem2 = binaryDataListItems[1];
            theValue = binaryDataListItem.TheValue;
            Assert.AreEqual("test12", theValue);
            theValue = binaryDataListItem2.TheValue;

            Assert.AreEqual("test22", theValue);
        }

        // Bug 8609
        [TestMethod]
        public void Can_Sub_Recordset_With_Index_Expect()
        {
            var dataListCompiler = DataListFactory.CreateDataListCompiler();
            ErrorResultTO errors = new ErrorResultTO();
            IBinaryDataListEntry entry = dataListCompiler.Evaluate(dl2.UID, enActionType.User, "[[recset(1).f1]]", false, out errors);

            Assert.AreEqual("r1.f1.value", entry.FetchScalar().TheValue);
        }

        #endregion
    }
}

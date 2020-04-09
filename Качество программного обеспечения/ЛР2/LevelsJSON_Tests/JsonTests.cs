using LevelsJSON.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace LevelsJSON_Tests
{
    /// <summary>
    /// �������� ����� <see cref="Json"/>
    /// </summary>
    [TestClass]
    public class JsonTests
    {     
        /// <summary>
        /// �������� ������������� ������
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("������������� �����");
        }
        /// <summary>
        /// �������� ������� ������
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("������� �����");
        }
        /// <summary>
        /// ������������ <see cref="Json(dynamic)"/>
        /// </summary>
        [DataTestMethod]
        public void JsonTest()
        {
            // ���� 1 (������ JSON)
            var actual = new Json("{\"key\": \"value\"}");
            var expected = "{\"key\": \"value\"}";
            Assert.AreEqual(expected, actual.String, "������ � ����� 1");
            // ���� 2 (������ JSON � ���������)
            actual = new Json("{\"key: \"value\"}");
            expected = "{\"error\": \"Invalid JSON\"}";
            Assert.AreEqual(expected, actual.String, "������ � ����� 2");
            // ���� 3 (������ JSON)
            actual = new Json(actual);
            expected = "{\"error\": \"Invalid JSON\"}";
            Assert.AreEqual(expected, actual.String, "������ � ����� 3");
            // ���� 4 (������ int)
            actual = new Json(1);
            expected = "{\"error\": \"Invalid JSON\"}";
            Assert.AreEqual(expected, actual.String, "������ � ����� 4");
            // ���� 5 (������ bool)
            actual = new Json(true);
            expected = "{\"error\": \"Invalid JSON\"}";
            Assert.AreEqual(expected, actual.String, "������ � ����� 5");
            // ���� 6 (������ null)
            actual = new Json(null);
            expected = "{\"error\": \"Invalid JSON\"}";
            Assert.AreEqual(expected, actual.String, "������ � ����� 6");
            // ���� 7 (������ double)
            actual = new Json(1.0);
            expected = "{\"error\": \"Invalid JSON\"}";
            Assert.AreEqual(expected, actual.String, "������ � ����� 7");
            // ���� 8 (������ JSON c { [ " ������ ��������)
            actual = new Json("{\"key\": \"\\\"value1\\\" \\\"{[value2, value3]}\\\"\"}");
            expected = "{\"key\": \"\\\"value1\\\" \\\"{[value2, value3]}\\\"\"}";
            Assert.AreEqual(expected, actual.String, "������ � ����� 8");
        }
        /// <summary>
        /// ������������ <see cref="Json.GetLevels"/>
        /// </summary>
        [TestMethod]
        public void GetLevelsTest()
        {
            // ���� 1
            Json json = new Json("{\"key\": \"value\"}");
            var actual = json.GetLevels();
            var expected = "{\"levels\": 1}";
            Assert.AreEqual(expected, actual, "������ � ����� 1");
            // ���� 2
            json = new Json("{\"identity\": {\"name\": \"Test\", \"translations\": [{\"order\": 1, \"language\": \"ru\", \"value\": \"����\"}]}}");
            actual = json.GetLevels();
            expected = "{\"levels\": 4}";
            Assert.AreEqual(expected, actual, "������ � ����� 2");
            // ���� 3
            json = new Json("{\"test1\": true, \"test2\": [null, 1]}");
            actual = json.GetLevels();
            expected = "{\"levels\": 2}";
            Assert.AreEqual(expected, actual, "������ � ����� 3");
            // ���� 4
            json = new Json("{\"title\":\"Conference\",\"participants\":[{},{}]}");
            actual = json.GetLevels();
            expected = "{\"levels\": 3}";
            Assert.AreEqual(expected, actual, "������ � ����� 4");
            // ���� 5
            json = new Json("{\"key\": \"\\\"value1\\\" \\\"{[value2, value3]}\\\"\"}");
            actual = json.GetLevels();
            expected = "{\"levels\": 1}";
            Assert.AreEqual(expected, actual, "������ � ����� 5");
        }
        /// <summary>
        /// ������������ <see cref="Json.Equals(object)"/>
        /// </summary>
        /// <remarks>������������������� ����</remarks>
        /// <param name="obj1">������, ������� ����������</param>
        /// <param name="obj2">������, � ������� ����������</param>
        /// <param name="expected">��������� ��������� (true ��� false)</param>
        [DataRow("{\"key1\": \"value1\"}", "{\"key1\": \"value1\"}", true)]
        [DataRow("{\"key1\": \"value1\"}", "{\"key2\": \"value2\"}", false)]
        [DataRow("{\"key1\": \"true\"}", "{\"key1\": true }", false)]
        [DataTestMethod]
        public void EqualsTest(dynamic obj1, dynamic obj2, bool expected)
        {
            Json json1 = new Json(obj1);
            Json json2 = new Json(obj2);
            bool actual = json1.Equals(json2);
            Assert.AreEqual(expected, actual);
        }
    }
}

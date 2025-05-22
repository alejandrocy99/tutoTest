using System.IO;
using System.Xml;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

public class ResultSerializer : ICallbacks
{
    public void RunFinished(ITestResultAdaptor result)
    {
        var xmlResult = result.ToXml();
        var path = Path.Combine(Application.persistentDataPath, "testresults.xml");

        using (var writer = XmlWriter.Create(path, new XmlWriterSettings { Indent = true }))
        {
            xmlResult.WriteTo(writer);
        }

        Debug.Log($"Resultados de prueba guardados en: {path}");
    }

    public void RunStarted(ITestAdaptor testsToRun) { }
    public void TestStarted(ITestAdaptor test) { }
    public void TestFinished(ITestResultAdaptor result) { }
}

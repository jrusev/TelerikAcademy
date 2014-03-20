using System;
using System.Collections.Generic;

public interface IDocument
{
    string Name { get; }

    string Content { get; }

    void LoadProperty(string key, string value);

    void SaveAllProperties(IList<KeyValuePair<string, object>> output);

    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }

    void Encrypt();

    void Decrypt();
}

public class DocumentSystem
{
    private static readonly IList<Document> Documents = new List<Document>();

    internal static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == string.Empty)
            {
                // End of commands
                break;
            }

            commands.Add(commandLine);
        }

        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        AddDcoument(new TextDocument(), attributes);
    }

    private static void AddDcoument(Document doc, string[] attributes)
    {
        foreach (var attrib in attributes)
        {
            string[] keyValue = attrib.Split('=');
            doc.LoadProperty(keyValue[0], keyValue[1]);
        }

        if (doc.Name == null)
        {
            Console.WriteLine("Document has no name");
        }
        else
        {
            Documents.Add(doc);
            Console.WriteLine("Document added: " + doc.Name);
        }
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDcoument(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDcoument(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDcoument(new ExcelDocument(), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDcoument(new AudioDocument(), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDcoument(new VideoDocument(), attributes);
    }

    private static void ListDocuments()
    {
        if (Documents.Count > 0)
        {
            foreach (var doc in Documents)
            {
                Console.WriteLine(doc);
            }
        }
        else
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        bool docFound = false;
        foreach (var doc in Documents)
        {
            if (doc.Name == name)
            {
                docFound = true;
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
            }
        }

        if (!docFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool docFound = false;
        foreach (var doc in Documents)
        {
            if (doc.Name == name)
            {
                docFound = true;
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
            }
        }

        if (!docFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool encriptableFound = false;
        foreach (var doc in Documents)
        { 
            if (doc is IEncryptable)
            {
                encriptableFound = true;
                (doc as IEncryptable).Encrypt();
            }
        }

        if (encriptableFound)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool docFound = false;
        foreach (var doc in Documents)
        {
            if (doc.Name == name)
            {
                docFound = true;
                if (doc is IEditable)
                {
                    (doc as IEditable).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", doc.Name);
                }
            }
        }

        if (!docFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }
}
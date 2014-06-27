Imports System.Security.Cryptography
Imports System.IO

Module Module1

    Sub Main(ByVal args As String())
        ' Read the command-line parameters
        Dim inFileName As String = args(0)
        Dim outFileName As String = args(1)
        Dim password As String = args(2)

        ' Create the password key
        Dim saltValueBytes As Byte() = System.Text.Encoding.ASCII.GetBytes("This is my sa1t")
        Dim passwordKey As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(password, saltValueBytes)

        ' Create the algorithm and specify the key and IV
        Dim alg As RijndaelManaged = New RijndaelManaged
        alg.Key = passwordKey.GetBytes(alg.KeySize / 8)
        alg.IV = passwordKey.GetBytes(alg.BlockSize / 8)

        ' Read the unencrypted file into fileData
        Dim inFile As FileStream = New FileStream(inFileName, FileMode.Open, FileAccess.Read)
        Dim fileData(inFile.Length) As Byte
        inFile.Read(fileData, 0, CType(inFile.Length, Integer))

        ' Create the ICryptoTransform and CryptoStream object 
        Dim encryptor As ICryptoTransform = alg.CreateEncryptor
        Dim outFile As FileStream = New FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.Write)
        Dim encryptStream As CryptoStream = New CryptoStream(outFile, encryptor, CryptoStreamMode.Write)

        ' Write the contents to the CryptoStream
        encryptStream.Write(fileData, 0, fileData.Length)

        ' Close the file handles
        encryptStream.Close()
        inFile.Close()
        outFile.Close()
    End Sub

End Module

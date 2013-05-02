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

        ' Read the encrypted file into fileData
        Dim decryptor As ICryptoTransform = alg.CreateDecryptor
        Dim inFile As FileStream = New FileStream(inFileName, FileMode.Open, FileAccess.Read)
        Dim decryptStream As CryptoStream = New CryptoStream(inFile, decryptor, CryptoStreamMode.Read)
        Dim fileData(inFile.Length) As Byte
        decryptStream.Read(fileData, 0, CType(inFile.Length, Integer))

        ' Write the contents of the unencrypted file
        Dim outFile As FileStream = New FileStream(outFileName, FileMode.OpenOrCreate, FileAccess.Write)
        outFile.Write(fileData, 0, fileData.Length)

        ' Close the file handles
        decryptStream.Close()
        inFile.Close()
        outFile.Close()
    End Sub

End Module

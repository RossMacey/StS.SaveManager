using System;
using System.IO;
using System.Text;

class StSSaveManager
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: StSSaveManager.exe <encode/decode> <inputFilePath> <outputFilePath>");
            return;
        }

        string action = args[0].ToLower();
        string inputFilePath = args[1];
        string outputFilePath = args[2];

        try
        {
            if (action == "encode")
            {
                byte[] dataToEncode = File.ReadAllBytes(inputFilePath);
                string encodedData = EncodeToBase64XOR(dataToEncode, "key");
                File.WriteAllText(outputFilePath, encodedData);
                Console.WriteLine($"Encoded file saved to: {outputFilePath}");
            }
            else if (action == "decode")
            {
                string base64String = File.ReadAllText(inputFilePath);
                byte[] decodedData = DecodeFromBase64XOR(base64String, "key");
                File.WriteAllBytes(outputFilePath, decodedData);
                Console.WriteLine($"Decoded file saved to: {outputFilePath}");
            }
            else
            {
                Console.WriteLine("Invalid action. Please specify 'encode' or 'decode'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static string EncodeToBase64XOR(byte[] data, string key)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] result = new byte[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            result[i] = (byte)(data[i] ^ keyBytes[i % keyBytes.Length]);
        }

        return Convert.ToBase64String(result);
    }

    /// <summary>
    /// Decodes a Base64-encoded string and applies XOR decryption using the specified key.
    /// </summary>
    /// <param name="data">The Base64-encoded string to decode.</param>
    /// <param name="key">The key for XOR decryption. Its bytes are cycled to match the length of the decoded data.</param>
    /// <returns>The decrypted byte array.</returns>
    static byte[] DecodeFromBase64XOR(string data, string key)
    {
        byte[] base64EncodedData = Convert.FromBase64String(data);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        byte[] result = new byte[base64EncodedData.Length];

        for (int i = 0; i < base64EncodedData.Length; i++)
        {
            result[i] = (byte)(base64EncodedData[i] ^ keyBytes[i % keyBytes.Length]);
        }

        return result;
    }

    /// <summary>
    /// Retrieves a number from a fixed list of integers (1, 2, 3) based on an optional index.
    /// </summary>
    /// <param name="ran">A nullable integer specifying the index of the element to return. Defaults to the first element if null.</param>
    /// <returns>The integer from the list corresponding to the provided index.</returns>
    static int WorkOutARandomNumber(int? ran)
    {
        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        
        return list[ran ?? 0];
        return 4;
    }
}

using System;
using System.Threading.Tasks;

namespace AsyncAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            SignDocumnetUsingDSAsync("DOCUMENT CONTENT");
    
        }
        static async void SignDocumnetUsingDSAsync(string documentContent)
        {
            String SantizedDocumentContent = await SantizeDocumentContentAsync(documentContent);
            Console.WriteLine("SantizedDocumentContent", SantizedDocumentContent);
            String HashdSantizedDocumentContent = await HashSantizedDocumentContentAsync(SantizedDocumentContent);
            Console.WriteLine("HashdSantizedDocumentContent", HashdSantizedDocumentContent);
            String EncryptedDigestUsingPrivateKey = await EncryptDigestUsingPrivateKeyAsync(HashdSantizedDocumentContent);
            Console.WriteLine("EncryptedDigestUsingPrivateKey", EncryptedDigestUsingPrivateKey);

        }
        private static Task<string> SantizeDocumentContentAsync(string documentContent)
        {
            return Task.Run<string>(() =>
            {
                return SantizeDocumentContent(documentContent);
            });
        }
        static string SantizeDocumentContent(string documentContent)
        {
            Task.Delay(3000).Wait();
            return documentContent + " Santized ";
        }



        private static Task<string> HashSantizedDocumentContentAsync(string santizedDocumentContent)
        {
            return Task.Run<string>(() =>
            {
                return HashSantizedDocumentContent(santizedDocumentContent);
            });
        }
        static string HashSantizedDocumentContent(string santizedDocumentContent)
        {
            Task.Delay(3000).Wait();
            return santizedDocumentContent + " Hashed ";
        }


        private static Task<string> EncryptDigestUsingPrivateKeyAsync(string digest)
        {
            return Task.Run<string>(() =>
            {
                return EncryptDigestUsingPrivateKey(digest);
            });
        }
        static string EncryptDigestUsingPrivateKey(string digest)
        {
            Task.Delay(3000).Wait();
            return digest + " Encrypted ";
        }

    }
}


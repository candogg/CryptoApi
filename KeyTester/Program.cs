using CryptoApi.Shared.Extensions;

var myString = "candogu_deneme_123";

Console.Write($"Clear: {myString}\n");

var encryptedString = myString.AsEncrypted();

Console.Write($"Encrypted: {encryptedString}\n");

var decryptedString = encryptedString.AsDecrypted();

Console.Write($"Decrypted: {decryptedString}\n");